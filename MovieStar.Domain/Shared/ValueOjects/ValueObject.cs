using System.Reflection;

namespace MovieStar.Domain.Shared.ValueObjects
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType()) return false;

            var other = (T)obj;

            var properties = GetProperties();

            foreach (var prop in properties)
            {
                var thisValue = prop.GetValue(this);
                var otherValue = prop.GetValue(other);

                if (thisValue == null ^ otherValue == null) return false;

                if (thisValue is null) continue;

                if (thisValue is IEnumerable<byte> thisBytes && otherValue is IEnumerable<byte> otherBytes)
                {
                    if (!thisBytes.SequenceEqual(otherBytes)) return false;
                }
                else if (!thisValue.Equals(otherValue))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            var properties = GetProperties();

            int hash = 17;

            foreach (var prop in properties)
            {
                var value = prop.GetValue(this);

                if (value == null)
                    continue;

                if (value is IEnumerable<byte> bytes)
                {
                    foreach (var b in bytes)
                    {
                        hash = hash * 31 + b.GetHashCode();
                    }
                }
                else
                {
                    hash = hash * 31 + value.GetHashCode();
                }
            }

            return hash;
        }

        private static IEnumerable<PropertyInfo> GetProperties()
        {
            return typeof(T)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.CanRead);
        }
    }
}

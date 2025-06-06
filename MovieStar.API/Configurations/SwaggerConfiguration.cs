namespace MovieStar.API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "MovieStar API",
                    Version = "v1",
                    Description = "API for MovieStar application"
                });
            });
            return services;
        }
    }
}

namespace MovieStar.API.Configurations
{
    public static class ApplicationConfiguration
    {
        public static WebApplication AddApplicationConfiguration(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}

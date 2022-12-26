using QRCodeGeneration.Data;

namespace QRCodeGeneration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var buildedApp = BuildQRCodeGenerationApp(args);
            var application = ConfigureQRCodeGenerationApp(buildedApp);
            application.Run();
        }

        public static WebApplication BuildQRCodeGenerationApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            services.AddDbContext<DbContextClass>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddApplicationInsightsTelemetry();
            return builder.Build();
               
        }

        private static WebApplication ConfigureQRCodeGenerationApp(WebApplication app)
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

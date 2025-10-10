
using Chatapp.API.Mapping;
using Chatapp.Infrastructure;
using Chatapp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Chatapp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            builder.Services.AddInfrastructureServices(builder.Configuration);

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<UserMapping>();
                cfg.AddProfile<MessageMapping>();
                cfg.AddProfile<GroupMapping>();
            });
            builder.Services.AddCors(
                  options => options.AddPolicy("CORSPolicy", builder =>
                  {
                      builder.WithOrigins("http://localhost:4200")
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials();
                  }
            ));



            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseCors("CORSPolicy");

            app.UseAuthorization();



            app.MapControllers();

            app.UseStaticFiles();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<AppDbContext>();

                    context.Database.EnsureCreated();

                    SeedData.Initialize(context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error during DB setup: {ex.Message}");
                }
            }


            app.Run();
        }
    }
}

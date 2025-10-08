
using Chatapp.API.Mapping;
using Chatapp.Infrastructure;

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

            app.Run();
        }
    }
}

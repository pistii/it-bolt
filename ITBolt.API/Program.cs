using ItBolt.Model.Entities;
using ITBolt.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;


namespace ITBolt.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Az appsettings.json fájlból olvasson be adatot
            builder.Services.AddDbContext<ITBoltContext>(options =>
                options.UseMySql(
                    builder.Configuration.GetConnectionString("ITDB"),
                    ServerVersion.Parse("10.4.6-mariadb")));



            // Configure the HTTP request pipeline.
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:5173");
                                  });
            });
            builder.Services.AddControllers();

            var app = builder.Build();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }

}
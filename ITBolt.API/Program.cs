using ItBolt.Model.Entities;
using ITBolt.API.Data;
using Microsoft.EntityFrameworkCore;


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

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }

}
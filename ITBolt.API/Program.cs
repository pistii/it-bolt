using ItBolt.Model.Entities;
using ITBolt.API.Controllers;
using ITBolt.API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using ApiClient.Helpers;
using ApiClient.Authorization;
using ApiClient.Services;

namespace ITBolt.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Az appsettings.json fájlból olvasson be adatot
            builder.Services.AddDbContext<ITBoltContext>(options =>
                options.UseMySql(
                    builder.Configuration.GetConnectionString("ITDB"),
                    ServerVersion.Parse("10.4.6-mariadb")));



           // Configure the HTTP request pipeline.
           //var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
           // builder.Services.AddCors(options =>
           // {
           //     options.AddPolicy(name: MyAllowSpecificOrigins,
           //                       policy =>
           //                       {
           //                           policy.WithOrigins("http://localhost:5173");
           //                           policy.WithOrigins("http://localhost:4444");
           //                       });
           // });


            // configure strongly typed settings object
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

            // configure DI for application services
            builder.Services.AddScoped<IJwtUtils, JwtUtils>();
            builder.Services.AddScoped<IFelhasznaloService, FelhasznaloService>();


            builder.Services.AddControllers().AddNewtonsoftJson();
            builder.Services.AddControllers();
            
            //Authentication
            var app = builder.Build();

            //app.UseCors(MyAllowSpecificOrigins);

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            //custom jwt aut middleware
            app.UseMiddleware<JwtMiddleware>();
            app.MapControllers();
            app.Run();

            
        }


    }

}
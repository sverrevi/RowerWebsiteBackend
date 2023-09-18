global using RowerWebsiteBackend.Models;
global using RowerWebsiteBackend.Data;
using RowerWebsiteBackend.Services.RowerService;
using RowerWebsiteBackend.Services.RowingClubService;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json.Serialization;

namespace RowerWebsiteBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration
            .GetConnectionString("AzureDBConnection")));
            builder.Services.AddAutoMapper(typeof(Program).Assembly);


            //For local database
            /*
            builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration
            .GetConnectionString("LocalConnectionString")));
            */

            //For external database
            /*
            builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration
            .GetConnectionString("AzureDBConnection")));
            */

            //Avoid object cycles
            builder.Services.AddControllersWithViews()
            .AddJsonOptions(options => options.JsonSerializerOptions
            .ReferenceHandler = ReferenceHandler.IgnoreCycles);

            //CORS-settings in development
            var allowedOriginsPolicy = "_allowedOriginsPolicy";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: allowedOriginsPolicy,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5173/")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
            

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IRowerService, RowerService>();
            builder.Services.AddScoped<IRowingClubService, RowingClubService>();
            builder.Services.AddDbContext<DataContext>();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseCors(options =>
            {
                options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            });

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
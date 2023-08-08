global using RowerWebsiteBackend.Models;
global using RowerWebsiteBackend.Data;
using RowerWebsiteBackend.Services.RowerService;
using RowerWebsiteBackend.Services.RowingClubService;
using Microsoft.Extensions.Configuration;
using IBM.Data.DB2.Core;
using Microsoft.AspNetCore.Hosting;

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


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IRowerService, RowerService>();
            builder.Services.AddScoped<IRowingClubService, RowingClubService>();
            builder.Services.AddDbContext<DataContext>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
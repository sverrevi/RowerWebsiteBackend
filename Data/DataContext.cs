global using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting.Server;
using RowerWebsiteBackend.Models.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

//Local connection string: "Server =.\\SQLExpress;Database=RowersProjectDB;Trusted_Connection=true;TrustServerCertificate=true;"

namespace RowerWebsiteBackend.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }
        public DbSet<Rower> Rowers { get; set; }
        public DbSet<RowingClub> RowingClubs { get; set; }

    }
}

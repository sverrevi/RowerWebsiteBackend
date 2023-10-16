global using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RowerWebsiteBackend.Models.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RowerWebsiteBackend.Data
{
    public class DataContext: IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }
        public DbSet<Rower> Rowers { get; set; }
        public DbSet<RowingClub> RowingClubs { get; set; }
        public DbSet<User> Users { get; set; }

    }
}

using AirportDataGridView.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportDataGridView.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Plane> Planes { get; set; }

        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Airport;Trusted_Connection=True;");
    }
}

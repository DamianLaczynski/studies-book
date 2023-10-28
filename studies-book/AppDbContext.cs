using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using studies_book.Entities;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace studies_book
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(c => c.Id)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("StudiesBookApiDatabase"));
        }
    }
}
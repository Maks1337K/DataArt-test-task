using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTest.Models;
using TaskTest.Models.DBModels;

namespace TaskTest
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Incidents> Incidents { get; set; }

        public DbSet<Contacts> Contacts { get; set; }

        public DbSet<Accounts> Accounts { get; set; }

        //public DbSet<RegisterIncident> RegisterIncidents { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DATestTask");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Accounts>()
            .Property(el => el.Id)
            .ValueGeneratedOnAdd();
            builder.Entity<Contacts>()
            .Property(el => el.Id)
            .ValueGeneratedOnAdd();
            builder.Entity<Contacts>()
                .HasIndex(el => el.Email)
                .IsUnique();
            builder.Entity<Accounts>()
                .HasKey(el => el.Id);
            builder.Entity<Contacts>()
                .HasKey(el => el.Id);
            builder.Entity<Incidents>()
                .HasKey(el => el.Name);
            builder.Entity<Incidents>()
                .HasMany(el => el.Account);
            builder.Entity<Accounts>()
                .HasMany(el => el.Contact);
        }
    }
}

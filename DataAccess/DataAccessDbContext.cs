using System;
using System.Collections.Generic;
using System.Text;
using FastDataAccess.Contract;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DataAccessDbContext : DbContext
    {
        public DataAccessDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=IndexedFiles;Trusted_Connection=True;");
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<ItemPath> ItemPaths { get; set; }
    }
}

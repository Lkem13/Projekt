using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class DataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = application.db");
        }

        public DbSet<Logowanie> Logowanie { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Adres> Adres { get; set; }
    }
}

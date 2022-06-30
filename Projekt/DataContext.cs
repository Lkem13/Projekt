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
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=application;Trusted_Connection=True;");
        }

        public DbSet<Pracownicy> Pracownik { get; set; }
        public DbSet<Logowanie> Logon { get; set; }
        public DbSet<Adresy> Adres { get; set; }
        public DbSet<Stanowiska> Stanowisko { get; set; }
        public DbSet<Placowki> Placowka { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adresy>()
                .HasOne(b => b.Pracownicy)
                .WithOne(i => i.Adres)
                .HasForeignKey<Pracownicy>(b => b.AdresyId);

            modelBuilder.Entity<Stanowiska>()
                .HasOne(b => b.Pracownicy)
                .WithOne(i => i.Stanowisko)
                .HasForeignKey<Pracownicy>(b => b.StanowiskaId);

            modelBuilder.Entity<Placowki>()
                .HasOne(b => b.Pracownicy)
                .WithOne(i => i.Placowka)
                .HasForeignKey<Pracownicy>(b => b.PlacowkiId);

            modelBuilder.Entity<Logowanie>()
                .HasIndex(u => u.Login)
                .IsUnique();
        }
    }
}

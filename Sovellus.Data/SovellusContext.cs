using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Sovellus.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sovellus.Data
{
    public class SovellusContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Alue> Alueet { get; set; }
        public DbSet<Arviointi> Arvioinnit { get; set; }
        public DbSet<Kaupunki> Kaupungit { get; set; }
        public DbSet<Ravintola> Ravintolat { get; set; }
        public DbSet<RavintolaTyyppi> RavintolaTyypit { get; set; }
        public DbSet<Uutinen> Uutiset { get; set; }
        public SovellusContext(DbContextOptions<SovellusContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model
                                                     .GetEntityTypes()
                                                     .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            MapAlue(modelBuilder);
            MapArviointi(modelBuilder);
            MapKaupunki(modelBuilder);
            MapRavintola(modelBuilder);
            MapRavintolaTyyppi(modelBuilder);
            MapUutinen(modelBuilder);
        }

        private void MapAlue(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alue>().ToTable("Alue", "R");
            modelBuilder.Entity<Alue>().HasKey(a => a.Id);
            modelBuilder.Entity<Alue>().Property(a => a.Id).HasColumnName("Id").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Alue>().Property(a => a.Nimi).HasColumnName("Nimi").IsRequired().HasMaxLength(200);
        }
        private void MapArviointi(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arviointi>().ToTable("Arviointi", "R");
            modelBuilder.Entity<Arviointi>().HasKey(a => a.Id);
            modelBuilder.Entity<Arviointi>().Property(a => a.Id).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Arviointi>().Property(a => a.RavintolaId).HasColumnName("RavintolaId").IsRequired();
            modelBuilder.Entity<Arviointi>().Property(a => a.Teksti).HasColumnName("Teksti").HasMaxLength(1000);
            modelBuilder.Entity<Arviointi>().Property(a => a.Arvio).HasColumnName("Arvio").IsRequired();
            modelBuilder.Entity<Arviointi>().Property(a => a.HintaLaatu).HasColumnName("HintaLaatu");
            modelBuilder.Entity<Arviointi>().Property(a => a.Palvelu).HasColumnName("Palvelu");
            modelBuilder.Entity<Arviointi>().Property(a => a.Ymparisto).HasColumnName("Ymparisto");
            modelBuilder.Entity<Arviointi>().Property(a => a.Aika).HasColumnName("Aika").IsRequired();

            modelBuilder.Entity<Arviointi>().HasOne(a => a.Ravintola).WithMany(b => b.Arvioinnit).HasForeignKey(a => a.RavintolaId);
        }

        private void MapKaupunki(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kaupunki>().ToTable("Kaupunki", "R");
            modelBuilder.Entity<Kaupunki>().HasKey(a => a.Id);
            modelBuilder.Entity<Kaupunki>().Property(a => a.Id).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Kaupunki>().Property(a => a.Nimi).HasColumnName("Nimi").IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Kaupunki>().Property(a => a.AlueId).HasColumnName("AlueId").IsRequired();

            modelBuilder.Entity<Kaupunki>().HasOne(a => a.Alue).WithMany(b => b.Kaupungit).HasForeignKey(a => a.AlueId);
        }
        private void MapRavintola(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ravintola>().ToTable("Ravintola", "R");
            modelBuilder.Entity<Ravintola>().HasKey(a => a.Id);
            modelBuilder.Entity<Ravintola>().Property(a => a.Id).HasColumnName("Id").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Ravintola>().Property(a => a.Nimi).HasColumnName("Nimi").IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Ravintola>().Property(a => a.KaupunkiId).HasColumnName("KaupunkiId").IsRequired();
            modelBuilder.Entity<Ravintola>().Property(a => a.TyyppiId).HasColumnName("TyyppiId");
            modelBuilder.Entity<Ravintola>().Property(a => a.Katuosoite).HasColumnName("Katuosoite").HasMaxLength(200);
            modelBuilder.Entity<Ravintola>().Property(a => a.Postinro).HasColumnName("Postinro").HasMaxLength(5);
            modelBuilder.Entity<Ravintola>().Property(a => a.KuvaUrl).HasColumnName("KuvaUrl").HasMaxLength(200);
            modelBuilder.Entity<Ravintola>().Property(a => a.KotisivuUrl).HasColumnName("KotisivuUrl").HasMaxLength(200);

            modelBuilder.Entity<Ravintola>().HasOne(a => a.Kaupunki).WithMany(b => b.Ravintolat).HasForeignKey(a => a.KaupunkiId);
            modelBuilder.Entity<Ravintola>().HasOne(a => a.RavintolaTyyppi).WithMany(b => b.Ravintolat).HasForeignKey(a =>
            a.TyyppiId);
        }
        private void MapRavintolaTyyppi(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RavintolaTyyppi>().ToTable("RavintolaTyyppi", "R");
            modelBuilder.Entity<RavintolaTyyppi>().HasKey(a => a.Id);
            modelBuilder.Entity<RavintolaTyyppi>().Property(a => a.Id).HasColumnName("Id").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<RavintolaTyyppi>().Property(a => a.Nimi).HasColumnName("Nimi").IsRequired().HasMaxLength(50);
        }
        private void MapUutinen(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Uutinen>().ToTable("Uutinen", "R");
            modelBuilder.Entity<Uutinen>().HasKey(a => a.Id);
            modelBuilder.Entity<Uutinen>().Property(a => a.Id).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Uutinen>().Property(a => a.RavintolaId).HasColumnName("RavintolaId").IsRequired();
            modelBuilder.Entity<Uutinen>().Property(a => a.Teksti).HasColumnName("Teksti").HasMaxLength(1000);
            modelBuilder.Entity<Uutinen>().Property(a => a.Aika).HasColumnName("Aika").IsRequired();
            modelBuilder.Entity<Uutinen>().Property(a => a.JulkaisuAika).HasColumnName("JulkaisuAika").IsRequired();

            modelBuilder.Entity<Uutinen>().HasOne(a => a.Ravintola).WithMany(b => b.Uutiset).HasForeignKey(a => a.RavintolaId);
        }
    }
}

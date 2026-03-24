using Microsoft.EntityFrameworkCore;
using NotKayitSistemi.Models.Entities;
using NotKayitSistemi.Models; // 🔥 AppUser için

namespace NotKayitSistemi.Models.DataContext
{
    public class NotKayitDbContext : DbContext
    {
        public NotKayitDbContext(DbContextOptions options) : base(options) { }

        public DbSet<OgrenciTml> OgrenciTml { get; set; }
        public DbSet<OgrenciIletisim> OgrenciIletisim { get; set; }
        public DbSet<OgrenciAdres> OgrenciAdres { get; set; }

        public DbSet<OgrenciDers> OgrenciDers { get; set; }
        public DbSet<DersAlanKodTml> DersAlanKodTml { get; set; }
        public DbSet<DersTml> DersTml { get; set; }

        public DbSet<NotKodTml> NotKodTml { get; set; }
        public DbSet<NotTml> NotTml { get; set; }

        // 🔐 LOGIN TABLOSU
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔥 TABLO EŞLEME (EN ÖNEMLİ KISIM)
            modelBuilder.Entity<AppUser>().ToTable("AppUsers");

            // DersTml -> DersAlanKodTml FK
            modelBuilder.Entity<DersTml>()
                .HasOne(d => d.DersAlanKodTml)
                .WithMany(a => a.Dersler)
                .HasForeignKey(d => d.DersAlanKodId)
                .OnDelete(DeleteBehavior.Restrict);

            // OgrenciDers -> DersTml FK (DersId)
            modelBuilder.Entity<OgrenciDers>()
                .HasOne(od => od.DersTml)
                .WithMany(d => d.OgrenciDersler)
                .HasForeignKey(od => od.DersId)
                .OnDelete(DeleteBehavior.Restrict);

            // NotTml -> DersTml FK (DersId)
            modelBuilder.Entity<NotTml>()
                .HasOne(n => n.DersTml)
                .WithMany(d => d.Notlar)
                .HasForeignKey(n => n.DersId)
                .OnDelete(DeleteBehavior.Restrict);

            // NotTml -> NotKodTml FK
            modelBuilder.Entity<NotTml>()
                .HasOne(n => n.NotKodTml)
                .WithMany(k => k.Notlar)
                .HasForeignKey(n => n.NotKodTmlId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
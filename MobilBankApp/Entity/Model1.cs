namespace MobilBankApp.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Banka> Banka { get; set; }
        public virtual DbSet<Eft> Eft { get; set; }
        public virtual DbSet<Fatura> Fatura { get; set; }
        public virtual DbSet<FaturaTur> FaturaTur { get; set; }
        public virtual DbSet<GirisMesaj> GirisMesaj { get; set; }
        public virtual DbSet<Havale> Havale { get; set; }
        public virtual DbSet<Hesap> Hesap { get; set; }
        public virtual DbSet<HesapOzeti> HesapOzeti { get; set; }
        public virtual DbSet<IslemTur> IslemTur { get; set; }
        public virtual DbSet<KrediBasvuru> KrediBasvuru { get; set; }
        public virtual DbSet<KrediTur> KrediTur { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<Sehir> Sehir { get; set; }
        public virtual DbSet<SigortaHareket> SigortaHareket { get; set; }
        public virtual DbSet<SigortaKampanya> SigortaKampanya { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<YardimMesaj> YardimMesaj { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FaturaTur>()
                .Property(e => e.Ad)
                .IsUnicode(false);

            modelBuilder.Entity<FaturaTur>()
                .HasMany(e => e.Fatura)
                .WithOptional(e => e.FaturaTur1)
                .HasForeignKey(e => e.FaturaTur);

            modelBuilder.Entity<GirisMesaj>()
                .Property(e => e.Mesaj)
                .IsUnicode(false);

            modelBuilder.Entity<Hesap>()
                .HasMany(e => e.Eft)
                .WithRequired(e => e.Hesap)
                .HasForeignKey(e => e.GonderenID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hesap>()
                .HasMany(e => e.Havale)
                .WithRequired(e => e.Hesap)
                .HasForeignKey(e => e.GonderenID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IslemTur>()
                .Property(e => e.Ad)
                .IsUnicode(false);

            modelBuilder.Entity<IslemTur>()
                .HasMany(e => e.HesapOzeti)
                .WithOptional(e => e.IslemTur)
                .HasForeignKey(e => e.IslemId);

            modelBuilder.Entity<KrediTur>()
                .HasMany(e => e.KrediBasvuru)
                .WithRequired(e => e.KrediTur1)
                .HasForeignKey(e => e.KrediTur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Musteri>()
                .HasMany(e => e.SigortaHareket)
                .WithRequired(e => e.Musteri)
                .HasForeignKey(e => e.Yaptiran)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sehir>()
                .HasMany(e => e.Musteri)
                .WithRequired(e => e.Sehir1)
                .HasForeignKey(e => e.Sehir)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SigortaKampanya>()
                .HasMany(e => e.SigortaHareket)
                .WithRequired(e => e.SigortaKampanya1)
                .HasForeignKey(e => e.SigortaKampanya)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<YardimMesaj>()
                .Property(e => e.Mesaj)
                .IsUnicode(false);
        }
    }
}

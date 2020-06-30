using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SportAPISever.Model;

namespace SportAPISever.Context
{
    public partial class HollywoodbetsDBContext : DbContext
    {
        public HollywoodbetsDBContext()
        {
        }

        public HollywoodbetsDBContext(DbContextOptions<HollywoodbetsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BetTypes> BetTypes { get; set; }
        public virtual DbSet<BettyepeMarkets> BettyepeMarkets { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Market> Market { get; set; }
        public virtual DbSet<SportCountry> SportCountry { get; set; }
        public virtual DbSet<SportTournament> SportTournament { get; set; }
        public virtual DbSet<SportTypes> SportTypes { get; set; }
        public virtual DbSet<Tournament> Tournament { get; set; }
        public virtual DbSet<TournamentBeTypes> TournamentBeTypes { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=(LocalDb)\\LocalDb;Database=HollywoodbetsDB;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BetTypes>(entity =>
            {
                entity.HasKey(e => e.Betypeid)
                    .HasName("PK__BetTypes__1857206B77CA616E");

                entity.Property(e => e.Betypeid).HasColumnName("betypeid");

                entity.Property(e => e.Bettype)
                    .HasColumnName("bettype")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<BettyepeMarkets>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BetTypeId).HasColumnName("BetTypeID");

                entity.Property(e => e.BetypeMarketId).HasColumnName("BetypeMarketID");

                entity.HasOne(d => d.BetType)
                    .WithMany()
                    .HasForeignKey(d => d.BetTypeId)
                    .HasConstraintName("FK__BettyepeM__BetTy__38996AB5");

                entity.HasOne(d => d.BetypeMarket)
                    .WithMany()
                    .HasForeignKey(d => d.BetypeMarketId)
                    .HasConstraintName("FK__BettyepeM__Betyp__37A5467C");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Flagurl)
                    .HasColumnName("flagurl")
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__Events__29D84CBBED66EE30");

                entity.Property(e => e.EventId).HasColumnName("EVentID");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventName).HasMaxLength(100);

                entity.Property(e => e.TournamentId).HasColumnName("TournamentID");
            });

            modelBuilder.Entity<Market>(entity =>
            {
                entity.Property(e => e.MarkeType).HasMaxLength(100);
            });

            modelBuilder.Entity<SportCountry>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sportCountry");
            });

            modelBuilder.Entity<SportTournament>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<SportTypes>(entity =>
            {
                entity.HasKey(e => e.SportId)
                    .HasName("PK__sportTyp__AC9F70485F715672");

                entity.ToTable("sportTypes");

                entity.Property(e => e.SportId).HasColumnName("sportId");

                entity.Property(e => e.Imageurl).HasColumnName("imageurl");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.Property(e => e.TournamentId).HasColumnName("TournamentID");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TournamentBeTypes>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.TournamentBetypeId).HasColumnName("TournamentBetypeID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

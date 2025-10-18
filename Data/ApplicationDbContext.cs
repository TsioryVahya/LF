using Microsoft.EntityFrameworkCore;
using LF.Models;

namespace LF.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Tables
    public DbSet<NatureImpots> NatureImpots { get; set; }
    public DbSet<RecettesInterieurs> RecettesInterieurs { get; set; }
    public DbSet<NatureDroitsetTaxes> NatureDroitsetTaxes { get; set; }
    public DbSet<RecettesDouanieres> RecettesDouanieres { get; set; }
    public DbSet<NatureRecettesNonFiscales> NatureRecettesNonFiscales { get; set; }
    public DbSet<RecettesNonFiscales> RecettesNonFiscales { get; set; }
    public DbSet<NatureDons> NatureDons { get; set; }
    public DbSet<Dons> Dons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuration des tables
        modelBuilder.Entity<NatureImpots>(entity =>
        {
            entity.ToTable("natureimpots");
            entity.HasKey(e => e.IdNatureImpots);
            entity.Property(e => e.IdNatureImpots).HasColumnName("idnatureimpots");
            entity.Property(e => e.Nom).HasColumnName("nom").HasMaxLength(50).IsRequired();
        });

        modelBuilder.Entity<RecettesInterieurs>(entity =>
        {
            entity.ToTable("recettesinterieurs");
            entity.HasKey(e => e.IdRecettesInterieurs);
            entity.Property(e => e.IdRecettesInterieurs).HasColumnName("idrecettesinterieurs");
            entity.Property(e => e.Annee).HasColumnName("annee").IsRequired();
            entity.Property(e => e.Montant).HasColumnName("montant").HasPrecision(15, 2).IsRequired();
            entity.Property(e => e.IdNatureImpots).HasColumnName("idnatureimpots").IsRequired();
            
            entity.HasOne(e => e.NatureImpot)
                .WithMany(n => n.RecettesInterieurs)
                .HasForeignKey(e => e.IdNatureImpots)
                .HasConstraintName("fk_recettes_interieurs_nature")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<NatureDroitsetTaxes>(entity =>
        {
            entity.ToTable("naturedroitsettaxes");
            entity.HasKey(e => e.IdNatureDroitsetTaxes);
            entity.Property(e => e.IdNatureDroitsetTaxes).HasColumnName("idnaturedroitsettaxes");
            entity.Property(e => e.Nom).HasColumnName("nom").HasMaxLength(50).IsRequired();
        });

        modelBuilder.Entity<RecettesDouanieres>(entity =>
        {
            entity.ToTable("recettesdouanieres");
            entity.HasKey(e => e.IdRecettesDouanieres);
            entity.Property(e => e.IdRecettesDouanieres).HasColumnName("idrecettesdouanieres");
            entity.Property(e => e.Annee).HasColumnName("annee").IsRequired();
            entity.Property(e => e.Montant).HasColumnName("montant").HasPrecision(15, 2).IsRequired();
            entity.Property(e => e.IdNatureDroitsetTaxes).HasColumnName("idnaturedroitsettaxes").IsRequired();
            
            entity.HasOne(e => e.NatureDroitsetTaxes)
                .WithMany(n => n.RecettesDouanieres)
                .HasForeignKey(e => e.IdNatureDroitsetTaxes)
                .HasConstraintName("fk_recettes_douanieres_nature")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<NatureRecettesNonFiscales>(entity =>
        {
            entity.ToTable("naturerecettesnonfiscales");
            entity.HasKey(e => e.IdNatureRecettesNonFiscales);
            entity.Property(e => e.IdNatureRecettesNonFiscales).HasColumnName("idnaturerecettesnonfiscales");
            entity.Property(e => e.Nom).HasColumnName("nom").HasMaxLength(50).IsRequired();
        });

        modelBuilder.Entity<RecettesNonFiscales>(entity =>
        {
            entity.ToTable("recettesnonfiscales");
            entity.HasKey(e => e.IdRecettesNonFiscales);
            entity.Property(e => e.IdRecettesNonFiscales).HasColumnName("idrecettesnonfiscales");
            entity.Property(e => e.Annee).HasColumnName("annee").IsRequired();
            entity.Property(e => e.Montant).HasColumnName("montant").HasPrecision(15, 2).IsRequired();
            entity.Property(e => e.IdNatureRecettesNonFiscales).HasColumnName("idnaturerecettesnonfiscales").IsRequired();
            
            entity.HasOne(e => e.NatureRecettesNonFiscales)
                .WithMany(n => n.RecettesNonFiscales)
                .HasForeignKey(e => e.IdNatureRecettesNonFiscales)
                .HasConstraintName("fk_recettes_non_fiscales_nature")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<NatureDons>(entity =>
        {
            entity.ToTable("naturedons");
            entity.HasKey(e => e.IdNatureDons);
            entity.Property(e => e.IdNatureDons).HasColumnName("idnaturedons");
            entity.Property(e => e.Nom).HasColumnName("nom").HasMaxLength(50).IsRequired();
        });

        modelBuilder.Entity<Dons>(entity =>
        {
            entity.ToTable("dons");
            entity.HasKey(e => e.IdDons);
            entity.Property(e => e.IdDons).HasColumnName("iddons");
            entity.Property(e => e.Annee).HasColumnName("annee").IsRequired();
            entity.Property(e => e.Montant).HasColumnName("montant").HasPrecision(15, 2).IsRequired();
            entity.Property(e => e.IdNatureDons).HasColumnName("idnaturedons").IsRequired();
            
            entity.HasOne(e => e.NatureDons)
                .WithMany(n => n.Dons)
                .HasForeignKey(e => e.IdNatureDons)
                .HasConstraintName("fk_dons_nature")
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}

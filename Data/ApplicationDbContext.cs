using Microsoft.EntityFrameworkCore;
using LF.Models;

namespace LF.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Tables - Recettes
    public DbSet<NatureImpots> NatureImpots { get; set; }
    public DbSet<RecettesInterieurs> RecettesInterieurs { get; set; }
    public DbSet<NatureDroitsetTaxes> NatureDroitsetTaxes { get; set; }
    public DbSet<RecettesDouanieres> RecettesDouanieres { get; set; }
    public DbSet<NatureRecettesNonFiscales> NatureRecettesNonFiscales { get; set; }
    public DbSet<RecettesNonFiscales> RecettesNonFiscales { get; set; }
    public DbSet<NatureDons> NatureDons { get; set; }
    public DbSet<Dons> Dons { get; set; }

    // Tables - Dépenses
    public DbSet<NatureDepenses> NatureDepenses { get; set; }
    public DbSet<DepensesParNature> DepensesParNature { get; set; }
    public DbSet<DepensesSoldePensions> DepensesSoldePensions { get; set; }
    public DbSet<DepensesFonctionnement> DepensesFonctionnement { get; set; }
    public DbSet<DepensesInvestissement> DepensesInvestissement { get; set; }
    public DbSet<DepensesAdministratives> DepensesAdministratives { get; set; }
    public DbSet<DeficitBudgetaire> DeficitBudgetaire { get; set; }

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

        // Configuration des tables de dépenses
        modelBuilder.Entity<NatureDepenses>(entity =>
        {
            entity.ToTable("naturedepenses");
            entity.HasKey(e => e.IdNatureDepenses);
            entity.Property(e => e.IdNatureDepenses).HasColumnName("idnaturedepenses");
            entity.Property(e => e.Nom).HasColumnName("nom").HasMaxLength(250).IsRequired();
        });

        modelBuilder.Entity<DepensesParNature>(entity =>
        {
            entity.ToTable("depensesparnature");
            entity.HasKey(e => e.IdDepensesParNature);
            entity.Property(e => e.IdDepensesParNature).HasColumnName("iddepensesparnature");
            entity.Property(e => e.Annee).HasColumnName("annee").IsRequired();
            entity.Property(e => e.Montant).HasColumnName("montant").HasPrecision(15, 2).IsRequired();
            entity.Property(e => e.IdNatureDepenses).HasColumnName("idnaturedepenses").IsRequired();
            
            entity.HasOne(e => e.NatureDepenses)
                .WithMany(n => n.DepensesParNature)
                .HasForeignKey(e => e.IdNatureDepenses)
                .HasConstraintName("fk_depenses_nature")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<DepensesSoldePensions>(entity =>
        {
            entity.ToTable("depensessoldepensions");
            entity.HasKey(e => e.IdDepensesSolde);
            entity.Property(e => e.IdDepensesSolde).HasColumnName("iddepensessolde");
            entity.Property(e => e.Annee).HasColumnName("annee").IsRequired();
            entity.Property(e => e.Montant).HasColumnName("montant").HasPrecision(15, 2).IsRequired();
            entity.Property(e => e.SoldePib).HasColumnName("solde_pib").HasPrecision(5, 2);
            entity.Property(e => e.SoldeRecettesFiscales).HasColumnName("solde_recettes_fiscales").HasPrecision(5, 2);
            entity.Property(e => e.SoldeDepensesTotales).HasColumnName("solde_depenses_totales").HasPrecision(5, 2);
        });

        modelBuilder.Entity<DepensesFonctionnement>(entity =>
        {
            entity.ToTable("depensesfonctionnement");
            entity.HasKey(e => e.IdDepensesFonctionnement);
            entity.Property(e => e.IdDepensesFonctionnement).HasColumnName("iddepensesfonctionnement");
            entity.Property(e => e.Annee).HasColumnName("annee").IsRequired();
            entity.Property(e => e.Indemnites).HasColumnName("indemnites").HasPrecision(15, 2);
            entity.Property(e => e.BiensServices).HasColumnName("biens_services").HasPrecision(15, 2);
            entity.Property(e => e.Transferts).HasColumnName("transferts").HasPrecision(15, 2);
            entity.Property(e => e.Total).HasColumnName("total").HasPrecision(15, 2);
        });

        modelBuilder.Entity<DepensesInvestissement>(entity =>
        {
            entity.ToTable("depensesinvestissement");
            entity.HasKey(e => e.IdDepensesInvestissement);
            entity.Property(e => e.IdDepensesInvestissement).HasColumnName("iddepensesinvestissement");
            entity.Property(e => e.Annee).HasColumnName("annee").IsRequired();
            entity.Property(e => e.FinancementInterne).HasColumnName("financement_interne").HasPrecision(15, 2);
            entity.Property(e => e.FinancementExterne).HasColumnName("financement_externe").HasPrecision(15, 2);
            entity.Property(e => e.Total).HasColumnName("total").HasPrecision(15, 2);
        });

        modelBuilder.Entity<DepensesAdministratives>(entity =>
        {
            entity.ToTable("depensesadministratives");
            entity.HasKey(e => e.IdDepensesAdministratives);
            entity.Property(e => e.IdDepensesAdministratives).HasColumnName("iddepensesadministratives");
            entity.Property(e => e.Annee).HasColumnName("annee").IsRequired();
            entity.Property(e => e.Institution).HasColumnName("institution").HasMaxLength(250).IsRequired();
            entity.Property(e => e.Montant).HasColumnName("montant").HasPrecision(15, 2).IsRequired();
        });

        modelBuilder.Entity<DeficitBudgetaire>(entity =>
        {
            entity.ToTable("deficitbudgetaire");
            entity.HasKey(e => e.IdDeficit);
            entity.Property(e => e.IdDeficit).HasColumnName("iddeficit");
            entity.Property(e => e.Annee).HasColumnName("annee").IsRequired();
            entity.Property(e => e.DepensesTotales).HasColumnName("depenses_totales").HasPrecision(15, 2);
            entity.Property(e => e.RecettesTotales).HasColumnName("recettes_totales").HasPrecision(15, 2);
            entity.Property(e => e.Deficit).HasColumnName("deficit").HasPrecision(15, 2);
            entity.Property(e => e.FinancementExterieur).HasColumnName("financement_exterieur").HasPrecision(15, 2);
            entity.Property(e => e.FinancementInterieur).HasColumnName("financement_interieur").HasPrecision(15, 2);
        });
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LF.Models;

public class DepensesInvestissement
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdDepensesInvestissement { get; set; }

    [Required]
    public int Annee { get; set; }

    [Column(TypeName = "numeric(15,2)")]
    public decimal? FinancementInterne { get; set; }

    [Column(TypeName = "numeric(15,2)")]
    public decimal? FinancementExterne { get; set; }

    [Column(TypeName = "numeric(15,2)")]
    public decimal? Total { get; set; }
}

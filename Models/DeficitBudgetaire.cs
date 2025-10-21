using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LF.Models;

public class DeficitBudgetaire
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdDeficit { get; set; }

    [Required]
    public int Annee { get; set; }

    [Column(TypeName = "numeric(15,2)")]
    public decimal? DepensesTotales { get; set; }

    [Column(TypeName = "numeric(15,2)")]
    public decimal? RecettesTotales { get; set; }

    [Column(TypeName = "numeric(15,2)")]
    public decimal? Deficit { get; set; }

    [Column(TypeName = "numeric(15,2)")]
    public decimal? FinancementExterieur { get; set; }

    [Column(TypeName = "numeric(15,2)")]
    public decimal? FinancementInterieur { get; set; }
}

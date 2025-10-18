using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LF.Models;

public class DepensesSoldePensions
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdDepensesSolde { get; set; }

    [Required]
    public int Annee { get; set; }

    [Required]
    [Column(TypeName = "numeric(15,2)")]
    public decimal Montant { get; set; }

    [Column(TypeName = "numeric(5,2)")]
    public decimal? SoldePib { get; set; }

    [Column(TypeName = "numeric(5,2)")]
    public decimal? SoldeRecettesFiscales { get; set; }

    [Column(TypeName = "numeric(5,2)")]
    public decimal? SoldeDepensesTotales { get; set; }
}

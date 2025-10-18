using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LF.Models;

public class RecettesNonFiscales
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdRecettesNonFiscales { get; set; }

    [Required]
    public int Annee { get; set; }

    [Required]
    [Column(TypeName = "numeric(15,2)")]
    public decimal Montant { get; set; }

    [Required]
    public int IdNatureRecettesNonFiscales { get; set; }

    [ForeignKey("IdNatureRecettesNonFiscales")]
    public NatureRecettesNonFiscales? NatureRecettesNonFiscales { get; set; }
}

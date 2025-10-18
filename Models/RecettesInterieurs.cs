using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LF.Models;

public class RecettesInterieurs
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdRecettesInterieurs { get; set; }

    [Required]
    public int Annee { get; set; }

    [Required]
    [Column(TypeName = "numeric(15,2)")]
    public decimal Montant { get; set; }

    [Required]
    public int IdNatureImpots { get; set; }

    [ForeignKey("IdNatureImpots")]
    public NatureImpots? NatureImpots { get; set; }
}

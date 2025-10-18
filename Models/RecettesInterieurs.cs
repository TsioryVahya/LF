using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LF.Models;

[Table("RecettesInterieurs")]
public class RecettesInterieurs
{
    [Key]
    [Column("idRecettesInterieurs")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdRecettesInterieurs { get; set; }

    [Required]
    [Column("annee")]
    public int Annee { get; set; }

    [Required]
    [Column("montant", TypeName = "numeric(15,2)")]
    public decimal Montant { get; set; }

    [Required]
    [Column("idNatureImpots")]
    public int IdNatureImpots { get; set; }

    [ForeignKey("IdNatureImpots")]
    public NatureImpots? NatureImpot { get; set; }
}

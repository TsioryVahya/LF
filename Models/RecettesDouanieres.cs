using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LF.Models;

public class RecettesDouanieres
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdRecettesDouanieres { get; set; }

    [Required]
    public int Annee { get; set; }

    [Required]
    [Column(TypeName = "numeric(15,2)")]
    public decimal Montant { get; set; }

    [Required]
    public int IdNatureDroitsetTaxes { get; set; }

    [ForeignKey("IdNatureDroitsetTaxes")]
    public NatureDroitsetTaxes? NatureDroitsetTaxes { get; set; }
}

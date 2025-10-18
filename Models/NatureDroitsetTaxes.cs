using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LF.Models;

public class NatureDroitsetTaxes
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdNatureDroitsetTaxes { get; set; }

    [Required]
    [MaxLength(50)]
    public string Nom { get; set; } = string.Empty;

    public ICollection<RecettesDouanieres> RecettesDouanieres { get; set; } = new List<RecettesDouanieres>();
}

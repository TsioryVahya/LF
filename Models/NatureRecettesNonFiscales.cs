using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LF.Models;

public class NatureRecettesNonFiscales
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdNatureRecettesNonFiscales { get; set; }

    [Required]
    [MaxLength(50)]
    public string Nom { get; set; } = string.Empty;

    public ICollection<RecettesNonFiscales> RecettesNonFiscales { get; set; } = new List<RecettesNonFiscales>();
}

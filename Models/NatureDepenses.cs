using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LF.Models;

public class NatureDepenses
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdNatureDepenses { get; set; }

    [Required]
    [StringLength(250)]
    public string Nom { get; set; } = string.Empty;

    public ICollection<DepensesParNature>? DepensesParNature { get; set; }
}

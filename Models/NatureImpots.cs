using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LF.Models;

[Table("NatureImpots")]
public class NatureImpots
{
    [Key]
    [Column("idNatureImpots")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdNatureImpots { get; set; }

    [Required]
    [Column("nom")]
    [MaxLength(50)]
    public string Nom { get; set; } = string.Empty;

    public ICollection<RecettesInterieurs> RecettesInterieurs { get; set; } = new List<RecettesInterieurs>();
}

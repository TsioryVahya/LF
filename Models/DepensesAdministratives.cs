using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LF.Models;

public class DepensesAdministratives
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdDepensesAdministratives { get; set; }

    [Required]
    public int Annee { get; set; }

    [Required]
    [StringLength(250)]
    public string Institution { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "numeric(15,2)")]
    public decimal Montant { get; set; }
}

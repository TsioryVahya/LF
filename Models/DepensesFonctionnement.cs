using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LF.Models;

public class DepensesFonctionnement
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdDepensesFonctionnement { get; set; }

    [Required]
    public int Annee { get; set; }

    [Column(TypeName = "numeric(15,2)")]
    public decimal? Indemnites { get; set; }

    [Column(TypeName = "numeric(15,2)")]
    public decimal? BiensServices { get; set; }

    [Column(TypeName = "numeric(15,2)")]
    public decimal? Transferts { get; set; }

    [Column(TypeName = "numeric(15,2)")]
    public decimal? Total { get; set; }
}

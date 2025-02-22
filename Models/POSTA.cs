using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace E_knjiznica.Models;
public class POSTA
{
    [Key]
    public decimal Postna_stevilka { get; set; }

    [Required]
    [StringLength(100)]
    public string Kraj { get; set; }

    public ICollection<NASLOV> Naslovi { get; set; }
}
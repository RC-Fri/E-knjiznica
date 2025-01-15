using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace E_knjiznica.Models;
public class KATEGORIJA_CLANA
{
    [Key]
    public int ID_kategorija_clana { get; set; }

    [Required]
    [StringLength(50)]
    public string Opis { get; set; }

    public ICollection<CLAN> Clani { get; set; }
}
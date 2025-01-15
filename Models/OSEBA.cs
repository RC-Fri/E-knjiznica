using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace E_knjiznica.Models;
public class OSEBA
{
    [Key]
    public int ID_osebe { get; set; }

    [Required]
    [StringLength(20)]
    public string Ime { get; set; }

    [Required]
    [StringLength(20)]
    public string Priimek { get; set; }

    [StringLength(20)]
    public string Uporabnisko_ime { get; set; }
    [StringLength(20)]
    public string Geslo { get; set; }

    public CLAN Clan { get; set; }
}
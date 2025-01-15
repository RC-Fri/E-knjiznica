using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace E_knjiznica.Models;
public class NASLOV
{
    [Key]
    [Column(Order = 0)]
    public decimal Postna_stevilka { get; set; }

    [Key]
    [Column(Order = 1)]
    [StringLength(20)]
    public string Ulica { get; set; }

    [Key]
    [Column(Order = 2)]
    [StringLength(5)]
    public string Hisna_stevilka { get; set; }

    [Required]
    public int ID_osebe { get; set; }

    [ForeignKey("Postna_stevilka")]
    public POSTA Posta { get; set; }

    [ForeignKey("ID_osebe")]
    public CLAN Clan { get; set; }
}
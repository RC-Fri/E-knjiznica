using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OSEBA
{
    [Key]
    public int ID_osebe { get; set; }

    [Required]
    [StringLength(50)]
    public string Ime { get; set; }

    [Required]
    [StringLength(50)]
    public string Priimek { get; set; }

    public CLAN Clan { get; set; }
}
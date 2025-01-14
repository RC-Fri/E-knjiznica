using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class NASLOV
{
    [Key, Column(Order = 0, TypeName = "numeric(4)")]
    public int Postna_stevilka { get; set; }
    public POSTA Posta { get; set; }

    [Key, Column(Order = 1), StringLength(20)]
    public string Ulica { get; set; }

    [Key, Column(Order = 2), StringLength(5)]
    public string Hisna_stevilka { get; set; }

    [ForeignKey("Clan")]
    public int ID_osebe { get; set; }
    public CLAN Clan { get; set; }
}
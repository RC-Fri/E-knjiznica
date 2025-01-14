using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class KATEGORIJA_CLANA
{
    [Key]
    public int ID_kategorija_clana { get; set; }

    [Required, StringLength(20)]
    public string Naziv { get; set; }

    [StringLength(40)]
    public string Opis { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal Clanarina { get; set; }
}
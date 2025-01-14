using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ZAPOSLEN
{
    [Key]
    public int ID_osebe { get; set; }
    public OSEBA Oseba { get; set; }

    [ForeignKey("FunkcijaZaposlenega")]
    public int ID_funkcija { get; set; }
    public FUNKCIJA_ZAPOSLENEGA FunkcijaZaposlenega { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal Placa { get; set; }

    [Required, StringLength(20)]
    public string Uporabnisko_ime { get; set; }

    [Required, StringLength(20)]
    public string Geslo { get; set; }
}
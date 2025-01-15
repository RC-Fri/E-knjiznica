using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ZAPOSLEN
{
    [Key]
    public int ID_osebe { get; set; }
    
    [ForeignKey(nameof(ID_osebe))]
    public OSEBA Oseba { get; set; }

    [ForeignKey("Funkcija")]
    public int ID_funkcija { get; set; }
    public FUNKCIJA_ZAPOSLENEGA Funkcija { get; set; }

    public decimal Placa { get; set; }

    public ICollection<dela_v> Dela_V { get; set; }
    public ICollection<OBDELAVA_GRADIV> Obdelave { get; set; }
}
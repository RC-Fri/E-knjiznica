using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class AVTOR
{
    [Key]
    public int ID_osebe { get; set; }
    
    [ForeignKey(nameof(ID_osebe))]
    public OSEBA Oseba { get; set; }

    [StringLength(20)]
    public string Pseudonim { get; set; }

    public DateTime Datum_rojstva { get; set; }

    public DateTime? Datum_smrti { get; set; }

    public ICollection<je_kreiral> Kreacije { get; set; }
}
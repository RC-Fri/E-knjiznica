using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class FUNKCIJA_ZAPOSLENEGA
{
    [Key]
    public int ID_funkcija { get; set; }

    [Required]
    [StringLength(20)]
    public string Funkcija { get; set; }

    [StringLength(40)]
    public string Opis_dela { get; set; }

    public ICollection<ZAPOSLEN> Zaposleni { get; set; }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class je_kreiral
{
    [Key, Column(Order = 0)]
    public int ID_osebe { get; set; }
    public AVTOR Avtor { get; set; }

    [Key, Column(Order = 1)]
    public int Inventarna_stevilka { get; set; }
    public GRADIVO Gradivo { get; set; }
}
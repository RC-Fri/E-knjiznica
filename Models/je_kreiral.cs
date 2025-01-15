using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class je_kreiral
{

    [ForeignKey("Avtor")]
    public int ID_osebe { get; set; }
    public AVTOR Avtor { get; set; }

    [ForeignKey("Gradivo")]
    public int Inventarna_stevilka { get; set; }
    public GRADIVO Gradivo { get; set; }
}


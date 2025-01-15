using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class dela_v
{
    [ForeignKey("Zaposlen")]
    public int ID_osebe { get; set; }
    public ZAPOSLEN Zaposlen { get; set; }

    [ForeignKey("Podruznica")]
    public int ID_podruznice { get; set; }
    public PODRUZNICA Podruznica { get; set; }
}

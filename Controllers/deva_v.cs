using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class dela_v
{
    [Key, Column(Order = 0)]
    public int ID_osebe { get; set; }
    public ZAPOSLEN Zaposlen { get; set; }

    [Key, Column(Order = 1)]
    public int ID_podruznice { get; set; }
    public PODRUZNICA Podruznica { get; set; }
}

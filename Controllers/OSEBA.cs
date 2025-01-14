using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OSEBA
{
    [Key]
    public int ID_osebe { get; set; }

    [Required, StringLength(20)]
    public string Ime { get; set; }

    [Required, StringLength(20)]
    public string Priimek { get; set; }
}
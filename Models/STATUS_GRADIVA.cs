using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class STATUS_GRADIVA
{
    [Key]
    public int ID_status { get; set; }

    [Required, StringLength(20)]
    public string Naziv { get; set; }

    [StringLength(40)]
    public string Opis { get; set; }
}
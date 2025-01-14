using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TIP_GRADIVA
{
    [Key]
    public int ID_tip_gradiva { get; set; }

    [Required]
    [StringLength(20)]
    public string Naziv { get; set; }

    [StringLength(40)]
    public string Opis { get; set; }

    public ICollection<GRADIVO> Gradiva { get; set; }
}
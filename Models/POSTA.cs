using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class POSTA
{
    [Key]
    public string Postna_stevilka { get; set; }

    [Required]
    [StringLength(100)]
    public string Naslov { get; set; }

    public ICollection<NASLOV> Naslovi { get; set; }
}
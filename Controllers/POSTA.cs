using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class POSTA
{
    [Key]
    [Column(TypeName = "numeric(4)")]
    public int Postna_stevilka { get; set; }

    [Required, StringLength(20)]
    public string Kraj { get; set; }
}
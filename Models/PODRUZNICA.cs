using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PODRUZNICA
{
    [Key]
    public int ID_podruznice { get; set; }

    [ForeignKey("TipPodruznice")]
    public int ID_tip_podruznice { get; set; }
    public TIP_PODRUZNICE TipPodruznice { get; set; }

    [Required, StringLength(20)]
    public string Posta { get; set; }
}
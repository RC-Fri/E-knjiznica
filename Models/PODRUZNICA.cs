using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace E_knjiznica.Models;
public class PODRUZNICA
{
    [Key]
    public int ID_podruznice { get; set; }

    [ForeignKey("TipPodruznice")]
    public int ID_tip_podruznice { get; set; }
    public TIP_PODRUZNICE TipPodruznice { get; set; }

    public string Posta { get; set; }

    public ICollection<GRADIVO> Gradiva { get; set; }
    public ICollection<dela_v> Zaposleni { get; set; }
}
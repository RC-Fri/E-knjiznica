using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_knjiznica.Models;
public class GRADIVO
{
    [Key]
    public int Inventarna_stevilka { get; set; }

    [ForeignKey("TipGradiva")]
    public int ID_tip_gradiva { get; set; }
    public TIP_GRADIVA TipGradiva { get; set; }

    [ForeignKey("Zalozba")]
    public int ID_zalozba { get; set; }
    public ZALOZBA Zalozba { get; set; }

    [ForeignKey("StatusGradiva")]
    public int ID_status { get; set; }
    public STATUS_GRADIVA StatusGradiva { get; set; }

    [ForeignKey("Podruznica")]
    public int ID_podruznice { get; set; }
    public PODRUZNICA Podruznica { get; set; }

    [Required]
    [StringLength(20)]
    public string Naziv { get; set; }

    [Required]
    public DateTime Datum_izdaje { get; set; }

    public ICollection<OBDELAVA_GRADIV> Obdelave { get; set; }
}
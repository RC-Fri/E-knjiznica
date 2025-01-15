using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace E_knjiznica.Models;
public class OBDELAVA_GRADIV
{
    [Key]
    public int ID_obdelave { get; set; }

    [ForeignKey("TipObdelave")]
    public int ID_tip_obdelave { get; set; }
    public TIP_OBDELAVE TipObdelave { get; set; }

    [ForeignKey("Gradivo")]
    public int Inventarna_stevilka { get; set; }
    public GRADIVO Gradivo { get; set; }

    [ForeignKey("Zaposlen")]
    public int ID_zaposlen { get; set; }
    public ZAPOSLEN Zaposlen { get; set; }

    [ForeignKey("Clan")]
    public int ID_clan { get; set; }
    public CLAN Clan { get; set; }

    public DateTime Datum_obdelave { get; set; }

    public DateTime? Datum_od { get; set; }

    public DateTime? Datum_do { get; set; }

    public decimal? Obracun { get; set; }
}

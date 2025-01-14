using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class dela_v
{
    [Key]
    public int ID { get; set; }

    [ForeignKey("Zaposlen")]
    public int ID_zaposlen { get; set; }
    public ZAPOSLEN Zaposlen { get; set; }

    [ForeignKey("Podruznica")]
    public int ID_podruznice { get; set; }
    public PODRUZNICA Podruznica { get; set; }

    [Required]
    public DateTime Datum_zaposlitve { get; set; }

    public DateTime? Datum_odhoda { get; set; }
}

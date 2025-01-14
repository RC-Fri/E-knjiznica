using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CLAN
{
    [Key]
    public int ID_osebe { get; set; }
    public OSEBA Oseba { get; set; }

    [ForeignKey("KategorijaClana")]
    public int ID_kategorija_clana { get; set; }
    public KATEGORIJA_CLANA KategorijaClana { get; set; }

    public bool GDPR { get; set; }

    [StringLength(20)]
    public string E_posta { get; set; }

    public bool Informiranje_preko_e_poste { get; set; }

    [Required]
    public DateTime Konec_clanstva { get; set; }

    public ICollection<NASLOV> Naslovi { get; set; }

    public ICollection<OBDELAVA_GRADIV> Obdelave { get; set; }
}
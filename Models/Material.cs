using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_knjiznica.Models
{
    
public class Material
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaterialID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(50)]
        public string Genre { get; set; }

        public int? PublicationYear { get; set; }

        [ForeignKey("Author")]
        public int AuthorID { get; set; }
    }
}
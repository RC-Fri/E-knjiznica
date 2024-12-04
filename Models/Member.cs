using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_knjiznica.Models;
public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstMidName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public DateTime? MembershipDate { get; set; }

        [ForeignKey("Subsidiary")]
        public int? SubsidiaryID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string Credentials { get; set; }
    }
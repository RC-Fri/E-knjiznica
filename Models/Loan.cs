using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_knjiznica.Models
{
    

    public class Loan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanID { get; set; }

        [ForeignKey("Member")]
        public int MemberID { get; set; }

        [ForeignKey("Book")]
        public int MaterialID { get; set; }

        public DateTime? LoanDate { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}

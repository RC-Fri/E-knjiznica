using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_knjiznica.Models;
public class Material
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int MaterialID { get; set; }
    
    public ApplicationUser? Borrower { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? Title { get; set; }
}

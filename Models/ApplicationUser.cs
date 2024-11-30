using Microsoft.AspNetCore.Identity;

namespace E_knjiznica.Models;

public class ApplicationUser : IdentityUser
{
     public string? FirstName { get; set; }
     public string? LastName { get; set; }
     public int? ID { get; set; }
}

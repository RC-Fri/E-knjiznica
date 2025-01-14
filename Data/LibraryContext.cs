using E_knjiznica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace E_knjiznica.Data;
public class LibraryContext(DbContextOptions<LibraryContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public required DbSet<ZAPOSLEN> ZAPOSLEN { get; set; }
    public required DbSet<ZALOZBA> ZALOZBA { get; set; }
    public required DbSet<TIP_PODRUZNICE> TIP_PODRUZNICE { get; set; }
    public required DbSet<TIP_OBDELAVE> TIP_OBDELAVE { get; set; }
    public required DbSet<TIP_GRADIVA> TIP_GRADIVA { get; set; }
    public required DbSet<STATUS_GRADIVA> STATUS_GRADIVA { get; set; }
    public required DbSet<POSTA> POSTA { get; set; }
    public required DbSet<PODRUZNICA> PODRUZNICA { get; set; }
    public required DbSet<OSEBA> OSEBA { get; set; }
    public required DbSet<OBDELAVA_GRADIV> OBDELAVA_GRADIV { get; set; }
    public required DbSet<NASLOV> NASLOV { get; set; }
    public required DbSet<KATEGORIJA_CLANA> KATEGORIJA_CLANA { get; set; }
    public required DbSet<je_kreiral> je_Kreiral { get; set; }
    public required DbSet<GRADIVO> GRADIVO { get; set; }
    public required DbSet<FUNKCIJA_ZAPOSLENEGA> FUNKCIJA_ZAPOSLENEGA { get; set; }
    public required DbSet<dela_v> dela_v { get; set; }
     public required DbSet<CLAN> CLAN { get; set; }
    public required DbSet<AVTOR> AVTOR { get; set; }
}
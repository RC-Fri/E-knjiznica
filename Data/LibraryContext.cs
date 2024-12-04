using E_knjiznica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace E_knjiznica.Data;
public class LibraryContext : IdentityDbContext<ApplicationUser>
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {

    }
    
    public DbSet<Material> Materials { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Subsidiary> Subsidiaries { get; set; }
    public DbSet<Loan> Loans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Author>().ToTable("Author");
        modelBuilder.Entity<Material>().ToTable("Material");
        modelBuilder.Entity<Member>().ToTable("Member");
        modelBuilder.Entity<Subsidiary>().ToTable("Subsidiary");
        modelBuilder.Entity<Loan>().ToTable("Loan");
    }
}
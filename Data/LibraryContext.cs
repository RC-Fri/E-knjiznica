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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Material>().ToTable("Material");
        modelBuilder.Entity<Member>().ToTable("Member");
    }
}

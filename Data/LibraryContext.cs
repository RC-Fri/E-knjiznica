using E_knjiznica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace E_knjiznica.Data
{
    public class LibraryContext : IdentityDbContext<ApplicationUser>
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NASLOV>().HasKey(n => new { n.Postna_stevilka, n.Ulica, n.Hisna_stevilka });
            modelBuilder.Entity<NASLOV>().HasOne(n => n.Posta).WithMany(p => p.Naslovi).HasForeignKey(n => n.Postna_stevilka);
            modelBuilder.Entity<NASLOV>().HasOne(n => n.Clan).WithMany(c => c.Naslovi).HasForeignKey(n => n.ID_osebe);

            modelBuilder.Entity<je_kreiral>().HasKey(j => new { j.ID_zaposlen, j.ID_obdelave });
            modelBuilder.Entity<je_kreiral>().HasOne(j => j.zaposlen).WithMany(z => z.Je_Kreiral).HasForeignKey(j => j.ID_zaposlen);
            modelBuilder.Entity<je_kreiral>().HasOne(j => j.Obdelava).WithMany(o => o.Je_Kreiral).HasForeignKey(j => j.ID_obdelave);

            modelBuilder.Entity<OBDELAVA_GRADIV>().HasKey(o => new { o.ID_obdelave, o.ID_gradiva });
            modelBuilder.Entity<OBDELAVA_GRADIV>().HasOne(o => o.Obdelava).WithMany(o => o.Obdelava_Gradiv).HasForeignKey(o => o.ID_obdelave);
            modelBuilder.Entity<OBDELAVA_GRADIV>().HasOne(o => o.Gradivo).WithMany(g => g.Obdelava_Gradiv).HasForeignKey(o => o.ID_gradiva);

            modelBuilder.Entity<dela_v>().HasKey(d => new { d.ID_zaposlen, d.ID_podruznice });
            modelBuilder.Entity<dela_v>().HasOne(d => d.Zaposlen).WithMany(z => z.Dela_V).HasForeignKey(d => d.ID_zaposlen);
            modelBuilder.Entity<dela_v>().HasOne(d => d.Podruznica).WithMany(p => p.Dela_V).HasForeignKey(d => d.ID_podruznice);

            modelBuilder.Entity<CLAN>().HasOne(c => c.Oseba).WithOne(o => o.Clan).HasForeignKey<CLAN>(c => c.ID_osebe);
            modelBuilder.Entity<CLAN>().HasOne(c => c.Kategorija).WithMany(k => k.Clan).HasForeignKey(c => c.ID_kategorija_clana);
        }
    }
}
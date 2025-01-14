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

            // NASLOV primary key and relationships
            modelBuilder.Entity<NASLOV>().HasKey(n => new { n.Postna_stevilka, n.Ulica, n.Hisna_stevilka });
            modelBuilder.Entity<NASLOV>()
                .HasOne(n => n.Posta)
                .WithMany(p => p.Naslovi)
                .HasForeignKey(n => n.Postna_stevilka);
            modelBuilder.Entity<NASLOV>()
                .HasOne(n => n.Clan)
                .WithMany(c => c.Naslovi)
                .HasForeignKey(n => n.ID_osebe);

            // je_kreiral primary key and relationships
            modelBuilder.Entity<je_kreiral>().HasKey(j => new { j.ID_osebe, j.Inventarna_stevilka });
            modelBuilder.Entity<je_kreiral>()
                .HasOne(j => j.Avtor)
                .WithMany()
                .HasForeignKey(j => j.ID_osebe);

            modelBuilder.Entity<je_kreiral>()
                .HasOne(j => j.Gradivo)
                .WithMany()
                .HasForeignKey(j => j.Inventarna_stevilka);

            // OBDELAVA_GRADIV primary key and relationships
            modelBuilder.Entity<OBDELAVA_GRADIV>().HasKey(o => o.ID_obdelave);

            modelBuilder.Entity<OBDELAVA_GRADIV>()
                .HasOne(o => o.TipObdelave)
                .WithMany(t => t.Obdelave)
                .HasForeignKey(o => o.ID_tip_obdelave);

            modelBuilder.Entity<OBDELAVA_GRADIV>()
                .HasOne(o => o.Gradivo)
                .WithMany(g => g.Obdelave)
                .HasForeignKey(o => o.Inventarna_stevilka);

            modelBuilder.Entity<OBDELAVA_GRADIV>()
                .HasOne(o => o.Zaposlen)
                .WithMany(z => z.Obdelave)
                .HasForeignKey(o => o.ID_zaposlen);

            modelBuilder.Entity<OBDELAVA_GRADIV>()
                .HasOne(o => o.Clan)
                .WithMany(c => c.Obdelave)
                .HasForeignKey(o => o.ID_clan);


            // dela_v primary key and relationships
            modelBuilder.Entity<dela_v>().HasKey(d => new { d.ID_zaposlen, d.ID_podruznice });
            modelBuilder.Entity<dela_v>()
                .HasOne(d => d.Zaposlen)
                .WithMany(z => z.Dela_V)
                .HasForeignKey(d => d.ID_zaposlen);
            modelBuilder.Entity<dela_v>()
                .HasOne(d => d.Podruznica)
                .WithMany(p => p.Zaposleni)
                .HasForeignKey(d => d.ID_podruznice);

            // CLAN relationships
            modelBuilder.Entity<CLAN>()
                .HasOne(c => c.Oseba)
                .WithOne(o => o.Clan)
                .HasForeignKey<CLAN>(c => c.ID_osebe);
            modelBuilder.Entity<CLAN>()
                .HasOne(c => c.KategorijaClana)
                .WithMany(k => k.Clani)
                .HasForeignKey(c => c.ID_kategorija_clana);
        }
    }
}
using E_knjiznica.Models;
using System;
using System.Linq;


namespace E_knjiznica.Data
{
    public class DbInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            context.Database.EnsureCreated();

            // Check if the database is already seeded
            if (context.TIP_GRADIVA.Any())
            {
                return; // DB has been seeded

                var tipObdelave = new TIP_OBDELAVE[]
                {
                    new TIP_OBDELAVE { ID_tip_obdelave = 1, Naziv = "Binding", Opis = "Book binding process" },
                    new TIP_OBDELAVE { ID_tip_obdelave = 2, Naziv = "Repair", Opis = "Repairing damaged materials" }
                };
                foreach (var t in tipObdelave)
                {
                    context.TIP_OBDELAVE.Add(t);
                }
                context.SaveChanges();

                var tipPodruznice = new TIP_PODRUZNICE[]
                {
                    new TIP_PODRUZNICE { ID_tip_podruznice = 1, Naziv = "Main", Opis = "Main branch" },
                    new TIP_PODRUZNICE { ID_tip_podruznice = 2, Naziv = "Sub", Opis = "Sub branch" }
                };
                foreach (var t in tipPodruznice)
                {
                    context.TIP_PODRUZNICE.Add(t);
                }
                context.SaveChanges();

                var statusGradiva = new STATUS_GRADIVA[]
                {
                    new STATUS_GRADIVA { ID_status = 1, Naziv = "Available", Opis = "Item is available" },
                    new STATUS_GRADIVA { ID_status = 2, Naziv = "Checked Out", Opis = "Item is checked out" }
                };
                foreach (var s in statusGradiva)
                {
                    context.STATUS_GRADIVA.Add(s);
                }
                context.SaveChanges();

                var zalozba = new ZALOZBA[]
                {
                    new ZALOZBA { ID_zalozba = 1, Naziv = "Publisher A", Opis = "Description A" },
                    new ZALOZBA { ID_zalozba = 2, Naziv = "Publisher B", Opis = "Description B" }
                };
                foreach (var z in zalozba)
                {
                    context.ZALOZBA.Add(z);
                }
                context.SaveChanges();

                var kategorijaClana = new KATEGORIJA_CLANA[]
                {
                    new KATEGORIJA_CLANA { ID_kategorija_clana = 1, Naziv = "Regular", Opis = "Regular member", Clanarina = 10.00M },
                    new KATEGORIJA_CLANA { ID_kategorija_clana = 2, Naziv = "Premium", Opis = "Premium member", Clanarina = 20.00M }
                };
                foreach (var k in kategorijaClana)
                {
                    context.KATEGORIJA_CLANA.Add(k);
                }
                context.SaveChanges();

                var posta = new POSTA[]
                {
                    new POSTA { Postna_stevilka = 1000, Kraj = "Ljubljana" },
                    new POSTA { Postna_stevilka = 2000, Kraj = "Maribor" }
                };
                foreach (var p in posta)
                {
                    context.POSTA.Add(p);
                }
                context.SaveChanges();

                var podruznica = new PODRUZNICA[]
                {
                    new PODRUZNICA { ID_podruznice = 1, ID_tip_podruznice = 1, Posta = "Ljubljana" },
                    new PODRUZNICA { ID_podruznice = 2, ID_tip_podruznice = 2, Posta = "Maribor" }
                };
                foreach (var p in podruznica)
                {
                    context.PODRUZNICA.Add(p);
                }
                context.SaveChanges();

                var funkcijaZaposlenega = new FUNKCIJA_ZAPOSLENEGA[]
                {
                    new FUNKCIJA_ZAPOSLENEGA { ID_funkcija = 1, Funkcija = "Manager", Opis_dela = "Oversees operations" },
                    new FUNKCIJA_ZAPOSLENEGA { ID_funkcija = 2, Funkcija = "Librarian", Opis_dela = "Manages books" }
                };
                foreach (var f in funkcijaZaposlenega)
                {
                    context.FUNKCIJA_ZAPOSLENEGA.Add(f);
                }
                context.SaveChanges();

                var oseba = new OSEBA[]
                {
                    new OSEBA { ID_osebe = 1, Ime = "Janez", Priimek = "Novak" },
                    new OSEBA { ID_osebe = 2, Ime = "Maja", Priimek = "Kovač" }
                };
                foreach (var o in oseba)
                {
                    context.OSEBA.Add(o);
                }
                context.SaveChanges();

                var zaposlena = new ZAPOSLEN[]
                {
                    new ZAPOSLEN { ID_osebe = 1, ID_funkcija = 1, Placa = 3000.00M, Uporabnisko_ime = "janez", Geslo = "password123" },
                    new ZAPOSLEN { ID_osebe = 2, ID_funkcija = 2, Placa = 2000.00M, Uporabnisko_ime = "maja", Geslo = "password456" }
                };
                foreach (var z in zaposlena)
                {
                    context.ZAPOSLEN.Add(z);
                }
                context.SaveChanges();

                var avtor = new AVTOR[]
                {
                    new AVTOR { ID_osebe = 1, Pseudonim = "J. Novak", Datum_rojstva = new DateTime(1980, 5, 1) },
                    new AVTOR { ID_osebe = 2, Pseudonim = "M. Kovač", Datum_rojstva = new DateTime(1990, 7, 12) }
                };
                foreach (var a in avtor)
                {
                    context.AVTOR.Add(a);
                }
                context.SaveChanges();

                var gradivo = new GRADIVO[]
                {
                    new GRADIVO { Inventarna_stevilka = 1, ID_tip_gradiva = 1, ID_zalozba = 1, ID_status = 1, ID_podruznice = 1, Naziv = "Book 1", Datum_izdaje = new DateTime(2020, 1, 1) },
                    new GRADIVO { Inventarna_stevilka = 2, ID_tip_gradiva = 2, ID_zalozba = 2, ID_status = 2, ID_podruznice = 2, Naziv = "Book 2", Datum_izdaje = new DateTime(2021, 5, 1) }
                };
                foreach (var g in gradivo)
                {
                    context.GRADIVO.Add(g);
                }
                context.SaveChanges();

                var clan = new CLAN[]
                {
                    new CLAN { ID_osebe = 1, ID_kategorija_clana = 1, GDPR = true, E_posta = "jane@example.com", Informiranje_preko_e_poste = true, Konec_clanstva = new DateTime(2025, 12, 31) },
                    new CLAN { ID_osebe = 2, ID_kategorija_clana = 2, GDPR = true, E_posta = "maja@example.com", Informiranje_preko_e_poste = true, Konec_clanstva = new DateTime(2025, 12, 31) }
                };
                foreach (var c in clan)
                {
                    context.CLAN.Add(c);
                }
                context.SaveChanges();

                var obdelavaGradiv = new OBDELAVA_GRADIV[]
                {
                    new OBDELAVA_GRADIV { ID_obdelave = 1, ID_tip_obdelave = 1, Inventarna_stevilka = 1, ID_zaposlen = 1, ID_clan = 1, Datum_obdelave = new DateTime(2022, 1, 1) },
                    new OBDELAVA_GRADIV { ID_obdelave = 2, ID_tip_obdelave = 2, Inventarna_stevilka = 2, ID_zaposlen = 2, ID_clan = 2, Datum_obdelave = new DateTime(2023, 5, 1) }
                };
                foreach (var o in obdelavaGradiv)
                {
                    context.OBDELAVA_GRADIV.Add(o);
                }
                context.SaveChanges();

                var naslov = new NASLOV[]
                {
                    new NASLOV { Postna_stevilka = 1000, Ulica = "Main St", Hisna_stevilka = "1", ID_osebe = 1 },
                    new NASLOV { Postna_stevilka = 2000, Ulica = "Broadway", Hisna_stevilka = "2", ID_osebe = 2 }
                };
                foreach (var n in naslov)
                {
                    context.NASLOV.Add(n);
                }
                context.SaveChanges();

                var delaV = new dela_v[]
                {
                    new dela_v { ID_osebe = 1, ID_podruznice = 1 },
                    new dela_v { ID_osebe = 2, ID_podruznice = 2 }
                };
                foreach (var d in delaV)
                {
                    context.dela_v.Add(d);
                }
                context.SaveChanges();

                var jeKreiral = new je_kreiral[]
                {
                    new je_kreiral { ID_osebe = 1, Inventarna_stevilka = 1 },
                    new je_kreiral { ID_osebe = 2, Inventarna_stevilka = 2 }
                };
                foreach (var j in jeKreiral)
                {
                    context.je_Kreiral.Add(j);
                }
                context.SaveChanges();

                
            }
        }
    }
}

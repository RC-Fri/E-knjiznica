# E-knjiznica

Avtorja:\
63210045 Rok Cigut\
63230121 Nik Janoš

Splošen opis naloge

Z informacijskim sistemom E-Knjižnica bomo podprli procese na knjižnici. Sistem bo omogočal pregled gradiva knjižnice, opis gradiva, izposojo in rezervacijo gradiva ter pogled nad izposojenimi gradivi od datuma vračila do podaljšanja istega datuma.
Sam informacijski sistem je razdeljen na spetno aplikacijo, spletne storitve, podatkono bazo in android aplikacijo. Spletna aplikacija in android aplikacija bosta dovolili uporabnikim dovolia dostop do IS, medtem ko bosta spletna storitev in podatkovna baza usposabljala sam sistem.

Spletna stran bo delovala kot portal za člane , zaposlene in goste, medtem ko bo aplikacija samo delovala za uporabnike. Tak sistem bo dovolil da se aplikacija prilagodi članom, saj je predivideno da jo bojo le ti uporabljali. Gostje, oziroma obiskovalci spletne strani, so podani pogled ter iskanje gradiva, ki se nahaja v knjižnici oziroma knjižnicah. Zaposleni imajo seveda večje pravice v sistemu, odvisno od avtorizacije. Te bodo lahko imeli možnosti od dodajanja gradiv, odstranjevanja gradiv, spremembe statusa gradiv, dodajanje članov, obdelovanje zamud in tako dalje.

Za uspešno delovanje strani in aplikacije seveda rabimo podatkovno bazo, katera jih lahko podpira. V podatkovni bazi so predivdene nasledne entitete: Gradivo, Izvod gradiva, Avtor, Član, Izposoja, Rezervacija, Podaljšanje, Zaposleni v knjižnici. Poleg tega tudi rabi procedure za lažji pregled in omogočiti delovanje katerih funkcij – naprimer vnos in zahteve podatkov glede strani in aplikacije, posodobljevanje baze,...

Zaslonske slike grafičnega vmesnika vaše mobilne aplikacije in spletne aplikacije
Spletna aplikacija
![slika](https://github.com/user-attachments/assets/e7e95cd9-a5fd-475a-8c4c-9e83d448f2b3)
Slika 1: Prijava

![slika](https://github.com/user-attachments/assets/918dc999-3acb-453b-b745-418d85bf68d0)
Slika 2: Gradiva v knjižnici

Mobilna aplikacija
![slika](https://github.com/user-attachments/assets/d4ce6cad-62e7-423b-9785-6247ae5790f8)
Slika 3: Prijava

![slika](https://github.com/user-attachments/assets/18a44cea-c5c6-4a0a-83e3-694794a4f556)
Slika 4: Pregled

![slika](https://github.com/user-attachments/assets/c302a529-10e8-4f72-b2d3-1401fce3d6d4)
Slika 5: Iskanje

Kratek opis delovanja celotnega sistema

Temelno delovanje je uporaba spletne strani za prijavo ali registracijo članov. Vsi obiskovalci imajo dostop do gradiva knjižnice, člani pa lahko pogledajo svoje gradivo. Zaposleni lahko vpisujejo novo gradivo in obdelujejo z gradivom. Delovanje omogoča C# in .NET. Z pomočjo Modelov in podatkovne baze je omogočen preprost in logičen dostop do podatkov nad katerim uporabniki upravljajo. API obstaja za mogočo integracijo z drugimi aplikacijami s pomočjo preproste dokumentacije z Swagger. Za mobilno delovanje je na podatkovno bazo integrirana mobilna aplikacija E-knjiznica-mobilna-aplikacija.

Opis nalog, ki jih je izvedel vsak izmed študentov:

Rok Cigut: Mobilna aplikacija, podatkovna baza, API in Modeli v spletni aplikaciji.

Nik Janoš: Azure Cloud, Models, generiranje views in controllerjev, css/html, pomoč pri debug-anju. 

Slika podatkovnega modela:
![slika](https://github.com/user-attachments/assets/b7f8e847-d757-4795-a95f-270776944f27)
Čeprav se poveza med Oseba in AspNetUsers ne vidi, obstaja. Ob kreaciji AspNetUser-ja se v Oseba vnesejo zahtevane vrednosti z pomočjo prožilcev.

using OsobyApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace OsobyApi.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<OsobyApi.Data.OsobyApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.OsobyApiContext context)
        {
            context.Staty.AddOrUpdate(x => x.Nazev,
                new Stat { Nazev = "Česká republika" },
                new Stat { Nazev = "Slovenská republika" },
                new Stat { Nazev = "Rakouská republika" },
                new Stat { Nazev = "Spolková republika Německo" },
                new Stat { Nazev = "Polská republika" }
                );

            context.TypyKontaktu.AddOrUpdate(
                new TypKontaktu { Typ = "Telefon" },
                new TypKontaktu { Typ = "Email" }
                );

            context.Narodnosti.AddOrUpdate(
                new Narodnost { Nazev = "česká" },
                new Narodnost { Nazev = "slovenská" },
                new Narodnost { Nazev = "rakouská" },
                new Narodnost { Nazev = "německá" },
                new Narodnost { Nazev = "polská" }
                );

#if DEBUG
            context.Osoby.AddOrUpdate(x => x.Id,
                new Osoba()
                {
                    Id = 0,
                    Jmeno = "Jan",
                    Prijmeni = "Novák",
                    RodneCislo = "8501011234",
                    DatumNarozeni = DateTime.Parse("1985-01-01"),
                    Narodnost = "Česká",
                    Bydliste = new Bydliste()
                    {
                        Ulice = "Hlavní 123",
                        Mesto = "Praha",
                        PSC = "11000",
                        Stat = "Česká republika"
                    },
                    Kontakty = new List<Kontakt>()
                    {
                    new Kontakt()
                    {
                        TypKontaktu = "Telefon",
                        Hodnota = "+420123456789",
                        OsobaId = 0
                    },
                    new Kontakt()
                    {
                        TypKontaktu = "Email",
                        Hodnota = "jan.novak@example.com",
                        OsobaId = 0
                    }
                    }
                });
#endif
        }
    }
}

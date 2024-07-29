using OsobyApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsobyApiTests
{
    internal class TestOsobyApiContext : IOsobyApiContext
    {
        public TestOsobyApiContext()
        {
            Osoby = new TestOsobaDbSet();
            Bydliste = new TestBydlisteDbSet();
            Staty = new TestStatDbSet();
            Kontakty = new TestKontaktDbSet();
            TypyKontaktu = new TestTypKontaktuDbSet();
            Narodnosti = new TestNarodnostDbSet();
        }

        public DbSet<Osoba> Osoby { get; set; }

        public DbSet<Bydliste> Bydliste { get; set; }

        public DbSet<Stat> Staty { get; set; }

        public DbSet<Kontakt> Kontakty { get; set; }

        public DbSet<TypKontaktu> TypyKontaktu { get; set; }

        public DbSet<Narodnost> Narodnosti { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public Task<int> SaveChangesAsync()
        {
            return Task.FromResult(0);
        }

        public void MarkAsModified(Osoba item) { }
        public void MarkAsModified(Bydliste item) { }
        public void MarkAsModified(Stat item) { }
        public void MarkAsModified(Kontakt item) { }
        public void MarkAsModified(TypKontaktu item) { }
        public void MarkAsModified(Narodnost item) { }

        public void Dispose() { }
    }
}

using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace OsobyApi.Models
{
    public interface IOsobyApiContext : IDisposable
    {
        DbSet<Osoba> Osoby { get; }
        DbSet<Bydliste> Bydliste { get; set; }

        DbSet<Stat> Staty { get; set; }

        DbSet<Kontakt> Kontakty { get; set; }

        DbSet<TypKontaktu> TypyKontaktu { get; set; }

        DbSet<Narodnost> Narodnosti { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        void MarkAsModified(Osoba osoba);
    }
}
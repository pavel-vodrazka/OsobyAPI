using OsobyApi.Models;
using Serilog;
using System.Data.Entity;

namespace OsobyApi.Data
{
    public class OsobyApiContext : DbContext, IOsobyApiContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public OsobyApiContext() : base("name=OsobyApiContext")
        {
            Database.Log = s => Log.Debug(s);
        }

        public DbSet<Osoba> Osoby { get; set; }

        public DbSet<Bydliste> Bydliste { get; set; }

        public DbSet<Stat> Staty { get; set; }

        public DbSet<Kontakt> Kontakty { get; set; }

        public DbSet<TypKontaktu> TypyKontaktu { get; set; }

        public DbSet<Narodnost> Narodnosti { get; set; }

        public void MarkAsModified(Osoba osoba)
        {
            Entry(osoba).State = EntityState.Modified;
        }
    }
}

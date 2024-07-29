using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OsobyApi.Models
{
    [Table("Kontakty")]
    public class Kontakt
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, ForeignKey("TypKontaktuNav"), MaxLength(50)]
        public string TypKontaktu { get; set; }
        [ForeignKey("TypKontaktu")]
        public virtual TypKontaktu TypKontaktuNav { get; set; }
        [Required, MaxLength(100)]
        public string Hodnota { get; set; }
        [Required, ForeignKey("Osoba")]
        public int OsobaId { get; set; }
        [ForeignKey("Osoba")]
        public virtual Osoba Osoba { get; set; }
    }
}
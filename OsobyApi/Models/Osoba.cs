using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OsobyApi.Models
{
    [Table("Osoby")]
    public class Osoba
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Jmeno { get; set; }
        [Required, MaxLength(50)]
        public string Prijmeni { get; set; }
        [MaxLength(50)]
        public string RodnePrijmeni { get; set; }
        [Required, MinLength(9), MaxLength(10), RegularExpression(@"[0-9]{2}[01235678][0-9][0-3][0-9][0-9]{3,4}")] // velice jednoduchý, negarantuje správnost
        public string RodneCislo { get; set; }
        [Required]
        public DateTime DatumNarozeni { get; set; }
        [Required, ForeignKey("NarodnostNav"), Column(Order = 1)]
        public string Narodnost { get; set; }
        [ForeignKey("Id, Nazev")]
        public virtual Narodnost NarodnostNav { get; set; }
        public int BydlisteFK { get; set; }
        [ForeignKey("BydlisteFK")]
        public virtual Bydliste Bydliste { get; set; }
        [Required, InverseProperty("Osoba")]
        public ICollection<Kontakt> Kontakty { get; set; }
    }
}
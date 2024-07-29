using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OsobyApi.Models
{
    public class OsobaDto
    {
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
        [Required]
        public string Narodnost { get; set; }
        [Required]
        public BydlisteDto Bydliste { get; set; }
        [Required]
        public ICollection<KontaktDto> Kontakty { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace OsobyApi.Models
{
    public class KontaktDto
    {
        public int Id { get; set; }
        [Required]
        public string TypKontaktu { get; set; }
        [Required, MaxLength(100)]
        public string Hodnota { get; set; }
        public int OsobaID { get; set; }
    }
}
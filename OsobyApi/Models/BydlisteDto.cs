using System.ComponentModel.DataAnnotations;

namespace OsobyApi.Models
{
    public class BydlisteDto
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Ulice { get; set; }
        [Required, MaxLength(50)]
        public string Mesto { get; set; }
        [Required, MaxLength(10)]
        public string PSC {  get; set; }
        [Required]
        public string Stat { get; set; }
    }
}
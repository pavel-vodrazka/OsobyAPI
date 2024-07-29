using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OsobyApi.Models
{
    [Table("Bydliste")]
    public class Bydliste
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Ulice { get; set; }
        [Required, MaxLength(50)]
        public string Mesto { get; set; }
        [Required, MaxLength(10)]
        public string PSC { get; set; }
        [Required, ForeignKey("StatNav"), MaxLength(50)]
        public string Stat {  get; set; }
        [ForeignKey("Stat")]
        public virtual Stat StatNav { get; set; }
    }
}
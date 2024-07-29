using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OsobyApi.Models
{
    [Table("Staty")]
    public class Stat
    {
        [Index(IsUnique = true), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key, MaxLength(50)]
        public string Nazev { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OsobyApi.Models
{
    [Table("Narodnosti")]
    public class Narodnost
    {
        [Index(IsUnique = true), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key, MaxLength(50)]
        public string Nazev { get; set; }
    }
}
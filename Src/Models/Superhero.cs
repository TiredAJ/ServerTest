using System.ComponentModel.DataAnnotations.Schema;

namespace ServerTest.Models
{
    [Table("superheroes")]
    public class Superhero
    {
        [Column("id")]
        public required int ID { get; set; }
        [Column("name")]
        public required string Name { get; set; } = string.Empty;
        [Column("description")]
        public string? Description { get; set; } = string.Empty;
        [Column("place")]
        public string Place { get; set; } = string.Empty;
    }
}
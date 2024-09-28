namespace ServerTest.Models
{
    public class Superhero
    {
        public required int ID { get; set; }
        public required string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
    }
}
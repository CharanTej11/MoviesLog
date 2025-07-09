namespace MoviesLog.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public string? Biography { get; set; }

        public ICollection<Movie>? Movies { get; set; }
    }
}

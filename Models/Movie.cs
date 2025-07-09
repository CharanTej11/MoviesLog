namespace MoviesLog.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Synopsis { get; set; }
        public DateTime ReleaseDate { get; set; }

        // Foreign Key
        public int DirectorId { get; set; }
        public Director? Director { get; set; }

        public ICollection<Review>? Reviews { get; set; }
    }
}

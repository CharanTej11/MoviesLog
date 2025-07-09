namespace MoviesLog.DTOs
{
    // For creating a new movie (no Id)
    public class MovieCreateDto
    {
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Synopsis { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int DirectorId { get; set; }
    }

    // For returning a movie (includes Id)
    public class MovieDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Synopsis { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int DirectorId { get; set; }
    }
}

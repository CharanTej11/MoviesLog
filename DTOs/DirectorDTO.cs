namespace MoviesLog.DTOs
{
    // For creating a director — no Id
    public class DirectorCreateDto
    {
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public string? Biography { get; set; }
    }

    // For reading/updating a director — includes Id
    public class DirectorDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public string? Biography { get; set; }
    }
}

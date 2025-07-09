namespace MoviesLog.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string? ReviewerName { get; set; }
        public int Rating { get; set; }  // 1 to 5
        public string? Comment { get; set; }
        public DateTime PostedAt { get; set; }

        // Foreign Key
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}

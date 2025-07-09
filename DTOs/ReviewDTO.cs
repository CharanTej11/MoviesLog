namespace MoviesLog.DTOs
{
    // =============================
    // REVIEW DTOs
    // =============================

    // For creating a review (no Id)
    public class ReviewCreateDto
    {
        public string? ReviewerName { get; set; }
        public int Rating { get; set; }  // e.g., 1 to 5
        public string? Comment { get; set; }
        public DateTime PostedAt { get; set; }
        public int MovieId { get; set; }
    }

    // For returning a review (includes Id)
    public class ReviewDto
    {
        public int Id { get; set; }
        public string? ReviewerName { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime PostedAt { get; set; }
        public int MovieId { get; set; }
    }
}

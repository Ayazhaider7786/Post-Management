namespace Post_Management.Models.Domain
{
    public class Comment
    {
        public Guid Id { get; set; } // Unique ID for each comment
        public Guid PostId { get; set; } // Associated post's ID
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

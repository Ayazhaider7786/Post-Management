namespace Post_Management.Models.Domain
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime Timestamp { get; set; }
        // Property for storing image data as a byte array
        public byte[] ImageData { get; set; }
        public string ImageFileName { get; set; }

    }
}

namespace Post_Management.Models
{
    public class BlogPostModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        // Property for storing image data as a byte array
        public IFormFile ImageData { get; set; }
    }
}

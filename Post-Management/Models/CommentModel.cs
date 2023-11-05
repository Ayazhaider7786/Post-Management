namespace Post_Management.Models
{
    public class CommentModel
    {
        public Guid PostId { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }

    }
}

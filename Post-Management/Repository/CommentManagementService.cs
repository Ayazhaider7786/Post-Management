using Microsoft.EntityFrameworkCore;
using Post_Management.Data;
using Post_Management.Models;
using Post_Management.Models.Domain;

namespace Post_Management.Repository
{
    public class CommentManagementService
    {
        private readonly PostManagementDbContext _context;

        public CommentManagementService (PostManagementDbContext context ) {
            _context = context;
        }
        public Comment CreateComment(CommentModel recComment)
        {
            var _comment = new Comment
            {
                Id = new Guid(),
                PostId = recComment.PostId,
                Text = recComment.Text,
                Author = recComment.Author,
                Timestamp = DateTime.UtcNow
            };

            _context.myComment.Add(_comment);
            _context.SaveChanges();

            return _comment;
        }
        public IEnumerable<Comment> GetAllComments()
        {
            var _cmt = _context.myComment.ToList();
            return _cmt;
        }
        public Comment GetCommentsById(Guid id)
        {
            var _cmt = _context.myComment.FirstOrDefault(post => post.Id == id);
            return _cmt;
        }
        public bool Update(Guid id, CommentModel post)
        {
            try
            {
                var existingPost = GetCommentsById(id);
                if (existingPost == null)
                    return false;
   
                existingPost.Text = post.Text;
                existingPost.Author = post.Author;

                _context.Entry(existingPost).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool DeleteComment(Guid commentId)
        {
            var commentToDelete = GetCommentsById(commentId);

            if (commentToDelete != null)
            {
                _context.myComment.Remove(commentToDelete);
                _context.SaveChanges();
                return true;
            }

            // Handle the case where the comment with the given ID doesn't exist.
            return false;
        }
    }
}

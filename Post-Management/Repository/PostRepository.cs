using Microsoft.EntityFrameworkCore;
using Post_Management.Data;
using Post_Management.Models;
using Post_Management.Models.Domain;

namespace Post_Management.Repository
{
    public class PostRepository
    {

        private readonly PostManagementDbContext _context;

        public PostRepository(PostManagementDbContext context)
        {
            _context = context;
        }
        public BlogPost Create(BlogPostModel post)
        {
            try {

                BlogPost _blogpost = new BlogPost();

                _blogpost.Id = new Guid();
                _blogpost.Title =post.Title; 
                _blogpost.Author = post.Author;
                _blogpost.Content = post.Content;
                _blogpost.Timestamp = DateTime.UtcNow;


                _context.myBlogPost.Add(_blogpost);
                _context.SaveChanges();

                return _blogpost;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public IEnumerable<BlogPost> GetAll()
        {
            try {
                return _context.myBlogPost.ToList();
                // return _posts;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public BlogPost GetById(Guid id)
        {
            try {
                return _context.myBlogPost.FirstOrDefault(post => post.Id == id);
                // return _posts.FirstOrDefault(post => post.Id == id);       
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(Guid id, BlogPostModel post)
        {
            try {
                var existingPost = GetById(id);
                if (existingPost == null)
                    return false;

                existingPost.Title = post.Title;
                existingPost.Content = post.Content;
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
        public bool Delete(Guid id)
        {
            try {

                var post = GetById(id);
                if (post == null)
                    return false;

                _context.myBlogPost.Remove(post);
                _context.SaveChanges();
                return true;

                // _posts.Remove(post);
           
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
    }
}

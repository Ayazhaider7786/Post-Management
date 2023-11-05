using AspnetIdentityRoleBasedTutorial.Services;
using Microsoft.EntityFrameworkCore;
using Post_Management.Data;
using Post_Management.Models;
using Post_Management.Models.Domain;

namespace Post_Management.Repository
{
    public class PostRepository
    {

        private readonly PostManagementDbContext _context;
        private readonly IFileService _fileService;

        public PostRepository(PostManagementDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }
        public BlogPost Create(BlogPostModel post)
        {
            try {

                var imageResult = _fileService.SaveImage(post.ImageData); // Assuming imageFile is the uploaded image
                if (imageResult.Item1 == 1)
                {
                    BlogPost _blogpost = new BlogPost
                    {
                        Id = new Guid(),
                        Title = post.Title,
                        Author = post.Author,
                        Content = post.Content,
                        Timestamp = DateTime.UtcNow,
                        ImageData = imageResult.Item2,
                        ImageFileName= imageResult.Item3
                    };

                    _context.myBlogPost.Add(_blogpost);
                    _context.SaveChanges();

                    return _blogpost;
                }
                else
                {
                    // Handle the case where image upload failed
                    return null;
                }

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

                var imageResult = _fileService.SaveImage(post.ImageData);

                var existingPost = GetById(id);
                if (existingPost == null)
                    return false;

                _fileService.DeleteImage(existingPost.ImageFileName);
                existingPost.Title = post.Title;
                existingPost.Content = post.Content;
                existingPost.Author = post.Author;

                existingPost.ImageData = imageResult.Item2;
                existingPost.ImageFileName = imageResult.Item3;

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

                _fileService.DeleteImage(post.ImageFileName);
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

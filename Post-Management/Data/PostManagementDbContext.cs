using Microsoft.EntityFrameworkCore;
using Post_Management.Models.Domain;

namespace Post_Management.Data
{
    public class PostManagementDbContext : DbContext
    {
        public PostManagementDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BlogPost> myBlogPost { get; set; }
        public DbSet<Comment> myComment { get; set; }

    }
}

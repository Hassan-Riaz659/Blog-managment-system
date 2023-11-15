using Blog_managment_system.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog_managment_system.Web.Data
{
    public class BlogManSysDbContext : DbContext
    {

        public BlogManSysDbContext(DbContextOptions<BlogManSysDbContext> options) : base(options) 
        { 
            
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogPostLike> BlogPostLike { get; set; }
        public DbSet<BlogPostComment> BlogPostComment { get; set; }
    }
}

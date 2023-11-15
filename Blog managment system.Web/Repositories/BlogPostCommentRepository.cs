using Blog_managment_system.Web.Data;
using Blog_managment_system.Web.Models.Domain;

namespace Blog_managment_system.Web.Repositories
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly BlogManSysDbContext blogManSysDbContext;
        private BlogPostComment blogPostComment;

        public BlogPostCommentRepository(BlogManSysDbContext blogManSysDbContext)
        {
            this.blogManSysDbContext = blogManSysDbContext;
        }
        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostCommnent)
        {
            await blogManSysDbContext.BlogPostComment.AddAsync(blogPostComment);
            await blogManSysDbContext.SaveChangesAsync();
            return blogPostComment;
        }
    }
}

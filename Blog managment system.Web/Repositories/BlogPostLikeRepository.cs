using Blog_managment_system.Web.Data;
using Blog_managment_system.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog_managment_system.Web.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BlogManSysDbContext blogManSysDbContext;

        public BlogPostLikeRepository(BlogManSysDbContext blogManSysDbContext)
        {
                this.blogManSysDbContext = blogManSysDbContext;
        }
        
        public async Task AddLikeForBlog(Guid blogPostId, Guid userId) 
        {
            var like = new BlogPostLike
            {
                Id = Guid.NewGuid(),
                BlogPostId = blogPostId,
                UserId = userId
            };
          await  blogManSysDbContext.BlogPostLike.AddAsync(like);
          await blogManSysDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            return await blogManSysDbContext.BlogPostLike.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }

        public async Task<int> GetTotalLikesForBlog(Guid blogPostId) 
        {
            return await blogManSysDbContext.BlogPostLike.CountAsync(x => x.BlogPostId == blogPostId);
        
        }

    }
}

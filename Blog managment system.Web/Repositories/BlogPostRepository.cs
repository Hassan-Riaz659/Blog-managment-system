using Blog_managment_system.Web.Data;
using Blog_managment_system.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog_managment_system.Web.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogManSysDbContext blogManSys;

        public BlogPostRepository(BlogManSysDbContext blogManSys)
        {
            this.blogManSys = blogManSys;
        }
        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await blogManSys.BlogPosts.AddAsync(blogPost);
            await blogManSys.SaveChangesAsync();
            return blogPost;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingBlog = await blogManSys.BlogPosts.FindAsync(id);
            if( existingBlog != null) 
            {
                blogManSys.BlogPosts.Remove(existingBlog);
                await blogManSys.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
           return await blogManSys.BlogPosts.Include(nameof(BlogPost.Tags)).ToListAsync();
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync(string tagName) 
        {
            return await (blogManSys.BlogPosts.Include(nameof(BlogPost.Tags))
                .Where(x => x.Tags.Any(x => x.Name == tagName)))
                .ToListAsync();
        }

        public async Task<BlogPost> GetAsync(Guid id)
        {
            return await blogManSys.BlogPosts.Include(nameof(BlogPost.Tags)).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost> GetAsync(string urlHandle)
        {
            return await blogManSys.BlogPosts.Include(nameof(BlogPost.Tags)).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
            var existingBlogPost = await blogManSys.BlogPosts.Include(nameof(BlogPost.Tags)).FirstOrDefaultAsync(x => x.Id == blogPost.Id); ;
            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = blogPost.Heading;
                existingBlogPost.PageTitle = blogPost.PageTitle;
                existingBlogPost.Content = blogPost.Content;
                existingBlogPost.Shortdescription = blogPost.Shortdescription;
                existingBlogPost.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlogPost.UrlHandle = blogPost.UrlHandle;
                existingBlogPost.PublishedDate = blogPost.PublishedDate;
                existingBlogPost.Author = blogPost.Author;
                existingBlogPost.Visible = blogPost.Visible;

                //Delete the exiosting tags and new tags
                if (blogPost.Tags != null && blogPost.Tags.Any()) 
                {
                    blogManSys.Tags.RemoveRange(existingBlogPost.Tags);

                    //add new tags
                    blogPost.Tags.ToList().ForEach(x=> x.BlogPostId = existingBlogPost.Id);
                    await blogManSys.Tags.AddRangeAsync(blogPost.Tags);
                }

            }

            await blogManSys.SaveChangesAsync();
            return existingBlogPost;
        }
    }
}

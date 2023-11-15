using Blog_managment_system.Web.Data;
using Blog_managment_system.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog_managment_system.Web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private BlogManSysDbContext blogManSys;

        public TagRepository(BlogManSysDbContext blogManSys)
        {
            this.blogManSys = blogManSys;
        }
        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            var tags = await blogManSys.Tags.ToListAsync();
            return tags.DistinctBy(x => x.Name.ToLower());
        }
    }
}

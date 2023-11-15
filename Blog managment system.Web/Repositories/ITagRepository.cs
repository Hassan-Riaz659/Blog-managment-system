using Blog_managment_system.Web.Models.Domain;

namespace Blog_managment_system.Web.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync(); 
        
    }
}

using Microsoft.AspNetCore.Identity;

namespace Blog_managment_system.Web.Repositories
{
    public interface IUserRepository
    {

       Task<IEnumerable<IdentityUser>> GetAll();

    }
}

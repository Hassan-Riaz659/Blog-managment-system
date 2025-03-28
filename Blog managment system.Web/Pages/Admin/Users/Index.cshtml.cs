using Blog_managment_system.Web.Models.ViewModels;
using Blog_managment_system.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog_managment_system.Web.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository userRepository;
        public List<User> Users { get; set; }
        public IndexModel(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<IActionResult> OnGet()
        {
            var users = await userRepository.GetAll();


            Users = new List<User>();
            foreach (var user in users) 
            {
                Users.Add(new Models.ViewModels.User()
                {
                   Id = Guid.Parse(user.Id),
                   username = user.UserName,
                   Email = user.Email
                });
            }

            return Page();

        }
    }
}

using Blog_managment_system.Web.Data;
using Blog_managment_system.Web.Models.Domain;
using Blog_managment_system.Web.Models.ViewModels;
using Blog_managment_system.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Blog_managment_system.Web.Pages.Admin.Blogs
{
    [Authorize(Roles = "Admin")]
    public class ListModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        public List<BlogPost> BlogPosts { get; set; }

        public ListModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;

        }
        public async Task OnGet()
        {
            var notificationJson = TempData["Notification"];
            if (notificationJson != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notificationJson.ToString());
            }


            BlogPosts = (await blogPostRepository.GetAllAsync())?.ToList();
        }
    }
}

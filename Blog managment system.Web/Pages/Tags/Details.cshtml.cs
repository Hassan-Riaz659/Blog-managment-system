using Blog_managment_system.Web.Models.Domain;
using Blog_managment_system.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog_managment_system.Web.Pages.Tags
{
    public class DetailsModel : PageModel
    {
        private IBlogPostRepository blogPostRepository;
        public List<BlogPost> Blogs{ get; set; }

        public DetailsModel(IBlogPostRepository blogPostRepository) 
        {
            this.blogPostRepository = blogPostRepository;
        }
        public async Task<IActionResult> OnGet(string tagName)
        {
           Blogs = (await blogPostRepository.GetAllAsync(tagName)).ToList();
           return Page();
        }
    }
}

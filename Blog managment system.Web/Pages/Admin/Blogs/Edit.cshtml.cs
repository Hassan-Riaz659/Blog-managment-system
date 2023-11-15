using Blog_managment_system.Web.Data;
using Blog_managment_system.Web.Models.Domain;
using Blog_managment_system.Web.Models.ViewModels;
using Blog_managment_system.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Blog_managment_system.Web.Enums;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace Blog_managment_system.Web.Pages.Admin.Blogs
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        [BindProperty]
        public string Tags {  get; set; }
        public EditModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task OnGet(Guid Id)
        {
           BlogPost = await blogPostRepository.GetAsync(Id);
            if (BlogPost != null && BlogPost.Tags !=null) 
            {
                Tags = string.Join(',', BlogPost.Tags.Select(x => x.Name));
            }

        }
        public async Task<IActionResult> OnPostEdit() 
        {
            try
            {
                BlogPost.Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag() { Name = x.Trim() }));
                await blogPostRepository.UpdateAsync(BlogPost);

                ViewData["Notification"] = new Notification
                {
                    Message = "Record updated succssfully",
                    Type = Enums.NotificationType.Success,
                };
            }
            catch (Exception ex)
            {
                ViewData["Notification"] = new Notification
                {
                    Type = Enums.NotificationType.Error,
                    Message = "Something went wrong",

                };
            
            }

            return Page();
        }

 

    public async Task<IActionResult> OnPostDelete() 
        {
            var deleted = await blogPostRepository.DeleteAsync(BlogPost.Id);
            
            if(deleted) 
            {
                var notification = new Notification
                {
                    Type = Enums.NotificationType.Success,
                    Message = "Blog deleted successfully",
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);
                return RedirectToPage("/Admin/Blogs/List");
             }
            return Page();
        }

    }
}

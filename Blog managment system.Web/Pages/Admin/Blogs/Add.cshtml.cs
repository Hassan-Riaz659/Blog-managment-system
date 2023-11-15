using Blog_managment_system.Web.Data;
using Blog_managment_system.Web.Models.Domain;
using Blog_managment_system.Web.Models.ViewModels;
using Blog_managment_system.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Blog_managment_system.Web.Pages.Admin.Blogs
{
    [Authorize(Roles = "Admin")]
    public class AddModel : PageModel
    {
        
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        public AddModel(IBlogPostRepository blogPostRepository)
        {
        
            this.blogPostRepository = blogPostRepository;
        }
        [BindProperty]
        public string Tags { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            var blogPost = new BlogPost()
            {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                Shortdescription = AddBlogPostRequest.Shortdescription,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible,
                Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag() { Name = x.Trim() }))
            };
           

            await blogPostRepository.AddAsync(blogPost);

            var notification = new Notification
            {
                Type = Enums.NotificationType.Success,
                Message = "New blog created!"
            };

            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/Admin/Blogs/List");


        /*          first method of getting all property values
         *         
         *          var heading = Request.Form["heading"];
                    var pageTitle = Request.Form["pageTitle"];
                    var content = Request.Form["content"];
                    var shortDescription = Request.Form["shortDescription"];
                    var FeaturedImageUrl = Request.Form["FeaturedImageUrl"];
                    var publishedDate = Request.Form["publishedDate"];*/

    }
}
}

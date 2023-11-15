using Blog_managment_system.Web.Models.ViewModels;
using Blog_managment_system.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Blog_managment_system.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostLikeController : Controller
    {
        private readonly IBlogPostLikeRepository blogPostLikeRepository;

        public BlogPostLikeController(IBlogPostLikeRepository blogPostLikeRepository)
        {
            this.blogPostLikeRepository = blogPostLikeRepository;
        }
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> AddLike([FromBody] AddBLogPostLikeRequest addBlogPostLikeRequest)
        {
           await blogPostLikeRepository.AddLikeForBlog(addBlogPostLikeRequest.BlogPostId, addBlogPostLikeRequest.UserId);
            return Ok();
        }

        [HttpGet]
        [Route("{blogPostId:Guid}/totallikes")]
        public async Task<IActionResult> GetTotalLikes([FromRoute] Guid blogPostId) 
        {
          var totalLikes =  await blogPostLikeRepository.GetTotalLikesForBlog(blogPostId);
          return Ok(totalLikes);
        }
    }
}

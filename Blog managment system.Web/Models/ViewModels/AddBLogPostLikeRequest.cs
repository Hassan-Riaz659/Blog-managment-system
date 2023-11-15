namespace Blog_managment_system.Web.Models.ViewModels
{
    public class AddBLogPostLikeRequest
    {
        public Guid BlogPostId { get; set; }
        public Guid UserId { get; set; }
    }
}

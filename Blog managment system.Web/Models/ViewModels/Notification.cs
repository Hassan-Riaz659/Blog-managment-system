using Blog_managment_system.Web.Enums;

namespace Blog_managment_system.Web.Models.ViewModels
{
    public class Notification
    {
        public string Message { get; set; }

        public NotificationType Type { get; set; }
    }
}

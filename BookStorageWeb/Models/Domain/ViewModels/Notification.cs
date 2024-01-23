using BookStorageWeb.Data.Enums;

namespace BookStorageWeb.Models.Domain.ViewModels
{
    public class Notification
    {
        public string Message {get;set;}

        public NotificationType Type { get;set;}
    }
}

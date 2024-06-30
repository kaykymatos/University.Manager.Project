using University.Manager.Project.Web.Blazor.Models.Enums;

namespace University.Manager.Project.Web.MVC.Models
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        public DateTime CreationData { get; set; }
        public DateTime UpdatedData { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? Attachment { get; set; }
        public ETypeOrder OrderType { get; set; }
        public long UserId { get; set; }
    }
}

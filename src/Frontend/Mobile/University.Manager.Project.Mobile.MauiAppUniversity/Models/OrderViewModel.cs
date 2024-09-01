using University.Manager.Project.Mobile.MauiAppUniversity.Models.Enums;
using University.Manager.Project.Mobile.MauiAppUniversity.Models.Interfaces;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Models
{
    public class OrderViewModel : IBaseModel
    {
        public long Id { get; set; }
        public DateTime CreationData { get; set; }
        public DateTime UpdatedData { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? Attachment { get; set; }
        public ETypeOrder OrderType { get; set; }
        public long UserId { get; set; }
        public Dictionary<string, object> ToDictionary()
        {
            throw new NotImplementedException();
        }
    }
}

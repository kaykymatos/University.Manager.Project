using University.Manager.Project.Mobile.MauiAppUniversity.Models.Interfaces;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Models
{
    public class StudentViewModel : IBaseModel
    {
        public long Id { get; set; }
        public string RegisterCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public long CourseId { get; set; }

        public decimal TotalValue { get; set; }
        public float Workload { get; set; }
        public DateTime CreationData { get; set; }
        public DateTime UpdatedData { get; set; }
        public Dictionary<string, object> ToDictionary()
        {
            throw new NotImplementedException();
        }
    }
}

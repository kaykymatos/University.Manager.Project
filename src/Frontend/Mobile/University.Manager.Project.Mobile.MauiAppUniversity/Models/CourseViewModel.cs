using University.Manager.Project.Mobile.MauiAppUniversity.Models.Interfaces;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Models
{
    public class CourseViewModel : IBaseModel
    {
        public long Id { get; set; }
        public DateTime CreationData { get; set; } = DateTime.Now;
        public DateTime UpdatedData { get; set; } = DateTime.Now;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Workload { get; set; }
        public decimal TotalValue { get; set; }
        public long CourseCategoryId { get; set; }
        public CourseCategoryViewModel CourseCategory { get; set; }
        public Dictionary<string, object> ToDictionary()
        {
            throw new NotImplementedException();
        }

    }
}

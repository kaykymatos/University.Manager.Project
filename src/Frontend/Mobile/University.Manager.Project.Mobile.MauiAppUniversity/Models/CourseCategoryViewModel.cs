using University.Manager.Project.Mobile.MauiAppUniversity.Models.Interfaces;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Models
{
    public class CourseCategoryViewModel : IBaseModel
    {
        public long Id { get; set; }
        public DateTime CreationData { get; set; }
        public DateTime UpdatedData { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Dictionary<string, object> ToDictionary()
        {
            throw new NotImplementedException();
        }
    }
}

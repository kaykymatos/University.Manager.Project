namespace University.Manager.Project.Web.MVC.Models
{
    public class StudentViewModel
    {
        public long Id { get; set; }
        public string RegisterCode { get; set; } = string.Empty;
        public long CourseId { get; set; }
        public long StudentId { get; set; }
        public DateTime CreationData { get; set; }
        public DateTime UpdatedData { get; set; }
    }
}

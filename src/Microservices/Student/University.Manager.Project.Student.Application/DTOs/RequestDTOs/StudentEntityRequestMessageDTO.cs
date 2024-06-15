using University.Manager.Project.MessageBus;

namespace University.Manager.Project.Student.Application.DTOs.RequestDTOs
{
    public class StudentEntityRequestMessageDTO : BaseMessage
    {
        public string RegisterCode { get; set; } = string.Empty;
        public long CourseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal TotalValue { get; set; }
        public float Workload { get; set; }
    }
}

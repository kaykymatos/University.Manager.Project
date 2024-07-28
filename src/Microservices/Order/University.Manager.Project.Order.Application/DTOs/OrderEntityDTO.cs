using University.Manager.Project.Order.Application.DTOs.Enum;
using University.Manager.Project.Order.Application.Interfaces;

namespace University.Manager.Project.Order.Application.DTOs
{
    public class OrderEntityDTO : IBaseModel
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

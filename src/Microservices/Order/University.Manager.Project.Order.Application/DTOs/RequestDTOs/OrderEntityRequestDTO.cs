using University.Manager.Project.Order.Application.DTOs.Enum;
using University.Manager.Project.Order.Application.Interfaces;

namespace University.Manager.Project.Order.Application.DTOs.RequestDTOs
{
    public class OrderEntityRequestDTO : IBaseModel
    {
        public OrderEntityRequestDTO(long id, string title, string message, string? attachment, ETypeOrder orderType, long userId)
        {
            Id = id;
            Title = title;
            Message = message;
            Attachment = attachment;
            OrderType = orderType;
            UserId = userId;
        }
        public OrderEntityRequestDTO()
        {

        }
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? Attachment { get; set; }

        public ETypeOrder OrderType { get; set; }
        public long UserId { get; set; }
        public DateTime CreationData { get; set; }
        public DateTime UpdatedData { get; set; }
    }
}

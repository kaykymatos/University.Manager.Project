

using System.ComponentModel.DataAnnotations;
using University.Manager.Project.Order.Application.DTOs.Enum;

namespace University.Manager.Project.Order.Application.DTOs.RequestDTOs
{
    public class OrderEntityRequestDTO
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public byte[]? Attachment { get; set; }

        [EnumDataType(typeof(ETypeOrder))]
        public ETypeOrder OrderType { get; set; }
        public long UserId { get; set; }
    }
}

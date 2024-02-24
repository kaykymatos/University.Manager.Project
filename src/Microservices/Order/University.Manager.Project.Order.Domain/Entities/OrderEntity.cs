using System.ComponentModel.DataAnnotations;
using University.Manager.Project.Order.Domain.Entities.Enum;
using University.Manager.Project.Order.Domain.Validation;

namespace University.Manager.Project.Order.Domain.Entities
{
    public class OrderEntity : Entity
    {
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public byte[]? Attachment { get; set; }
        [EnumDataType(typeof(ETypeOrder))]
        public ETypeOrder OrderType { get; set; }
        public long UserId { get; set; }

        public OrderEntity()
        {

        }

        public OrderEntity(long id, string title, string message, byte[] attachment, ETypeOrder orderType, long userId)
        {
            Id = id;
            Title = title;
            Message = message;
            Attachment = attachment;
            OrderType = orderType;
            UserId = userId;
        }
        public void UpdateDomain(string title, string message, byte[]? attachment, ETypeOrder orderType, long userId)
        {
            ValidationDomain(title, message, attachment, orderType, userId);
            UpdatedData = DateTime.Now;
        }
        private void ValidationDomain(string title, string message, byte[]? attachment, ETypeOrder orderType, long userId)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(title),
                "Invalid Title, Title is required!");
            DomainExceptionValidation.When(title.Length < 3,
                "Invalid Title, Title is too short, minimum 3 characters!");
            DomainExceptionValidation.When(title.Length > 200,
                "Invalid Title, Title is too long, maximum 200 characters!");
            Title = title;

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(message),
                "Invalid Message, Message is required!");
            DomainExceptionValidation.When(message.Length < 3,
                "Invalid Message, Message is too short, minimum 3 characters!");
            DomainExceptionValidation.When(title.Length > 200,
                "Invalid Message, Message is too long, maximum 200 characters!");
            Message = message;

            if (attachment?.Length > 0)
            {
                DomainExceptionValidation.When(
                    !IsPdfAttachment(attachment) &&
                    !IsJpegAttachment(attachment) &&
                    !IsPngAttachment(attachment),
                "Invalid Attachment, the Attachment must be .pdf, .png, .jpeg or .jpg!");
                Attachment = attachment;
            }
            switch (orderType)
            {
                case ETypeOrder.GENERAL_PROBLEM:
                    break;
                case ETypeOrder.FINANCIAL_PROBLEM:
                    break;
                case ETypeOrder.DOUBT:
                    break;
                default:
                    throw new DomainExceptionValidation("Invalid Order type, Order type is not defined!");

            }
            DomainExceptionValidation.When(userId <= 0,
                "Invalid User Id, User Id must be greater than 0!");
            UserId = userId;

        }
        static bool CheckSignature(byte[] arquivoBytes, byte[] assinatura)
        {
            if (arquivoBytes.Length < assinatura.Length)
                return false;

            for (int i = 0; i < assinatura.Length; i++)
            {
                if (arquivoBytes[i] != assinatura[i])
                    return false;
            }

            return true;
        }
        static bool IsPdfAttachment(byte[] bytes)
        {
            // Assinatura dos primeiros bytes de um arquivo PDF
            byte[] pdfSignature = { 0x25, 0x50, 0x44, 0x46, 0x2D };
            return CheckSignature(bytes, pdfSignature);
        }
        static bool IsJpegAttachment(byte[] bytes)
        {
            // Assinatura dos primeiros bytes de um arquivo JPEG
            byte[] jpegSignature = { 0xFF, 0xD8, 0xFF, 0xE0 };
            return CheckSignature(bytes, jpegSignature);
        }
        static bool IsPngAttachment(byte[] bytes)
        {
            // Assinatura dos primeiros bytes de um arquivo PNG
            byte[] pngSignature = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
            return CheckSignature(bytes, pngSignature);
        }
    }
}

using University.Manager.Project.Order.Domain.Entities.Enum;
using University.Manager.Project.Order.Domain.Validation;

namespace University.Manager.Project.Order.Domain.Entities
{
    public class OrderEntity : Entity
    {
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? Attachment { get; set; }
        public ETypeOrder OrderType { get; set; }
        public long UserId { get; set; }

        public OrderEntity()
        {

        }

        public OrderEntity(long id, string title, string message, string attachment, ETypeOrder orderType, long userId)
        {
            DomainExceptionValidation.When(id <= 0,
                "Invalid Id value!");

            ValidationDomain(title, message, attachment, orderType, userId);
        }
        public void UpdateDomain(string title, string message, string? attachment, ETypeOrder orderType, long userId)
        {
            ValidationDomain(title, message, attachment, orderType, userId);
            UpdatedData = DateTime.Now;
        }
        private void ValidationDomain(string title, string message, string? attachment, ETypeOrder orderType, long userId)
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
            DomainExceptionValidation.When(message.Length > 200,
                "Invalid Message, Message is too long, maximum 200 characters!");
            Message = message;

            if (!string.IsNullOrWhiteSpace(attachment))
            {
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

    }
}

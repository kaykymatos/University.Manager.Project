
namespace University.Manager.Project.Order.Domain.Tests
{
    public class OrderEntityTests
    {
        [Fact]
        public void CreateOrderEntity_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new OrderEntity(1, "Teste", "Teste", "", ETypeOrder.GENERAL_PROBLEM, 1);
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Fact]
        public void CreateOrderEntity_NavigateIdValue_DomainExceptionInvalidId()
        {
            Action action = () =>
            new OrderEntity(-1, "Teste", "Teste", "", ETypeOrder.GENERAL_PROBLEM, 1);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value!");
        }
        [Theory]
        [InlineData("a")]
        [InlineData("ab")]
        public void CreateOrderEntity_ShortTitle_DomainExceptionShortTitle(string title)
        {
            Action action = () =>
            new OrderEntity(1, title, "Teste", "", ETypeOrder.GENERAL_PROBLEM, 1);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Title, Title is too short, minimum 3 characters!");
        }
        [Fact]
        public void CreateOrderEntity_NullTitle_DomainExceptionTitleIsRequired()
        {
            Action action = () =>
            new OrderEntity(1, null, "Teste", "", ETypeOrder.GENERAL_PROBLEM, 1);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Title, Title is required!");
        }
        [Fact]
        public void CreateOrderEntity_EmptyTitle_DomainExceptionTitleIsRequired()
        {
            Action action = () =>
            new OrderEntity(1, string.Empty, "Teste", "", ETypeOrder.GENERAL_PROBLEM, 1);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Title, Title is required!");
        }
        [Fact]
        public void CreateOrderEntity_EmptyStringTitle_DomainExceptionTitleIsRequired()
        {
            Action action = () =>
            new OrderEntity(1, "", "Teste", "", ETypeOrder.GENERAL_PROBLEM, 1);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Title, Title is required!");
        }

        [Fact]
        public void CreateOrderEntity_GreaterThanTitle_DomainExceptionGreaterThanTitle()
        {
            Action action = () =>
            new OrderEntity(1, "teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste", "Teste", "", ETypeOrder.GENERAL_PROBLEM, 1);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Title, Title is too long, maximum 200 characters!");
        }
        [Theory]
        [InlineData("a")]
        [InlineData("ab")]
        public void CreateOrderEntity_ShortMessage_DomainExceptionShortMessage(string message)
        {
            Action action = () =>
            new OrderEntity(1, "Teste", message, "", ETypeOrder.GENERAL_PROBLEM, 1);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Message, Message is too short, minimum 3 characters!");
        }
        [Fact]
        public void CreateOrderEntity_NullMessage_DomainExceptionMessageIsRequired()
        {
            Action action = () =>
            new OrderEntity(1, "Teste", null, "", ETypeOrder.GENERAL_PROBLEM, 1);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Message, Message is required!");
        }
        [Fact]
        public void CreateOrderEntity_EmptyMessage_DomainExceptionMessageIsRequired()
        {
            Action action = () =>
            new OrderEntity(1, "Teste", string.Empty, "", ETypeOrder.GENERAL_PROBLEM, 1);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Message, Message is required!");
        }
        [Fact]
        public void CreateOrderEntity_EmptyStringMessage_DomainExceptionMessageIsRequired()
        {
            Action action = () =>
           new OrderEntity(1, "Teste", "", "", ETypeOrder.GENERAL_PROBLEM, 1);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Message, Message is required!");
        }

        [Fact]
        public void CreateOrderEntity_GreaterThanMessage_DomainExceptionGreaterThanMessage()
        {
            Action action = () =>
            new OrderEntity(1, "Teste", "teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste", "", ETypeOrder.GENERAL_PROBLEM, 1);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Message, Message is too long, maximum 200 characters!");
        }
        [Fact]
        public void CreateOrderEntity_UserIdLessThan_DomainExceptionUserIdLessThan()
        {
            Action action = () =>
           new OrderEntity(1, "Teste", "Teste", "", ETypeOrder.GENERAL_PROBLEM, 0);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid User Id, User Id must be greater than 0!");
        }


    }
}
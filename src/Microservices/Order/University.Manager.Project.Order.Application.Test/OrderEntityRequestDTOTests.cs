using University.Manager.Project.Order.Application.DTOs.Enum;
using University.Manager.Project.Order.Application.DTOs.RequestDTOs;
using University.Manager.Project.Order.Application.Validation;
using University.Manager.Project.Order.Application.Validation.ErrorMessages;

namespace University.Manager.Project.Order.Application.Test
{
    public class OrderEntityRequestDTOTests
    {
        private readonly OrderEntityRequestDTOValidation _validator;
        public OrderEntityRequestDTOTests()
        {
            _validator = new OrderEntityRequestDTOValidation();
        }
        [Fact]
        public async Task CreateOrderEntityRequestDTO_WithValidParameters_ResultObjectValidState()
        {
            OrderEntityRequestDTO model = new OrderEntityRequestDTO(1, "Teste", "Teste", "", ETypeOrder.GENERAL_PROBLEM, 1);
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.True(validation.IsValid);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("ab")]
        public async Task CreateOrderEntityRequestDTO_ShortTitle_DomainExceptionShortTitle(string title)
        {
            OrderEntityRequestDTO model =
             new OrderEntityRequestDTO(1, title, "Teste", "", ETypeOrder.GENERAL_PROBLEM, 1);
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMinLenght.Replace("{PropertyName}", "Title").Replace("{MinLength}", "3")));
        }
        [Fact]
        public async Task CreateOrderEntityRequestDTO_NullTitle_DomainExceptionTitleIsRequired()
        {
            OrderEntityRequestDTO model =
             new OrderEntityRequestDTO(1, null, "Teste", "", ETypeOrder.GENERAL_PROBLEM, 1);
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Title")));
        }
        [Fact]
        public async Task CreateOrderEntityRequestDTO_EmptyTitle_DomainExceptionTitleIsRequired()
        {
            OrderEntityRequestDTO model =
             new OrderEntityRequestDTO(1, string.Empty, "Teste", "", ETypeOrder.GENERAL_PROBLEM, 1);
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMinLenght.Replace("{PropertyName}", "Title").Replace("{MinLength}", "3")));
        }
        [Fact]
        public async Task CreateOrderEntityRequestDTO_EmptyStringTitle_DomainExceptionTitleIsRequired()
        {
            OrderEntityRequestDTO model =
             new OrderEntityRequestDTO(1, "", "Teste", "", ETypeOrder.GENERAL_PROBLEM, 1);
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMinLenght.Replace("{PropertyName}", "Title").Replace("{MinLength}", "3")));
        }

        [Fact]
        public async Task CreateOrderEntityRequestDTO_GreaterThanTitle_DomainExceptionGreaterThanTitle()
        {
            OrderEntityRequestDTO model =
             new OrderEntityRequestDTO(1, "teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste", "Teste", "", ETypeOrder.GENERAL_PROBLEM, 1);
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMaxLenght.Replace("{PropertyName}", "Title").Replace("{MaxLength}", "200")));
        }
        [Theory]
        [InlineData("a")]
        [InlineData("ab")]
        public async Task CreateOrderEntityRequestDTO_ShortMessage_DomainExceptionShortMessage(string message)
        {
            OrderEntityRequestDTO model =
             new OrderEntityRequestDTO(1, "Teste", message, "", ETypeOrder.GENERAL_PROBLEM, 1);
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMinLenght.Replace("{PropertyName}", "Message").Replace("{MinLength}", "3")));
        }
        [Fact]
        public async Task CreateOrderEntityRequestDTO_NullMessage_DomainExceptionMessageIsRequired()
        {
            OrderEntityRequestDTO model =
             new OrderEntityRequestDTO(1, "Teste", null, "", ETypeOrder.GENERAL_PROBLEM, 1);
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Message")));
        }
        [Fact]
        public async Task CreateOrderEntityRequestDTO_EmptyMessage_DomainExceptionMessageIsRequired()
        {
            OrderEntityRequestDTO model =
             new OrderEntityRequestDTO(1, "Teste", string.Empty, "", ETypeOrder.GENERAL_PROBLEM, 1);
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMinLenght.Replace("{PropertyName}", "Message").Replace("{MinLength}", "3")));
        }
        [Fact]
        public async Task CreateOrderEntityRequestDTO_EmptyStringMessage_DomainExceptionMessageIsRequired()
        {
            OrderEntityRequestDTO model =
            new OrderEntityRequestDTO(1, "Teste", "", "", ETypeOrder.GENERAL_PROBLEM, 1);
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMinLenght.Replace("{PropertyName}", "Message").Replace("{MinLength}", "3")));
        }

        [Fact]
        public async Task CreateOrderEntityRequestDTO_GreaterThanMessage_DomainExceptionGreaterThanMessage()
        {
            OrderEntityRequestDTO model =
             new OrderEntityRequestDTO(1, "Teste", "teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste", "", ETypeOrder.GENERAL_PROBLEM, 1);
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMaxLenght.Replace("{PropertyName}", "Message").Replace("{MaxLength}", "200")));
        }
        [Fact]
        public async Task CreateOrderEntityRequestDTO_UserIdLessThan_DomainExceptionUserIdLessThan()
        {
            OrderEntityRequestDTO model =
            new OrderEntityRequestDTO(1, "Teste", "Teste", "", ETypeOrder.GENERAL_PROBLEM, 0);
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan.Replace("{PropertyName}", "UserId").Replace("{ComparisonValue}", "0")));
        }
    }
}
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using University.Manager.Project.Order.Application.DTOs.RequestDTOs;
using University.Manager.Project.Order.Application.Test.Builder;
using University.Manager.Project.Order.Application.Validation;
using University.Manager.Project.Order.Application.Validation.ErrorMessages;

namespace University.Manager.Project.Order.Application.Test
{
    public class OrderEntityRequestDTOTests
    {
        private readonly OrderEntityRequestDTOBuilder _builder;
        private readonly OrderEntityRequestDTOValidation _validator;
        public OrderEntityRequestDTOTests()
        {
            _builder = new OrderEntityRequestDTOBuilder();
            _validator = new ServiceCollection()
                .AddTransient<OrderEntityRequestDTOValidation>()
                .BuildServiceProvider()
                .GetService<OrderEntityRequestDTOValidation>();

        }
        [Fact]
        public async Task CreateOrderEntityRequestDTO_WithValidParameters_ResultObjectValidState()
        {
            OrderEntityRequestDTO model = _builder.Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.True(validation.IsValid);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("ab")]
        public async Task CreateOrderEntityRequestDTO_ShortTitle_DomainExceptionShortTitle(string title)
        {
            OrderEntityRequestDTO model = _builder.With(x => x.Title = title).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMinLenght.Replace("{PropertyName}", "Title").Replace("{MinLength}", "3")));
        }
        [Fact]
        public async Task CreateOrderEntityRequestDTO_NullTitle_DomainExceptionTitleIsRequired()
        {
            OrderEntityRequestDTO model = _builder.With(x => x.Title = null).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Title")));
        }
        [Fact]
        public async Task CreateOrderEntityRequestDTO_EmptyTitle_DomainExceptionTitleIsRequired()
        {
            OrderEntityRequestDTO model = _builder.With(x => x.Title = string.Empty).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMinLenght.Replace("{PropertyName}", "Title").Replace("{MinLength}", "3")));
        }
        [Fact]
        public async Task CreateOrderEntityRequestDTO_EmptyStringTitle_DomainExceptionTitleIsRequired()
        {
            OrderEntityRequestDTO model = _builder.With(x => x.Title = "").Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMinLenght.Replace("{PropertyName}", "Title").Replace("{MinLength}", "3")));
        }

        [Fact]
        public async Task CreateOrderEntityRequestDTO_GreaterThanTitle_DomainExceptionGreaterThanTitle()
        {
            OrderEntityRequestDTO model = _builder.With(x => x.Title = "teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste").Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMaxLenght.Replace("{PropertyName}", "Title").Replace("{MaxLength}", "200")));
        }
        [Theory]
        [InlineData("a")]
        [InlineData("ab")]
        public async Task CreateOrderEntityRequestDTO_ShortMessage_DomainExceptionShortMessage(string message)
        {
            OrderEntityRequestDTO model = _builder.With(x => x.Message = message).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMinLenght.Replace("{PropertyName}", "Message").Replace("{MinLength}", "3")));
        }
        [Fact]
        public async Task CreateOrderEntityRequestDTO_NullMessage_DomainExceptionMessageIsRequired()
        {
            OrderEntityRequestDTO model = _builder.With(x => x.Message = null).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Message")));
        }
        [Fact]
        public async Task CreateOrderEntityRequestDTO_EmptyMessage_DomainExceptionMessageIsRequired()
        {
            OrderEntityRequestDTO model = _builder.With(x => x.Message = string.Empty).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMinLenght.Replace("{PropertyName}", "Message").Replace("{MinLength}", "3")));
        }
        [Fact]
        public async Task CreateOrderEntityRequestDTO_EmptyStringMessage_DomainExceptionMessageIsRequired()
        {
            OrderEntityRequestDTO model = _builder.With(x => x.Message = "").Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMinLenght.Replace("{PropertyName}", "Message").Replace("{MinLength}", "3")));
        }

        [Fact]
        public async Task CreateOrderEntityRequestDTO_GreaterThanMessage_DomainExceptionGreaterThanMessage()
        {
            OrderEntityRequestDTO model = _builder.With(x => x.Message = "teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste").Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMaxLenght.Replace("{PropertyName}", "Message").Replace("{MaxLength}", "200")));
        }
        [Fact]
        public async Task CreateOrderEntityRequestDTO_UserIdLessThan_DomainExceptionUserIdLessThan()
        {
            OrderEntityRequestDTO model = _builder.With(x => x.UserId = 0).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan.Replace("{PropertyName}", "UserId").Replace("{ComparisonValue}", "0")));
        }
    }
}
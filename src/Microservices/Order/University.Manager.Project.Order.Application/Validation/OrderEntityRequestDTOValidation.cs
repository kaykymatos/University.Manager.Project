using FluentValidation;
using University.Manager.Project.Order.Application.DTOs.RequestDTOs;
using University.Manager.Project.Order.Application.Validation.ErrorMessages;

namespace University.Manager.Project.Order.Application.Validation
{
    public class OrderEntityRequestDTOValidation : AbstractValidator<OrderEntityRequestDTO>
    {
        public OrderEntityRequestDTOValidation()
        {
            RuleFor(x => x.Message).NotEmpty().WithMessage(BaseValidationErrorMessages.FieldNull)
               .MinimumLength(3).WithMessage(BaseValidationErrorMessages.FieldMinLenght)
               .MaximumLength(200).WithMessage(BaseValidationErrorMessages.FieldMaxLenght)
               .WithName("Message");

            RuleFor(x => x.Title).NotEmpty().WithMessage(BaseValidationErrorMessages.FieldNull)
               .MinimumLength(3).WithMessage(BaseValidationErrorMessages.FieldMinLenght)
               .MaximumLength(200).WithMessage(BaseValidationErrorMessages.FieldMaxLenght)
               .WithName("Title");

            RuleFor(x => x.UserId)
               .GreaterThan(0).WithMessage(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan)
               .LessThan(9999999).WithMessage(BaseValidationErrorMessages.FieldNumberMustBeLessThan)
               .WithName("UserId");
            When(x => x.Attachment?.Length > 0, () =>
            {
                RuleFor(x => x.Attachment)
               .Must(CheckAttachment).WithMessage("Invalid Attachment, the Attachment must be .pdf, .png, .jpeg or .jpg!").WithName("Attachment");

            });
        }
        static bool CheckAttachment(string? fileBytes)
        {
            return VerificarTipoArquivo(fileBytes);
        }

        static string ObterHeader(string base64String)
        {
            int headerLength = 20; // Ajuste conforme necessário para a assinatura do tipo de arquivo
            string header = base64String.Substring(0, headerLength);

            return header;
        }
        static bool VerificarTipoArquivo(string? base64String)
        {
            if (string.IsNullOrWhiteSpace(base64String))
                return false;

            string header = ObterHeader(base64String);

            if (header.StartsWith("JVBERi0xLj") || header.StartsWith("%PDF-"))
                return true;
            else if (header.StartsWith("/9j/") || header.StartsWith("ÿØÿÛ"))
                return true;
            else if (header.StartsWith("iVBORw0KGgo="))
                return true;
            else
                return false;

        }

    }
}

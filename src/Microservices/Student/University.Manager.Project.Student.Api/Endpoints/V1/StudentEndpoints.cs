using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using University.Manager.Project.Student.Application.DTOs;
using University.Manager.Project.Student.Application.DTOs.RequestDTOs;
using University.Manager.Project.Student.Application.Interfaces;
using University.Manager.Project.Student.Application.Models.Error;
using University.Manager.Project.Student.Application.RabbitMQSender;

namespace University.Manager.Project.Student.Api.Endpoints.V1
{
    public class StudentEndpoints : BaseEndpoints<StudentEntityDTO, StudentEntityRequestDTO, IStudentService, IValidator<StudentEntityRequestDTO>>
    {
        protected override string BaseRoute => "api/v1/student";
        public override void MapEndpoints(WebApplication app)
        {
            base.MapGetAll(app);
            base.MapGetById(app);
            base.MapPut(app);

            var service = app.Services.CreateScope().ServiceProvider.GetService<IStudentService>();

            app.MapPost(BaseRoute, async ([FromBody] StudentEntityRequestDTO model,
                [FromServices] IStudentService _service,
                [FromServices] IValidator<StudentEntityRequestDTO> _validator,
                [FromServices] IRabbitMQMessageSender _sender,
                [FromServices] IMapper _mapper) =>
            {
                if (model == null)
                    return Results.BadRequest("Invalid Data!");

                FluentValidation.Results.ValidationResult validationModel = _validator.Validate(model);
                if (!validationModel.IsValid)
                    return Results.BadRequest(validationModel.Errors.ToCustomValidationFailure());
                await _service.CreateModelAsync(model);
                IEnumerable<StudentEntityDTO> student = await _service.GetAllAsync();
                StudentEntityRequestMessageDTO mapped = _mapper.Map<StudentEntityRequestMessageDTO>(model);
                mapped.Id = student.Max(x => x.Id);
                _sender.SendMessage(mapped, "student_financial_installments");

                return Results.Ok(model);
            }).RequireAuthorization();

            app.MapDelete($"{BaseRoute}/{{id:long}}", async ([FromRoute] long id) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new CustomValidationFailure("Id", "Invalid Id!"));

                var modelFound = await service.GetByIdAsync(id);
                if (modelFound == null)
                    return Results.NotFound(new CustomValidationFailure("Id", "Id not found!"));


                await service.DeleteModelAsync(modelFound);

                return Results.Ok(modelFound);
            }).RequireAuthorization();

            app.MapDelete(BaseRoute, async ([FromBody] IEnumerable<long> ids) =>
            {
                if (!ids.Any())
                    return Results.BadRequest(new CustomValidationFailure("Id", "Invalid Id!"));

                var allRegister = await service.GetAllAsync();
                var idsRemove = allRegister.Where(x => ids.Contains(x.Id)).ToList();
                await service.DeleteMultipleAsync(ids);

                return Results.Ok(ids);
            }).RequireAuthorization();
        }
    }

}

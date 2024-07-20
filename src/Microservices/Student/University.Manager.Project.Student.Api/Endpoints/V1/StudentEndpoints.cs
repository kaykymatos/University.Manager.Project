using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using University.Manager.Project.Student.Application.DTOs.RequestDTOs;
using University.Manager.Project.Student.Application.Interfaces;
using University.Manager.Project.Student.Application.Models.Error;
using University.Manager.Project.Student.Application.RabbitMQSender;

namespace University.Manager.Project.Student.Api.Endpoints.V1
{
    public static class StudentEndpoints
    {
        public static WebApplication MapStudentEndpoints(this WebApplication app)
        {
            app.MapGet("api/v1/student", async ([FromServices] IStudentService _service) =>
            {
                IEnumerable<Application.DTOs.StudentEntityDTO> listModel = await _service.GetAllAsync();
                if (listModel.Any())
                    return Results.Ok(listModel);
                return Results.NoContent();
            }).RequireAuthorization();
            app.MapGet("api/v1/student/{id:long}", async ([FromRoute] long id, [FromServices] IStudentService _service) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new CustomValidationFailure("Id", "Invalid Id!").ToList());

                Application.DTOs.StudentEntityDTO modelFound = await _service.GetByIdAsync(id);
                if (modelFound != null)
                    return Results.Ok(modelFound);
                return Results.NotFound();
            }).RequireAuthorization().WithName("student");

            app.MapPost("api/v1/student", async (
                [FromBody] StudentEntityRequestDTO model,
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
                IEnumerable<Application.DTOs.StudentEntityDTO> student = await _service.GetAllAsync();
                StudentEntityRequestMessageDTO mapped = _mapper.Map<StudentEntityRequestMessageDTO>(model);
                mapped.Id = student.Max(x => x.Id);
                _sender.SendMessage(mapped, "student_financial_installments");

                return Results.CreatedAtRoute("student", new { id = model.Id }, model);
            }).RequireAuthorization();

            app.MapPut("api/v1/student", async ([FromBody] StudentEntityRequestDTO model, [FromServices] IStudentService _service, [FromServices] IValidator<StudentEntityRequestDTO> _validator) =>
            {

                Application.DTOs.StudentEntityDTO modelFound = await _service.GetByIdAsync(model.Id);
                if (modelFound == null)
                    return Results.NotFound(
                        new CustomValidationFailure("Id", "Id not found!").ToList());

                FluentValidation.Results.ValidationResult validationModel = _validator.Validate(model);
                if (!validationModel.IsValid)
                    return Results.BadRequest(validationModel.Errors.ToCustomValidationFailure());

                await _service.UpdateModelAsync(model);
                return Results.NoContent();
            }).RequireAuthorization();
            app.MapDelete("api/v1/student/{id:long}", async ([FromRoute] long id, [FromServices] IStudentService _service) =>
            {
                if (id <= 0)
                    return Results.BadRequest(
                        new CustomValidationFailure("Id", "Invalid Id!").ToList());

                Application.DTOs.StudentEntityDTO modelFound = await _service.GetByIdAsync(id);
                if (modelFound == null)
                    return Results.NotFound(
                        new CustomValidationFailure("Id", "Id not found!").ToList());

                await _service.DeleteModelAsync(modelFound);

                return Results.Ok(modelFound);
            }).RequireAuthorization();

            app.MapDelete("api/v1/student", async ([FromBody] IEnumerable<long> ids,
               [FromServices] IStudentService _service) =>
            {
                if (!ids.Any())
                    return Results.BadRequest(
                        new CustomValidationFailure("Id", "Invalid Id!").ToList());


                await _service.DeleteMultipleAsync(ids);

                return Results.Ok(ids);
            }).RequireAuthorization();

            return app;
        }
    }
}

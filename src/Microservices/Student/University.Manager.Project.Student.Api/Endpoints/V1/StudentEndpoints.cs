using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using University.Manager.Project.Student.Api.Models.Error;
using University.Manager.Project.Student.Application.DTOs.RequestDTOs;
using University.Manager.Project.Student.Application.Interfaces;

namespace University.Manager.Project.Student.Api.Endpoints.V1
{
    public static class StudentEndpoints
    {
        public static WebApplication MapStudentEndpoints(this WebApplication app)
        {
            app.MapGet("api/v1/student", async ([FromServices] IStudentService _service) =>
            {
                var listModel = await _service.GetAllAsync();
                if (listModel.Any())
                    return Results.Ok(listModel);
                return Results.NoContent();
            });
            app.MapGet("api/v1/student/{id:long}", async ([FromRoute] long id, [FromServices] IStudentService _service) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new CustomValidationFailure("Id", "Invalid Id!").ToList());

                var modelFound = await _service.GetByIdAsync(id);
                if (modelFound != null)
                    return Results.Ok(modelFound);
                return Results.NotFound();
            }).WithName("student");

            app.MapPost("api/v1/student", async ([FromBody] StudentEntityRequestDTO model, [FromServices] IStudentService _service, [FromServices] IValidator<StudentEntityRequestDTO> _validator) =>
            {
                if (model == null)
                    return Results.BadRequest("Invalid Data!");

                var validationModel = _validator.Validate(model);
                if (!validationModel.IsValid)
                    return Results.BadRequest(validationModel.Errors.ToCustomValidationFailure());

                await _service.CreateModelAsync(model);
                return Results.CreatedAtRoute("student", new { id = model.Id }, model);
            });

            app.MapPut("api/v1/student/{id:long}", async ([FromRoute] long id, [FromBody] StudentEntityRequestDTO model, [FromServices] IStudentService _service, [FromServices] IValidator<StudentEntityRequestDTO> _validator) =>
            {
                if (id != model.Id)
                    return Results.BadRequest(
                        new CustomValidationFailure("Id", "Id can't be different!").ToList()
                            );

                var modelFound = await _service.GetByIdAsync(id);
                if (modelFound == null)
                    return Results.NotFound(
                        new CustomValidationFailure("Id", "Id not found!").ToList());

                var validationModel = _validator.Validate(model);
                if (!validationModel.IsValid)
                    return Results.BadRequest(validationModel.Errors.ToCustomValidationFailure());

                await _service.UpdateModelAsync(model);
                return Results.NoContent();
            });
            app.MapDelete("api/v1/student/{id:long}", async ([FromRoute] long id, [FromServices] IStudentService _service) =>
            {
                if (id <= 0)
                    return Results.BadRequest(
                        new CustomValidationFailure("Id", "Invalid Id!").ToList());

                var modelFound = await _service.GetByIdAsync(id);
                if (modelFound == null)
                    return Results.NotFound(
                        new CustomValidationFailure("Id", "Id not found!").ToList());

                await _service.DeleteModelAsync(modelFound);

                return Results.Ok(modelFound);
            });
            return app;
        }
    }
}

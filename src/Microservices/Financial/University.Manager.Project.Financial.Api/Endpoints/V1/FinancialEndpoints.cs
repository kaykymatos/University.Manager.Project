using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using University.Manager.Project.Financial.Application.DTOs.RequestDTOs;
using University.Manager.Project.Financial.Application.Interfaces;
using University.Manager.Project.Financial.Application.Models.Error;

namespace University.Manager.Project.Financial.Api.Endpoints.V1
{
    public static class FinancialEndpoints
    {
        public static WebApplication MapFinancialEndpoints(this WebApplication app)
        {
            app.MapGet("api/v1/financial", async ([FromServices] ICourseInstallmentsService _service) =>
            {
                IEnumerable<Application.DTOs.CourseInstallmentsDTO> listModel = await _service.GetAllAsync();
                if (listModel.Any())
                    return Results.Ok(listModel);
                return Results.NoContent();
            }).RequireAuthorization();
            app.MapGet("api/v1/financial/{id:long}", async ([FromRoute] long id, [FromServices] ICourseInstallmentsService _service) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new CustomValidationFailure("Id", "Invalid Id!").ToList());

                Application.DTOs.CourseInstallmentsDTO modelFound = await _service.GetByIdAsync(id);
                if (modelFound != null)
                    return Results.Ok(modelFound);
                return Results.NotFound();
            }).RequireAuthorization().WithName("financial");

            app.MapPost("api/v1/financial", async ([FromBody] CourseInstallmentsRequestDTO model, [FromServices] ICourseInstallmentsService _service, [FromServices] IValidator<CourseInstallmentsRequestDTO> _validator) =>
            {
                if (model == null)
                    return Results.BadRequest("Invalid Data!");

                FluentValidation.Results.ValidationResult validationModel = _validator.Validate(model);
                if (!validationModel.IsValid)
                    return Results.BadRequest(validationModel.Errors.ToCustomValidationFailure());

                await _service.CreateModelAsync(model);
                return Results.CreatedAtRoute("financial", new { id = model.Id }, model);
            }).RequireAuthorization();

            app.MapPut("api/v1/financial", async ([FromBody] CourseInstallmentsRequestDTO model, [FromServices] ICourseInstallmentsService _service, [FromServices] IValidator<CourseInstallmentsRequestDTO> _validator) =>
            {

                Application.DTOs.CourseInstallmentsDTO modelFound = await _service.GetByIdAsync(model.Id);
                if (modelFound == null)
                    return Results.NotFound(
                        new CustomValidationFailure("Id", "Id not found!").ToList());

                FluentValidation.Results.ValidationResult validationModel = _validator.Validate(model);
                if (!validationModel.IsValid)
                    return Results.BadRequest(validationModel.Errors.ToCustomValidationFailure());

                await _service.UpdateModelAsync(model);
                return Results.NoContent();
            }).RequireAuthorization();
            app.MapDelete("api/v1/financial/{id:long}", async ([FromRoute] long id, [FromServices] ICourseInstallmentsService _service) =>
            {
                if (id <= 0)
                    return Results.BadRequest(
                        new CustomValidationFailure("Id", "Invalid Id!").ToList());

                Application.DTOs.CourseInstallmentsDTO modelFound = await _service.GetByIdAsync(id);
                if (modelFound == null)
                    return Results.NotFound(
                        new CustomValidationFailure("Id", "Id not found!").ToList());

                await _service.DeleteModelAsync(modelFound);

                return Results.Ok(modelFound);
            }).RequireAuthorization();

            app.MapDelete("api/v1/financial", async ([FromBody] IEnumerable<long> ids,
                [FromServices] ICourseInstallmentsService _service) =>
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

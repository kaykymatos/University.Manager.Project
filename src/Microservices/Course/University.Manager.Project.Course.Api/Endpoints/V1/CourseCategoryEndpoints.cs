using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using University.Manager.Project.Course.Api.Models.Error;
using University.Manager.Project.Course.Application.DTOs.RequestDTOs;
using University.Manager.Project.Course.Application.Interfaces;

namespace University.Manager.Project.Course.Api.Endpoints.V1
{
    public static class CourseCategoryEndpoints
    {
        public static WebApplication MapCourseCategoryEndpoints(this WebApplication app)
        {
            app.MapGet("api/v1/courseCategory", async ([FromServices] ICourseCategoryService _service) =>
            {
                var listModel = await _service.GetAllAsync();
                if (listModel.Any())
                    return Results.Ok(listModel);
                return Results.NoContent();
            });
            app.MapGet("api/v1/courseCategory/{id:long}", async ([FromRoute] long id, [FromServices] ICourseCategoryService _service) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new CustomValidationFailure("Id", "Invalid Id!").ToList());

                var modelFound = await _service.GetByIdAsync(id);
                if (modelFound != null)
                    return Results.Ok(modelFound);
                return Results.NotFound();
            }).WithName("courseCategory");

            app.MapPost("api/v1/courseCategory", async ([FromBody] CourseCategoryRequestDTO model, [FromServices] ICourseCategoryService _service, [FromServices] IValidator<CourseCategoryRequestDTO> _validator) =>
            {
                if (model == null)
                    return Results.BadRequest("Invalid Data!");

                var validationModel = _validator.Validate(model);
                if (!validationModel.IsValid)
                    return Results.BadRequest(validationModel.Errors.ToCustomValidationFailure());

                await _service.CreateModelAsync(model);
                return Results.CreatedAtRoute("courseCategory", new { id = model.Id }, model);
            });

            app.MapPut("api/v1/courseCategory/{id:long}", async ([FromRoute] long id, [FromBody] CourseCategoryRequestDTO model, [FromServices] ICourseCategoryService _service, [FromServices] IValidator<CourseCategoryRequestDTO> _validator) =>
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
            app.MapDelete("api/v1/courseCategory/{id:long}", async ([FromRoute] long id, [FromServices] ICourseCategoryService _service) =>
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

using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using University.Manager.Project.Course.Application.DTOs.RequestDTOs;
using University.Manager.Project.Course.Application.Interfaces;
using University.Manager.Project.Course.Application.Models.Error;

namespace University.Manager.Project.Course.Api.Endpoints.V1
{
    public static class CourseEndpoints
    {
        public static WebApplication MapCourseEndpoints(this WebApplication app)
        {
            app.MapGet("api/v1/course", async ([FromServices] ICourseService _service) =>
            {
                var listModel = await _service.GetAllAsync();
                if (listModel.Any())
                    return Results.Ok(listModel);
                return Results.NoContent();
            });
            app.MapGet("api/v1/course/{id:long}", async ([FromRoute] long id, [FromServices] ICourseService _service) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new CustomValidationFailure("Id", "Invalid Id").ToList());

                var modelFound = await _service.GetByIdAsync(id);
                if (modelFound != null)
                    return Results.Ok(modelFound);
                return Results.NotFound();
            }).WithName("course");

            app.MapGet("api/v1/course/category/{id:long}", async ([FromRoute] long id, [FromServices] ICourseService _service) =>
            {
                if (id <= 0)
                    return Results.BadRequest(
                        new CustomValidationFailure("Id", "Invalid Id").ToList()
                               );

                var modelFound = await _service.GetCourseByCategoryId(id);
                if (modelFound.Any())
                    return Results.Ok(modelFound);
                return Results.NoContent();
            });
            app.MapPost("api/v1/course", async ([FromBody] CourseEntityRequestDTO model, [FromServices] ICourseService _service, [FromServices] ICourseCategoryService _categoryService, [FromServices] IValidator<CourseEntityRequestDTO> _validator) =>
            {
                if (model == null)
                    return Results.BadRequest("Invalid Data!");

                var category = await _categoryService.GetByIdAsync(model.CourseCategoryId);
                if (category == null)
                    return Results.BadRequest(
                        new CustomValidationFailure("CategoryId", "Category Id not found!").ToList()
                               );
                var validationModel = _validator.Validate(model);
                if (!validationModel.IsValid)
                    return Results.BadRequest(validationModel.Errors.ToCustomValidationFailure());

                await _service.CreateModelAsync(model);
                return Results.CreatedAtRoute("course", new { id = model.Id }, model);
            });
            app.MapPut("api/v1/course/{id:long}", async ([FromRoute] long id, [FromBody] CourseEntityRequestDTO model, [FromServices] ICourseService _service, [FromServices] ICourseCategoryService _categoryService, [FromServices] IValidator<CourseEntityRequestDTO> _validator) =>
            {
                if (id != model.Id)
                    return Results.BadRequest(
                        new CustomValidationFailure("Id", "Id can't by different!").ToList()
                        );
                var category = await _categoryService.GetByIdAsync(model.CourseCategoryId);
                if (category == null)
                    return Results.BadRequest(
                        new CustomValidationFailure("CategoryId", "Category Id not found!").ToList()
                               );

                var modelFound = await _service.GetByIdAsync(id);
                if (modelFound == null)
                    return Results.NotFound(new CustomValidationFailure("Id", "Course not found!").ToList());

                var validationModel = _validator.Validate(model);
                if (!validationModel.IsValid)
                    return Results.BadRequest(validationModel.Errors.ToCustomValidationFailure());

                await _service.UpdateModelAsync(model);
                return Results.NoContent();
            });
            app.MapDelete("api/v1/course/{id:long}", async ([FromRoute] long id, [FromServices] ICourseService _service) =>
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

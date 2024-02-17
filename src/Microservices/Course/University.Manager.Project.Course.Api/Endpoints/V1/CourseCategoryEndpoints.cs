using Microsoft.AspNetCore.Mvc;
using University.Manager.Project.Course.Application.DTOs;
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
                    return Results.BadRequest("Invalid Id!");

                var modelFound = await _service.GetByIdAsync(id);
                if (modelFound != null)
                    return Results.Ok(modelFound);
                return Results.NotFound();
            }).WithName("courseCategory");

            app.MapPost("api/v1/courseCategory", async ([FromBody] CourseCategoryDTO model, [FromServices] ICourseCategoryService _service) =>
            {
                if (model == null)
                    return Results.BadRequest("Invalid Data!");
                await _service.CreateModelAsync(model);
                return Results.CreatedAtRoute("courseCategory", new { id = model.Id }, model);
            });

            app.MapPut("api/v1/courseCategory/{id:long}", async ([FromRoute] long id, [FromBody] CourseCategoryDTO model, [FromServices] ICourseCategoryService _service) =>
            {
                if (id != model.Id)
                    return Results.BadRequest("Id not found!");

                var modelFound = await _service.GetByIdAsync(id);
                if (modelFound == null)
                    return Results.NotFound("Category not found!");

                model.CreationData = modelFound.CreationData;
                await _service.UpdateModelAsync(model);
                return Results.NoContent();
            });
            app.MapDelete("api/v1/courseCategory/{id:long}", async ([FromRoute] long id, [FromServices] ICourseCategoryService _service) =>
            {
                if (id <= 0)
                    return Results.BadRequest("Invalid Id!");

                var modelFound = await _service.GetByIdAsync(id);
                if (modelFound == null)
                    return Results.NotFound("Category not found!");

                await _service.DeleteModelAsync(modelFound);

                return Results.Ok(modelFound);
            });
            return app;
        }
    }
}

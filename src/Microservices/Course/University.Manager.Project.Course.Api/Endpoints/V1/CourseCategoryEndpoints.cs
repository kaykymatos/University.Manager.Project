using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using University.Manager.Project.Course.Application.DTOs;
using University.Manager.Project.Course.Application.DTOs.RequestDTOs;
using University.Manager.Project.Course.Application.Interfaces;
using University.Manager.Project.Course.Application.Models.Error;

namespace University.Manager.Project.Course.Api.Endpoints.V1
{
    public class CourseCategoryEndpoints : BaseEndpoints<CourseCategoryDTO, CourseCategoryRequestDTO, ICourseCategoryService, IValidator<CourseCategoryRequestDTO>>
    {

        protected override string BaseRoute => "api/v1/courseCategory";
        public override void MapEndpoints(WebApplication app)
        {
            base.MapGetAll(app);
            base.MapGetById(app);
            base.MapPost(app);
            base.MapPut(app);
            var service = app.Services.CreateScope().ServiceProvider.GetService<ICourseCategoryService>();
            var courseService = app.Services.CreateScope().ServiceProvider.GetService<ICourseService>();


            app.MapDelete($"{BaseRoute}/{{id:long}}", async ([FromRoute] long id) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new CustomValidationFailure("Id", "Invalid Id!"));

                var modelFound = await service.GetByIdAsync(id);
                if (modelFound == null)
                    return Results.NotFound(new CustomValidationFailure("Id", "Id not found!"));

                var vinculedCourse = await courseService.GetCourseByCategoryId(id);
                if (vinculedCourse.Count() > 0)
                    return Results.BadRequest(new CustomValidationFailure("Category", "There are courses linked in this category!"));


                await service.DeleteModelAsync(modelFound);
                return Results.Ok(modelFound);
            }).RequireAuthorization();

            app.MapDelete(BaseRoute, async ([FromBody] IEnumerable<long> ids) =>
            {
                if (!ids.Any())
                    return Results.BadRequest(new CustomValidationFailure("Id", "Invalid Id!"));

                bool hasVinculedCourse = false;
                foreach (var item in ids)
                {
                    var vinculedCourse = await courseService.GetCourseByCategoryId(item);
                    if (vinculedCourse.Any())
                    {
                        hasVinculedCourse = true;
                        break;
                    }
                }
                if (hasVinculedCourse)
                    return Results.BadRequest(new CustomValidationFailure("Category", "There are courses linked in this category!"));


                await service.DeleteMultipleAsync(ids);
                return Results.Ok(ids);
            }).RequireAuthorization();
        }
    }
}

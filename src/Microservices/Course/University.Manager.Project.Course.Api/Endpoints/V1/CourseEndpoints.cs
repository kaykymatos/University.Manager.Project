using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using University.Manager.Project.Course.Application.DTOs;
using University.Manager.Project.Course.Application.DTOs.RequestDTOs;
using University.Manager.Project.Course.Application.Interfaces;
using University.Manager.Project.Course.Application.Models.Error;

namespace University.Manager.Project.Course.Api.Endpoints.V1
{
    public class CourseEndpoints : BaseEndpoints<CourseEntityDTO, CourseEntityRequestDTO, ICourseService, IValidator<CourseEntityRequestDTO>>
    {
        protected override string BaseRoute => "api/v1/course";
        public override void MapEndpoints(WebApplication app)
        {
            base.MapEndpoints(app);
            app.MapGet("api/v1/course/category/{id:long}", async ([FromRoute] long id, [FromServices] ICourseService _service) =>
            {
                if (id <= 0)
                    return Results.BadRequest(
                        new CustomValidationFailure("Id", "Invalid Id").ToList()
                               );

                IEnumerable<CourseEntityDTO> modelFound = await _service.GetCourseByCategoryId(id);
                if (modelFound.Any())
                    return Results.Ok(modelFound);
                return Results.NoContent();
            }).RequireAuthorization();
        }
    }

}

using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using University.Manager.Project.Financial.Application.Interfaces;
using University.Manager.Project.Financial.Application.Models.Error;

namespace University.Manager.Project.Financial.Api.Endpoints
{
    public abstract class BaseEndpoints<TModel, TRequestDTO, TService, TValidator>
     where TModel : class
     where TRequestDTO : class, IBaseModel
     where TService : class, IBaseService<TModel, TRequestDTO>
     where TValidator : IValidator<TRequestDTO>
    {
        protected abstract string BaseRoute { get; }

        public virtual void MapEndpoints(WebApplication app)
        {
            var group = app.MapGroup(BaseRoute).RequireAuthorization();

            group.MapGet("", async ([FromServices] TService _service) =>
            {
                IEnumerable<TModel> listModel = await _service.GetAllAsync();
                if (listModel != null && listModel.Any())
                    return Results.Ok(listModel);
                return Results.NoContent();
            });

            group.MapGet("/{id:long}", async ([FromRoute] long id, [FromServices] TService _service) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new CustomValidationFailure("Id", "Invalid Id!").ToList());

                TModel modelFound = await _service.GetByIdAsync(id);
                if (modelFound != null)
                    return Results.Ok(modelFound);
                return Results.NotFound();
            });

            group.MapPost("", async ([FromBody] TRequestDTO model, [FromServices] TService _service, [FromServices] TValidator _validator) =>
            {
                if (model == null)
                    return Results.BadRequest("Invalid Data!");

                FluentValidation.Results.ValidationResult validationModel = _validator.Validate(model);
                if (!validationModel.IsValid)
                    return Results.BadRequest(validationModel.Errors.ToCustomValidationFailure());

                await _service.CreateModelAsync(model);
                return Results.Created($"{BaseRoute}/{model.Id}", model);
            });

            group.MapPut("", async ([FromBody] TRequestDTO model, [FromServices] TService _service, [FromServices] TValidator _validator) =>
            {
                TModel modelFound = await _service.GetByIdAsync(model.Id);
                if (modelFound == null)
                    return Results.NotFound(new CustomValidationFailure("Id", "Id not found!").ToList());

                FluentValidation.Results.ValidationResult validationModel = _validator.Validate(model);
                if (!validationModel.IsValid)
                    return Results.BadRequest(validationModel.Errors.ToCustomValidationFailure());

                await _service.UpdateModelAsync(model);
                return Results.NoContent();
            });

            group.MapDelete("/{id:long}", async ([FromRoute] long id, [FromServices] TService _service) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new CustomValidationFailure("Id", "Invalid Id!").ToList());

                TModel modelFound = await _service.GetByIdAsync(id);
                if (modelFound == null)
                    return Results.NotFound(new CustomValidationFailure("Id", "Id not found!").ToList());

                await _service.DeleteModelAsync(modelFound);
                return Results.Ok(modelFound);
            });

            group.MapDelete("", async ([FromBody] IEnumerable<long> ids, [FromServices] TService _service) =>
            {
                if (!ids.Any())
                    return Results.BadRequest(new CustomValidationFailure("Id", "Invalid Id!").ToList());

                await _service.DeleteMultipleAsync(ids);
                return Results.Ok(ids);
            });
        }
    }

}

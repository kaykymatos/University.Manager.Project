using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using University.Manager.Project.Order.Application.Interfaces;
using University.Manager.Project.Order.Application.Models.Error;

namespace University.Manager.Project.Order.Api.Endpoints
{
    public abstract class BaseEndpoints<TModel, TRequestDTO, TService, TValidator>
     where TModel : class
     where TRequestDTO : class, IBaseModel
     where TService : class, IBaseService<TModel, TRequestDTO>
     where TValidator : IValidator<TRequestDTO>
    {
        protected abstract string BaseRoute { get; }

        public virtual void MapGetAll(WebApplication app)
        {
            app.MapGet(BaseRoute, async ([FromServices] TService _service) =>
            {
                IEnumerable<TModel> listModel = await _service.GetAllAsync();
                if (listModel != null && listModel.Any())
                    return Results.Ok(listModel);
                return Results.NoContent();
            }).RequireAuthorization();
        }
        public virtual void MapGetById(WebApplication app)
        {
            app.MapGet($"{BaseRoute}/{{id:long}}", async ([FromRoute] long id, [FromServices] TService _service) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new CustomValidationFailure("Id", "Invalid Id!").ToList());

                TModel modelFound = await _service.GetByIdAsync(id);
                if (modelFound != null)
                    return Results.Ok(modelFound);
                return Results.NotFound();
            }).RequireAuthorization();
        }
        public virtual void MapPost(WebApplication app)
        {
            app.MapPost(BaseRoute, async ([FromBody] TRequestDTO model, [FromServices] TService _service, [FromServices] TValidator _validator) =>
            {
                if (model == null)
                    return Results.BadRequest("Invalid Data!");

                FluentValidation.Results.ValidationResult validationModel = _validator.Validate(model);
                if (!validationModel.IsValid)
                    return Results.BadRequest(validationModel.Errors.ToCustomValidationFailure());

                await _service.CreateModelAsync(model);
                return Results.Created($"{BaseRoute}/{model.Id}", model);
            }).RequireAuthorization();
        }
        public virtual void MapPut(WebApplication app)
        {
            app.MapPut(BaseRoute, async ([FromBody] TRequestDTO model, [FromServices] TService _service, [FromServices] TValidator _validator) =>
            {
                TModel modelFound = await _service.GetByIdAsync(model.Id);
                if (modelFound == null)
                    return Results.NotFound(new CustomValidationFailure("Id", "Id not found!").ToList());

                FluentValidation.Results.ValidationResult validationModel = _validator.Validate(model);
                if (!validationModel.IsValid)
                    return Results.BadRequest(validationModel.Errors.ToCustomValidationFailure());

                await _service.UpdateModelAsync(model);
                return Results.NoContent();
            }).RequireAuthorization();
        }
        public virtual void MapDelete(WebApplication app)
        {
            app.MapDelete($"{BaseRoute}/{{id:long}}", async ([FromRoute] long id, [FromServices] TService _service) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new CustomValidationFailure("Id", "Invalid Id!"));

                TModel modelFound = await _service.GetByIdAsync(id);
                if (modelFound == null)
                    return Results.NotFound(new CustomValidationFailure("Id", "Id not found!"));

                await _service.DeleteModelAsync(modelFound);
                return Results.Ok(modelFound);
            }).RequireAuthorization();
        }
        public virtual void MapDeleteMultiply(WebApplication app)
        {
            app.MapDelete(BaseRoute, async ([FromBody] IEnumerable<long> ids, [FromServices] TService _service) =>
            {
                if (!ids.Any())
                    return Results.BadRequest(new CustomValidationFailure("Id", "Invalid Id!"));

                await _service.DeleteMultipleAsync(ids);
                return Results.Ok(ids);
            }).RequireAuthorization();
        }
        public virtual void MapEndpoints(WebApplication app)
        {
            MapGetAll(app);
            MapGetById(app);
            MapPost(app);
            MapPut(app);
            MapDelete(app);
            MapDeleteMultiply(app);
        }
    }

}

using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using University.Manager.Project.Order.Application.DTOs.RequestDTOs;
using University.Manager.Project.Order.Application.Interfaces;
using University.Manager.Project.Order.Application.Models.Error;

namespace University.Manager.Project.Order.Api.Endpoints.V1
{
    public static class OrderEndpoints
    {
        public static WebApplication MapOrderEndpoints(this WebApplication app)
        {
            app.MapGet("api/v1/order", async ([FromServices] IOrderService _service) =>
            {
                var listModel = await _service.GetAllAsync();
                if (listModel.Any())
                    return Results.Ok(listModel);
                return Results.NoContent();
            });
            app.MapGet("api/v1/order/{id:long}", async ([FromRoute] long id, [FromServices] IOrderService _service) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new CustomValidationFailure("Id", "Invalid Id!").ToList());

                var modelFound = await _service.GetByIdAsync(id);
                if (modelFound != null)
                    return Results.Ok(modelFound);
                return Results.NotFound();
            }).WithName("order");

            app.MapPost("api/v1/order", async ([FromBody] OrderEntityRequestDTO model, [FromServices] IOrderService _service, [FromServices] IValidator<OrderEntityRequestDTO> _validator) =>
            {
                if (model == null)
                    return Results.BadRequest("Invalid Data!");

                var validationModel = _validator.Validate(model);
                if (!validationModel.IsValid)
                    return Results.BadRequest(validationModel.Errors.ToCustomValidationFailure());

                await _service.CreateModelAsync(model);
                return Results.CreatedAtRoute("order", new { id = model.Id }, model);
            });

            app.MapPut("api/v1/order", async ([FromBody] OrderEntityRequestDTO model, [FromServices] IOrderService _service, [FromServices] IValidator<OrderEntityRequestDTO> _validator) =>
            {
                var modelFound = await _service.GetByIdAsync(model.Id);
                if (modelFound == null)
                    return Results.NotFound(
                        new CustomValidationFailure("Id", "Id not found!").ToList());

                var validationModel = _validator.Validate(model);
                if (!validationModel.IsValid)
                    return Results.BadRequest(validationModel.Errors.ToCustomValidationFailure());

                await _service.UpdateModelAsync(model);
                return Results.NoContent();
            });
            app.MapDelete("api/v1/order/{id:long}", async ([FromRoute] long id, [FromServices] IOrderService _service) =>
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

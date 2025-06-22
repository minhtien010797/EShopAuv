
using Catalog.API.Products.CreateProduct;
using Catalog.API.Products.UpdateProduct;
using MediatR;
using static Catalog.API.Products.UpdateProduct.UpdateProductEndPoint;

namespace Catalog.API.Products.DeleteProduct
{
    public class DeleteProductEndPoint : ICarterModule
    {
        public record DeleteProductResponse(bool IsSuccess);

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id:guid}",async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteProductCommand(id));

                var response = result.Adapt<DeleteProductResponse>();
                return Results.Ok(response);
            })
            .WithName("DeleteProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Product")
            .WithDescription("Delete Product"); ;
        }
    }
}

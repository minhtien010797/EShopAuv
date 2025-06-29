using Catalog.API.Exception;

namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

    public record GetProductByIdResult(Product Products);

    public class GetProductByIdQueryHandler (IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger) 
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling GetProductByIdQuery: {@Query}", query);
            // Create entity
            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);
            if (product == null)
            { 
                throw new ProductNotFoundException(query.Id);
            }
            // Return result
            return new GetProductByIdResult(product);
        }
    }
}

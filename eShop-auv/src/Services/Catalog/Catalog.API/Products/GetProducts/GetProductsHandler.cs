﻿namespace Catalog.API.Products.GetProduct
{
    public record GetProductsQuery() : IQuery<GetProductsResult>;

    public record GetProductsResult(IEnumerable<Product> Products);

    internal class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger)
        : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling GetProductsQuery: {@Command}", query);

            // Create entity
            var products = await session.Query<Product>()
                .ToListAsync(cancellationToken);

            // Return result
            return new GetProductsResult(products);
        }
    }
}

namespace Catalog.API.Products.GetProduct
{
    public record GetProductsQuery() : IQuery<GetProductsResult>;

    public record GetProductsResult(IEnumerable<Product> Products);

    internal class GetProductsQueryHandler(IDocumentSession session)
        : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            // Create entity
            var products = await session.Query<Product>()
                .ToListAsync(cancellationToken);

            // Return result
            return new GetProductsResult(products);
        }
    }
}

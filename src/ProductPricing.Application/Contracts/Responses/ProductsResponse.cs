namespace ProductPricing.Application.Contracts.Responses;

public class ProductsResponse
{
    public ProductsResponse()
    {
    }

    public ProductsResponse(IEnumerable<ProductResponse> products)
    {
        Products = products;
    }

    public IEnumerable<ProductResponse> Products { get; init; } = Enumerable.Empty<ProductResponse>();
}
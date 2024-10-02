using ProductPricing.Application.Models.Domain;

namespace ProductPricing.Application.UnitTests.Services;

public class ProductPricingServiceTests
{
    private readonly ProductPricingService _sut = new();
        
    [Theory]
    [InlineData(1, true)]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(4, false)]
    [InlineData(5, true)]
    [InlineData(6, false)]    
    public void CheckProductExists_ShouldReturnExpectedResult(int id, bool expectedResult)
    {
        //act
        var result = _sut.CheckProductExists(id);
        
        //assert
        Assert.Equal(expectedResult, result);
    }
}

internal class ProductPricingService : IProductPricingService
{
    private readonly IEnumerable<ProductPricingModel> _productPrices = new []
    {
        new ProductPricingModel
        {
            Id = 1,
            Name = "Product A",
            CurrentPrice = 100.0M,
            LastUpdated = DateTime.UtcNow,
        },
        new ProductPricingModel
        {
            Id = 2,
            Name = "Product B",
            CurrentPrice = 110.0M,
            LastUpdated = DateTime.UtcNow,
        },
        new ProductPricingModel
        {
            Id = 3,
            Name = "Product C",
            CurrentPrice = 120.0M,
            LastUpdated = DateTime.UtcNow,
        },
        new ProductPricingModel
        {
            Id = 5,
            Name = "Product E",
            CurrentPrice = 130.0M,
            LastUpdated = DateTime.UtcNow,
        },         
    };
    
    public bool CheckProductExists(int id)
    {
        return _productPrices.Any(p => p.Id == id);
    }
}

internal interface IProductPricingService
{
    bool CheckProductExists(int id);
}
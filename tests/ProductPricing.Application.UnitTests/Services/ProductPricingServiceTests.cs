using ProductPricing.Application.Services;

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
    public void CheckProductExists_ShouldReturnExpectedResult(int productId, bool expectedResult)
    {
        //act
        var result = _sut.CheckProductExists(productId);
        
        //assert
        Assert.Equal(expectedResult, result);
    }
}




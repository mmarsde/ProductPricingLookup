namespace ProductPricing.Application.UnitTests.Services;

public class ProductPricingServiceTests
{
    private readonly ProductPricingService _sut = new();
        
    [Theory]
    [InlineData(1, true)]
    [InlineData(2, false)]
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
    public bool CheckProductExists(int id)
    {
        return id == 1;
    }
}

internal interface IProductPricingService
{
    bool CheckProductExists(int id);
}
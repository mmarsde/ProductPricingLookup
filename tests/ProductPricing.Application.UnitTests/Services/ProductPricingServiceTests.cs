namespace ProductPricing.Application.UnitTests.Services;

public class ProductPricingServiceTests
{
    private readonly ProductPricingService _sut = new();
        
    [Fact]
    public void CheckProductExists_ShouldReturnTrue()
    {
        //arrange
        var id = 1;
        var expectedResult = true;
        
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
        return true;
    }
}

internal interface IProductPricingService
{
    bool CheckProductExists(int id);
}
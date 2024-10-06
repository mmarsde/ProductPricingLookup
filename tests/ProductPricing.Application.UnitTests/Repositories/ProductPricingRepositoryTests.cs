using FluentAssertions;
using ProductPricing.Application.Models.Domain;
using ProductPricing.Application.Repositories;
using ProductPricing.Application.UnitTests.TestData;

namespace ProductPricing.Application.UnitTests.Repositories;

public class ProductPricingRepositoryTests
{
    private readonly ProductPricingRepository _productPricingRepository;
    
    public ProductPricingRepositoryTests()
    {
        _productPricingRepository = new ProductPricingRepository();
    }
    
    [Theory]
    [ClassData(typeof(UpdatedProductPriceTestDataGenerator))]
    public async Task UpdateProductPriceAsync_ShouldUpdateProductPrice(int productId, PriceModel newPrice, ProductPricingModel expectedResult)
    {
        //act 
        var result = await _productPricingRepository.UpdateProductPriceAsync(productId, newPrice);
        
        //assert
        result.Should().BeEquivalentTo(expectedResult);
    }
    
    [Theory]
    [ClassData(typeof(NotFoundProductPriceTestDataGenerator))]
    public async Task UpdateProductPriceAsync_ShouldReturnNull_WhenProductNotFound(int productId, PriceModel newPrice)
    {
        //act 
        var result = await _productPricingRepository.UpdateProductPriceAsync(productId, newPrice);
        
        //assert
        result.Should().BeNull();
    }
}
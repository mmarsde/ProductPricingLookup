using FluentAssertions;
using NSubstitute;
using ProductPricing.Application.Contracts.Responses;
using ProductPricing.Application.Models.Domain;
using ProductPricing.Application.Services;
using ProductPricing.Application.Repositories;
using ProductPricing.Application.UnitTests.TestData;

namespace ProductPricing.Application.UnitTests.Services;

public class ProductPricingServiceTests
{
    private readonly IProductPricingRepository _productPricingRepository;
    private readonly ProductPricingService _productPricingService;
    
    public ProductPricingServiceTests()
    {
        _productPricingRepository = Substitute.For<IProductPricingRepository>();
        _productPricingService = new ProductPricingService(_productPricingRepository);
    }

    [Theory]
    [InlineData(1)]
    public async Task GetProductPricingByIdAsync_ShouldReturnNull_WhenNoProductPricesFound(int productId)
    {
        //arrange
        
        //act
        var result = await _productPricingService.GetProductPricingByIdAsync(productId);
        
        //assert
        result.Should().BeNull();
    }
    
    
    [Theory]
    [ClassData(typeof(ProductPricingTestDataGenerator))]
    public async Task GetProductPricingByIdAsync_ShouldReturnExpectedResult(int productId, ProductPricingModel repositoryResult, ProductPricingResponse expectedResult)
    {
        //arrange
        _productPricingRepository.GetProductPricingByIdAsync(productId).Returns(repositoryResult);
        
        //act
        var result = await _productPricingService.GetProductPricingByIdAsync(productId);
        
        //assert
        result.Should().BeEquivalentTo(expectedResult);
    }
}




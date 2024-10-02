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

    [Fact]
    public void GetAllProductsAsync_ReturnsNothingIfNoProducts()
    {
        //arrange
        var expectedResponse = new ProductsResponse
        {
            Products = Enumerable.Empty<ProductResponse>()
        };
        
        //act
        var result = _productPricingService.GetAllProductsAsync();

        //assert
        result.Result.Should().BeEquivalentTo(expectedResponse);
    }

    [Theory]
    [ClassData(typeof(ProductsTestDataGenerator))]
    public async Task GetAllProductsAsync_ReturnsExpectedResult(IEnumerable<ProductPricingModel> expectedProducts, ProductsResponse expectedResponse)
    {
        //arrange
        _productPricingRepository.GetAllProductsAsync().Returns(expectedProducts);
        
        //act
        var response = await _productPricingService.GetAllProductsAsync();
        
        //assert
        response.Should().BeEquivalentTo(expectedResponse);
    }

    [Fact]
    public async Task GetProductPricingByIdAsync_ShouldReturnNull_WhenNoProductPricesFound()
    {
        //arrange
        var productId = 1;
        
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




using FluentAssertions;
using NSubstitute;
using ProductPricing.Application.Contracts.Requests;
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
    public async Task GetAllProductsAsync_ShouldReturnNothing_WhenNoProductsFound()
    {
        //arrange
        var expectedResult = new ProductsResponse
        {
            Products = Enumerable.Empty<ProductResponse>()
        };
        
        //act
        var result = await _productPricingService.GetAllProductsAsync();
        
        //assert
        await _productPricingRepository.Received(1).GetAllProductsAsync();
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Theory]
    [ClassData(typeof(ProductsTestDataGenerator))]
    public async Task GetAllProductsAsync_ShouldReturnExpectedResult(IEnumerable<ProductPricingModel> expectedProducts, ProductsResponse expectedResult)
    {
        //arrange
        _productPricingRepository.GetAllProductsAsync().Returns(expectedProducts);
        
        //act
        var result = await _productPricingService.GetAllProductsAsync();
        
        //assert
        await _productPricingRepository.Received(1).GetAllProductsAsync();
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Theory]
    [InlineData(1)]
    public async Task GetProductPricingByIdAsync_ShouldReturnNull_WhenNoProductPricesFound(int productId)
    {
        //act
        var result = await _productPricingService.GetProductPricingByIdAsync(productId);

        //assert
        await _productPricingRepository.Received(1).GetProductPricingByIdAsync(Arg.Is(productId));
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
        await _productPricingRepository.Received(1).GetProductPricingByIdAsync(Arg.Is(productId)); 
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Theory]
    [ClassData(typeof(DiscountTestDataGenerator))]
    public async Task ApplyDiscountAsync_ShouldReturnExpectedResult(int productId, ProductPricingModel repositoryResult, DiscountRequest request, decimal expectedResult)
    {
        //arrange 
        _productPricingRepository.GetProductPricingByIdAsync(productId).Returns(repositoryResult);
        
        //act
        var result = await _productPricingService.ApplyDiscountAsync(productId, request);
        
        //assert
        await _productPricingRepository.Received(1).GetProductPricingByIdAsync(Arg.Is(productId)); 
        result.DiscountedPrice.Should().Be(expectedResult);
    }

    [Theory]
    [ClassData(typeof(DiscountRequestsTestDataGenerator))]
    public async Task ApplyDiscountAsync_ShouldReturnNull_WhenProductDoesNotExist(int productId, DiscountRequest request)
    {
        //act 
        var result = await _productPricingService.ApplyDiscountAsync(productId, request);
        
        //assert
        await _productPricingRepository.Received(1).GetProductPricingByIdAsync(Arg.Is(productId));
        result.Should().BeNull();
    }

    [Theory]
    [ClassData(typeof(InvalidDiscountRequestsTestDataGenerator))]
    public async Task ApplyDiscountAsync_ThrowsArgumentException_WhenDiscountIsInvalid(int productId,
        DiscountRequest request)
    {
        //act
        var act = async () => await _productPricingService.ApplyDiscountAsync(productId, request);
        
        //assert
        await act.Should().ThrowAsync<ArgumentException>().WithMessage($"Discount percentage must be between 1 and 100. (Parameter '{nameof(request)}')");
    }
}
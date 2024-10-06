using FluentAssertions;
using ProductPricing.Application.Mappers.Extensions;
using ProductPricing.Application.Models.Domain;

namespace ProductPricing.Application.UnitTests.Mappers;

public class ProductPricingModelExtensionsTests
{
    [Theory]
    [InlineData(1, "Product A", 2)]
    public void MapToProductPricingResponse_ShouldMapCorrectly(int expectedProductId, string expectedProductName, int expectPriceHistoryCount)
    {
        // Arrange
        var productPricingModel = new ProductPricingModel
        {
            Id = 1,
            Name = "Product A",
            CurrentPrice = 110M,
            LastUpdated = DateTime.UtcNow,
            PriceHistory = 
            [
                new PriceModel()
                {
                    Price = 150.0m,
                    CreateDateTime = DateTime.UtcNow.AddDays(-5)
                },

                new PriceModel()
                {
                    Price = 100.0m,
                    CreateDateTime = DateTime.UtcNow.AddDays(-10)
                }
            ]
        };

        // Act
        var result = productPricingModel.MapToProductPricingResponse();

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(expectedProductId);
        result.Name.Should().Be(expectedProductName);
        result.PriceHistory.Should().HaveCount(expectPriceHistoryCount);
    }

    [Theory]
    [InlineData(2, "Product A", 110, "Product B", 220)]
    public void MapToProductsResponse_ShouldMapCorrectly(int expectedProductsCount, string expectedFirstProduct, decimal expectedFirstPrice, string expectedLastProduct, decimal expectedLastPrice)
    {
        // Arrange
        var productPricingModels = new List<ProductPricingModel>
        {
            new()
            {
                Id = 1, 
                Name = "Product A", 
                CurrentPrice = 110M, 
                LastUpdated = DateTime.UtcNow
            },
            new()
            {
                Id = 2, 
                Name = "Product B", 
                CurrentPrice = 220m, 
                LastUpdated = DateTime.UtcNow
            }
        };

        // Act
        var result = productPricingModels.MapToProductsResponse();
        
        // Assert
        result.Should().NotBeNull();
        result.Products.Should().HaveCount(expectedProductsCount);
        result.Products.First().Name.Should().Be(expectedFirstProduct);
        result.Products.First().CurrentPrice.Should().Be(expectedFirstPrice);
        result.Products.Last().Name.Should().Be(expectedLastProduct);        
        result.Products.Last().CurrentPrice.Should().Be(expectedLastPrice);
    }
    
    [Theory]
    [InlineData(1, "Product A", 300, 250)]
    public void MapToDiscountResponse_ShouldMapCorrectly(int expectedProductId, string expectedProductName, decimal expectedOriginalPrice, int expectedDiscountPrice)
    {
        // Arrange
        var productPricingModel = new ProductPricingModel
        {
            Id = 1,
            Name = "Product A",
            CurrentPrice = 300M, 
            LastUpdated = DateTime.UtcNow
        };

        // Act
        var result = productPricingModel.MapToDiscountResponse(expectedDiscountPrice);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(expectedProductId);
        result.Name.Should().Be(expectedProductName);
        result.OriginalPrice.Should().Be(expectedOriginalPrice);
        result.DiscountedPrice.Should().Be(expectedDiscountPrice);
    }
 
    [Theory]
    [InlineData(1, "Product A", 400)]
    public void MapToNewPriceResponse_ShouldMapCorrectly(int expectedProductPriceId, string expectedProductName, decimal expectedProductPrice)
    {
        // Arrange
        var productPricingModel = new ProductPricingModel
        {
            Id = 1,
            Name = "Product A",
            CurrentPrice = 400.0m,
            LastUpdated = DateTime.UtcNow.AddDays(-5)
        };

        // Act
        var result = productPricingModel.MapToNewPriceResponse();

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(expectedProductPriceId);
        result.Name.Should().Be(expectedProductName);
        result.NewPrice.Should().Be(expectedProductPrice);
        result.LastUpdated.Should().Be(productPricingModel.LastUpdated);
    }
}

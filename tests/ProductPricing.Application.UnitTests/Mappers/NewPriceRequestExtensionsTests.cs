using FluentAssertions;
using ProductPricing.Application.Contracts.Requests;
using ProductPricing.Application.Mappers.Extensions;

namespace ProductPricing.Application.UnitTests.Mappers;

public class NewPriceRequestExtensionsTests
{
    [Theory]
    [InlineData(150)]
    public void MapToPriceModel_ShouldMapCorrectly_WhenRequestIsValid(decimal expectedPrice)
    {
        // Arrange
        var request = new NewPriceRequest
        {
            NewPrice = 150.0m
        };

        // Act
        var result = request.MapToPriceModel();

        // Assert
        result.Should().NotBeNull();
        result.Price.Should().Be(expectedPrice);
        result.CreateDateTime.Should().BeCloseTo(DateTime.UtcNow, precision: TimeSpan.FromSeconds(1));
    }
}
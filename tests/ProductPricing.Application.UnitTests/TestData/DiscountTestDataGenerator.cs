using System.Collections;
using ProductPricing.Application.Contracts.Requests;
using ProductPricing.Application.Models.Domain;

namespace ProductPricing.Application.UnitTests.TestData;

internal sealed class DiscountTestDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return
        [
            1,
            new ProductPricingModel
            {
                Id = 1,
                Name = "Product A",
                CurrentPrice = 100M,
                LastUpdated = new DateTime(2024, 09, 26, 12, 34, 56),
                PriceHistory = []
            },
            new DiscountRequest
            {
                DiscountPercentage = 10 
            },
            90M
        ];
        yield return
        [
            3,
            new ProductPricingModel
            {
                Id = 3,
                Name = "Product C",
                CurrentPrice = 125.95M,
                LastUpdated = new DateTime(2024, 09, 26, 12, 34, 56),
                PriceHistory = []
            },
            new DiscountRequest
            {
                DiscountPercentage = 5 
            },
            119.65M
        ];        
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
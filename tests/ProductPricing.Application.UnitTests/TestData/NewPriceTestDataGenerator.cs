using System.Collections;
using ProductPricing.Application.Contracts.Responses;
using ProductPricing.Application.Models.Domain;

namespace ProductPricing.Application.UnitTests.TestData;

internal sealed class NewPriceTestDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return 
        [
            1,
            new PriceModel
            {
                Price = 115.0M,
                CreateDateTime = new DateTime(2024, 10, 05, 14, 56, 24)
            },
            new ProductPricingModel
            {
                Id = 1,
                Name = "Product A",
                CurrentPrice  = 100.0M,
                LastUpdated = new DateTime(2024, 09, 26, 12, 34, 56),
                PriceHistory = new List<PriceModel>
                    {
                        new()
                        {
                            Price = 120.0M,
                            CreateDateTime = new DateTime(2024, 09, 01, 00, 00, 00),
                        },
                        new()
                        {
                            Price = 110.0M,
                            CreateDateTime = new DateTime(2024, 08, 15, 00, 00, 00),
                        },
                        new()
                        {
                            Price = 100.0M,
                            CreateDateTime = new DateTime(2024, 08, 10, 00, 00, 00),
                        },                     
                    }
            },
            new NewPriceResponse
            {
                Id = 1,
                Name = "Product A",
                NewPrice = 115.0M,
                LastUpdated = new DateTime(2024, 10, 05, 14, 56, 24)
            }
        ];     
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
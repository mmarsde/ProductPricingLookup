using System.Collections;
using ProductPricing.Application.Contracts.Responses;
using ProductPricing.Application.Models.Domain;

namespace ProductPricing.Application.UnitTests.TestData;

internal sealed class ProductPricingTestDataGenerator : IEnumerable<object[]>
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
                CurrentPrice = 100.0M,
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
            new ProductPricingResponse
            {
                Id = 1,
                Name = "Product A",
                CurrentPrice = 100.0M,
                LastUpdatedDateTime = new DateTime(2024, 09, 26, 12, 34, 56),
                PriceHistory = new List<PriceResponse>
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
                    new ()
                    {
                        Price = 100.0M,
                        CreateDateTime = new DateTime(2024, 08, 10, 00, 00, 00),
                    }
                }
            }
        ];
        yield return
        [
            2,
            new ProductPricingModel
            {
                Id = 2,
                Name = "Product B",
                CurrentPrice = 200.0M,
                LastUpdated = new DateTime(2024, 09, 25, 10, 12, 34),
                PriceHistory = Enumerable.Empty<PriceModel>().ToList(),
            },
            new ProductPricingResponse
            {
                Id = 2,
                Name = "Product B",
                CurrentPrice = 200.0M,
                LastUpdatedDateTime = new DateTime(2024, 09, 25, 10, 12, 34),
                PriceHistory = Enumerable.Empty<PriceResponse>().ToList(),
            }
        ];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
using System.Collections;
using ProductPricing.Application.Contracts.Responses;
using ProductPricing.Application.Models.Domain;

namespace ProductPricing.Application.UnitTests.TestData;

internal sealed class ProductsTestDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return
        [
            new List<ProductPricingModel>()
            {
                new()
                {
                    Id = 1,
                    Name = "Product A",
                    CurrentPrice = 100.0M,
                    LastUpdated = new DateTime(2024, 09, 26, 12, 34, 56),
                    PriceHistory =
                    [
                        new PriceModel
                        {
                            Price = 120.0M,
                            CreateDateTime = new DateTime(2024, 09, 01, 00, 00, 00),
                        },

                        new PriceModel
                        {
                            Price = 110.0M,
                            CreateDateTime = new DateTime(2024, 08, 15, 00, 00, 00),
                        },

                        new PriceModel
                        {
                            Price = 100.0M,
                            CreateDateTime = new DateTime(2024, 08, 10, 00, 00, 00),
                        }

                    ]
                },
                new()
                {
                    Id = 2,
                    Name = "Product B",
                    CurrentPrice = 200.0M,
                    LastUpdated = new DateTime(2024, 09, 25, 10, 12, 34),
                    PriceHistory = Enumerable.Empty<PriceModel>(),
                },
            },
            new ProductsResponse
            {
                Products =
                [
                    new ProductResponse
                    {
                        Id = 1,
                        Name = "Product A",
                        CurrentPrice = 100.0M,
                        LastUpdatedDateTime = new DateTime(2024, 09, 26, 12, 34, 56)
                    },
                    new ProductResponse
                    {
                        Id = 2,
                        Name = "Product B",
                        CurrentPrice = 200.0M,
                        LastUpdatedDateTime = new DateTime(2024, 09, 25, 10, 12, 34)
                    }
                ]
            }
        ];
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
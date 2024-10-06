using System.Collections;
using ProductPricing.Application.Models.Domain;

namespace ProductPricing.Application.UnitTests.TestData;

internal sealed class UpdatedProductPriceTestDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return 
        [
            1,
            new PriceModel
            {
                CreateDateTime = new DateTime(2024, 10, 06, 10, 00, 00),
                Price = 160M
            },
            new ProductPricingModel()
            {
                Id = 1,
                Name = "Product A",
                CurrentPrice = 160M,
                LastUpdated = new DateTime(2024, 10, 06, 10, 00, 00),
                PriceHistory = new List<PriceModel>
                {
                    new()
                    {
                        Price = 100.0M,
                        CreateDateTime = new DateTime(2024, 09, 26, 12, 34, 56),
                    },
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
        ];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
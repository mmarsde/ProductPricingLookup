using System.Collections;
using ProductPricing.Application.Models.Domain;

namespace ProductPricing.Application.UnitTests.TestData;

public class NotFoundProductPriceTestDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return [
            4,
            new PriceModel
            {
                CreateDateTime = DateTime.UtcNow,
                Price = 140M
            }
        ];
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
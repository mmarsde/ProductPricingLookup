using System.Collections;
using ProductPricing.Application.Models.Domain;

namespace ProductPricing.Application.UnitTests.TestData;

internal sealed class PriceModelTestDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return 
        [
            1,
            new PriceModel
            {
                CreateDateTime = DateTime.UtcNow,
                Price = 100M
            }
        ];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
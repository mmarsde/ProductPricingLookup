using System.Collections;
using ProductPricing.Application.Contracts.Requests;

namespace ProductPricing.Application.UnitTests.TestData;

internal sealed class DiscountRequestsTestDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return 
        [
            1,
            new DiscountRequest
            {
             DiscountPercentage = 10
            }
        ];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
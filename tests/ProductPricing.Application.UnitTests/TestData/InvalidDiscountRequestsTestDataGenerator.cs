using System.Collections;
using ProductPricing.Application.Contracts.Requests;

namespace ProductPricing.Application.UnitTests.TestData;

internal class InvalidDiscountRequestsTestDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return
        [
            1,
            new DiscountRequest
            {
                DiscountPercentage = 0
            }
        ];
        yield return
        [
            2,
            new DiscountRequest
            {
                DiscountPercentage = -10
            }
        ];
        yield return
        [
            3,
            new DiscountRequest
            {
                DiscountPercentage = 101
            }
        ];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

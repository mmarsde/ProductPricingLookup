using System.ComponentModel.DataAnnotations;

namespace ProductPricing.Application.Contracts.Requests;

public class NewPriceRequest
{
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The price can only contain 2 decimal places.")]
    [Range(0, 9999999999999999.99, ErrorMessage = "The price must be a positive number.")]
    public required decimal NewPrice { get; init; }
}
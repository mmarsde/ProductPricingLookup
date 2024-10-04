using System.ComponentModel.DataAnnotations;

namespace ProductPricing.Application.Contracts.Requests;

public class DiscountRequest
{
    [Range(1, 100, ErrorMessage = "The discount percentage must be between 1 and 100")]
    public required int DiscountPercentage { get; init; }
}
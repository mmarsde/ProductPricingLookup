using Microsoft.AspNetCore.Mvc;
using ProductPricing.Application.Contracts.Responses;
using ProductPricing.Application.Services;

namespace ProductPricing.Api.Controllers;

[ApiController]
[Route("api")]
public class ProductsController : ControllerBase
{
    private readonly IProductPricingService _productPricingService;
    
    public ProductsController(ILogger<ProductsController> logger, IProductPricingService productPricingService)
    {
        _productPricingService = productPricingService ?? throw new ArgumentNullException(nameof(productPricingService));
    }

    [HttpGet("products")]
    [ProducesResponseType(typeof(ProductsResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllProducts()
    {
        var response = await _productPricingService.GetAllProductsAsync();
        return Ok(response);
    }
    
    [HttpGet("products/{id:int}")]
    [ProducesResponseType(typeof(ProductPricingResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductById([FromRoute] int id)
    {
        var response = await _productPricingService.GetProductPricingByIdAsync(id);

        if (response is null)
        {
            return NotFound();
        }
        
        return Ok(response);
    }
}
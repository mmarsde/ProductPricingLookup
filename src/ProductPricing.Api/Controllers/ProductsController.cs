using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using ProductPricing.Application.Contracts.Requests;
using ProductPricing.Application.Contracts.Responses;
using ProductPricing.Application.Mappers.Extensions;
using ProductPricing.Application.Services;

namespace ProductPricing.Api.Controllers;

[ApiController]
[Route("api")]
public class ProductsController : ControllerBase
{
    private readonly IProductPricingService _productPricingService;
    
    public ProductsController(IProductPricingService productPricingService)
    {
        _productPricingService = productPricingService ?? throw new ArgumentNullException(nameof(productPricingService));
    }

    [HttpGet("products")]
    [ProducesResponseType(typeof(ProductsResponse), StatusCodes.Status200OK)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetAllProducts()
    {
        var response = await _productPricingService.GetAllProductsAsync();
        return Ok(response);
    }
    
    [HttpGet("products/{id:int}")]
    [ProducesResponseType(typeof(ProductPricingResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetProductById([FromRoute]int id)
    {
        var response = await _productPricingService.GetProductPricingByIdAsync(id);

        if (response is null)
        {
            return NotFound();
        }
        
        return Ok(response);
    }

    [HttpPost("products/{id:int}/discounts")]
    [ProducesResponseType(typeof(DiscountResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Apply([FromRoute] int id, [FromBody]DiscountRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var response = await _productPricingService.ApplyDiscountAsync(id, request);

        if (response is null)
        {
            return NotFound();
        }
        
        return Ok(response);
    }
    
    [HttpPut("products/{id:int}/prices")]
    [ProducesResponseType(typeof(NewPriceResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]    
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody]NewPriceRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var priceModel = request.MapToPriceModel();
        
        var response = await _productPricingService.UpdatePriceAsync(id, priceModel);
        if (response is null)
        {
            return NotFound();
        }
        
        return Ok(response);
    }
}
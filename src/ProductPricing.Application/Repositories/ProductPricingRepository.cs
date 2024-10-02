using ProductPricing.Application.Models.Domain;

namespace ProductPricing.Application.Repositories;

public class ProductPricingRepository : IProductPricingRepository
{
    private readonly IEnumerable<ProductPricingModel> _productPricingModels = SeedProductPricingModels();

    public Task<ProductPricingModel> GetProductPricingByIdAsync(int id)
    {
        return Task.FromResult(_productPricingModels.FirstOrDefault(x => x.Id == id));
    }

    public Task<IEnumerable<ProductPricingModel>> GetAllProductsAsync()
    {
        return Task.FromResult(_productPricingModels);
    }
    
    private static IEnumerable<ProductPricingModel> SeedProductPricingModels() => 
        [
            new()
            {
                Id = 1,
                Name = "Product A",
                CurrentPrice = 100.0M,
                LastUpdated = new DateTime(2024, 09, 26, 12, 34, 56),
                PriceHistory = new List<PriceModel>
                {
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
            new()
            {
                Id = 2,
                Name = "Product B",
                CurrentPrice = 200.0M,
                LastUpdated = new DateTime(2024, 09, 25, 10, 12, 34),
                PriceHistory = Enumerable.Empty<PriceModel>().ToList(),
            }
        ];
}
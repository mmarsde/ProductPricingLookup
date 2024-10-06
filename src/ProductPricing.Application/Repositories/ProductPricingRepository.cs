using ProductPricing.Application.Models.Domain;

namespace ProductPricing.Application.Repositories;

public class ProductPricingRepository : IProductPricingRepository
{
    private static readonly List<ProductPricingModel> _productPricingModels = SeedProductPricingModels();

    public Task<ProductPricingModel> GetProductPricingByIdAsync(int id)
    {
        return Task.FromResult(_productPricingModels.FirstOrDefault(x => x.Id == id));
    }

    public Task<IEnumerable<ProductPricingModel>> GetAllProductsAsync()
    {
        return Task.FromResult(_productPricingModels.AsEnumerable());
    }

    public Task<ProductPricingModel> UpdateProductPriceAsync(int productId, PriceModel priceModel)
    {
        var productPriceModel = _productPricingModels.FirstOrDefault(x => x.Id == productId);
        if (productPriceModel is null)
        {
            return null;
        }

        var priceHistory = UpdatePriceHistory(productPriceModel);

        UpdateProductPriceModel(priceModel, productPriceModel, priceHistory);

        return Task.FromResult(productPriceModel);
    }

    private static void UpdateProductPriceModel(PriceModel priceModel, ProductPricingModel productPricingModel,
        IEnumerable<PriceModel> priceHistory)
    {
        productPricingModel.CurrentPrice = priceModel.Price;
        productPricingModel.LastUpdated = priceModel.CreateDateTime;
        productPricingModel.PriceHistory = priceHistory;
    }

    private static List<PriceModel> UpdatePriceHistory(ProductPricingModel productPricingModel)
    {
        var priceHistory = productPricingModel.PriceHistory?.ToList() ?? [];
        var originalPrice = productPricingModel.CurrentPrice;
        var lastUpdated = productPricingModel.LastUpdated;
        priceHistory.Add(new PriceModel { CreateDateTime = lastUpdated, Price = originalPrice });
        
        return priceHistory;
    }
    
    private static List<ProductPricingModel> SeedProductPricingModels() =>
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
using MyShopCore.Web.API.Models.Products;

namespace MyShopCore.Web.API.Services.Foundations.Products
{
    public interface IProductService
    {
        ValueTask<Product> AddProductAsync(Product prodcut);
        IQueryable<Product> RetrieveAllProducts();
        ValueTask<Product> RetreiveProductBIdAsync(Guid prodcut);
        ValueTask<Product> ModifiedProductAsync(Product prodcut);
        ValueTask<Product> RemoveProductAsync(Product prodcut);
    }
}

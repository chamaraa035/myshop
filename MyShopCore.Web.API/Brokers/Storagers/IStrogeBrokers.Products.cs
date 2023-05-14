using MyShopCore.Web.API.Models.Products;

namespace MyShopCore.Web.API.Brokers.Storagers
{
    public partial interface IStrogeBrokers
    {
        ValueTask<Product> InserrtProductAsync(Product prodcut);
        IQueryable<Product> SelectAllProducts();
        ValueTask<Product> SelectProductBIdAsync(Guid prodcut);
        ValueTask<Product> UpdateProductAsync(Product prodcut);
        ValueTask<Product> DeleteProductAsync(Product prodcut);
    }
}

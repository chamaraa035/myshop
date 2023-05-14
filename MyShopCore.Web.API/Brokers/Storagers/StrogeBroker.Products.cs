using Microsoft.EntityFrameworkCore;
using MyShopCore.Web.API.Models.Products;

namespace MyShopCore.Web.API.Brokers.Storagers
{
    public partial class StrogeBroker
    {
        public DbSet<Product> Products { get; set; }

        public async ValueTask<Product> DeleteProductAsync(Product prodcut)
        {
            this.Entry(prodcut).State = EntityState.Deleted;
            await this.SaveChangesAsync();

            return prodcut;
        }

        public async ValueTask<Product> InserrtProductAsync(Product prodcut)
        {
            this.Entry(prodcut).State = EntityState.Added;
            await this.SaveChangesAsync();

            return prodcut;
        }

        public IQueryable<Product> SelectAllProducts()
        {
           return this.Products.AsQueryable();
        }

        public async ValueTask<Product> SelectProductBIdAsync(Guid prodcutId)
        {
            return await this.Products.FindAsync(prodcutId);
        }

        public async ValueTask<Product> UpdateProductAsync(Product prodcut)
        {
            this.Entry(prodcut).State= EntityState.Modified;
            await this.SaveChangesAsync();

            return prodcut;
        }
    }
}

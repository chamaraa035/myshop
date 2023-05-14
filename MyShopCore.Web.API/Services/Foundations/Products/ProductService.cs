using MyShopCore.Web.API.Brokers.DateTimes;
using MyShopCore.Web.API.Brokers.Loggings;
using MyShopCore.Web.API.Brokers.Storagers;
using MyShopCore.Web.API.Models.Products;

namespace MyShopCore.Web.API.Services.Foundations.Products
{
    public class ProductService : IProductService
    {
        private readonly IStrogeBrokers stroragebroker;
        private readonly ILogginBrocker Loggingbroker;
        private readonly IDateTimeBroker dateTimebroker;

        public ProductService(ILogginBrocker loggingBroker, IStrogeBrokers stroragebroker, IDateTimeBroker dateTimebroker) 
        {
          this.Loggingbroker = loggingBroker;
          this.stroragebroker = stroragebroker;
          this.dateTimebroker = dateTimebroker;
        }

        public async ValueTask<Product> AddProductAsync(Product prodcut)
        {
            this.Loggingbroker.LogInformation($"{prodcut.Id} added");
            prodcut.Id= Guid.NewGuid();
            prodcut.Created = this.dateTimebroker.GetCurrentDateTime();
            prodcut.CreatedBy=Guid.NewGuid();
            return await this.stroragebroker.InserrtProductAsync(prodcut);
        }

        public async ValueTask<Product> ModifiedProductAsync(Product prodcut)
        {
            this.Loggingbroker.LogInformation($"{prodcut.Id} modified");
            prodcut.Updated = this.dateTimebroker.GetCurrentDateTime();
            prodcut.UpdatedBy = Guid.NewGuid();
            return await this.stroragebroker.UpdateProductAsync(prodcut);
        }

        public async ValueTask<Product> RemoveProductAsync(Product prodcut)
        {
            this.Loggingbroker.LogInformation($"{prodcut.Id} removed");
            return await this.stroragebroker.DeleteProductAsync(prodcut);
        }

        public async ValueTask<Product> RetreiveProductBIdAsync(Guid prodcutid)
        {
            return await this.stroragebroker.SelectProductBIdAsync(prodcutid);
        }

        public IQueryable<Product> RetrieveAllProducts()
        {
            return   this.stroragebroker.SelectAllProducts();
        }
    }
}

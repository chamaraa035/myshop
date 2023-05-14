using Microsoft.EntityFrameworkCore;
using MyShopCore.Web.API.Models.Products;

namespace MyShopCore.Web.API.Brokers.Storagers
{
    public partial class StrogeBroker:DbContext,IStrogeBrokers
    {
        private readonly IConfiguration configuration;

        public StrogeBroker(IConfiguration configuration)
        { 
         this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = this.configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}


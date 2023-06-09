using MyShopCore.Web.API.Brokers.DateTimes;
using MyShopCore.Web.API.Brokers.Loggings;
using MyShopCore.Web.API.Brokers.Storagers;
using MyShopCore.Web.API.Services.Foundations.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StrogeBroker>();

ServiceBroker(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ServiceBroker(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IStrogeBrokers, StrogeBroker>();
    builder.Services.AddTransient<ILogginBrocker, LoggingBroker>();
    builder.Services.AddTransient<IDateTimeBroker, DateTimeBroker>();
    builder.Services.AddTransient<IProductService, ProductService>();
}
using Eskitech.API.MappingProfiles;
using Eskitech.Entities.Categories;
using Eskitech.Entities.Products;
using Eskitech.Infrastructure.DbContexts;
using Eskitech.Infrastructure.Repositories;
using Eskitech.Infrastructure.Seeding;
using Microsoft.EntityFrameworkCore;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ProductMappingProfile));
builder.Services.AddAutoMapper(typeof(CategoryMappingProfile));

// Dependency injection
builder.Services.AddTransient<ProductDataContributor, ProductDataContributor>();
builder.Services.AddTransient<CategoryDataContributor, CategoryDataContributor>();
builder.Services.AddScoped<IBaseRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IBaseRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// Configure database
builder.Services.AddDbContext<EskitechDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlite(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.EnableTryItOutByDefault());
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

// Migrate the database
try
{
    var dbContext = services.GetRequiredService<EskitechDbContext>();
    await dbContext.Database.MigrateAsync();
}
catch (Exception ex)
{
    // TODO: Log the exception using a logger
    Console.WriteLine($"Could not migrate the database: {ex.Message}");
}

// Seed the database
var categorySeeder = scope.ServiceProvider.GetService<CategoryDataContributor>();
var productSeeder = scope.ServiceProvider.GetService<ProductDataContributor>();
try
{
    categorySeeder?.SeedData();
    productSeeder?.SeedData();
}
catch (Exception ex)
{
    // TODO: Log the exception using a logger
    Console.WriteLine($"Could not seed the database: {ex.Message}");
}

app.Run();
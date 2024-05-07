using Eskitech.Domain.Products;
using Eskitech.Infrastructure.DbContexts;
using Eskitech.Infrastructure.Seeding;
using Microsoft.EntityFrameworkCore;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injection
builder.Services.AddTransient<ProductDataContributor, ProductDataContributor>();

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
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

try
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    // Migrate the database
    var dbContext = services.GetRequiredService<EskitechDbContext>();
    await dbContext.Database.MigrateAsync();

    // Seed the database
    var productSeeder = scope.ServiceProvider.GetService<ProductDataContributor>();
    productSeeder?.SeedData();
}
catch (Exception ex)
{
    // TODO: Log the exception using a logger
    Console.WriteLine($"Could not migrate the database: {ex.Message}");
}


app.Run();

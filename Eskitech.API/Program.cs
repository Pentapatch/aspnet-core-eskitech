using Eskitech.API.MappingProfiles;
using Eskitech.Domain.Categories;
using Eskitech.Domain.Products;
using Eskitech.Entities.Categories;
using Eskitech.Entities.Products;
using Eskitech.Infrastructure.DbContexts;
using Eskitech.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

    // Add services to the container
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddAutoMapper(typeof(ProductMappingProfile), typeof(CategoryMappingProfile));

    // Dependency injection
    builder.Services.AddTransient<ProductDataContributor, ProductDataContributor>();
    builder.Services.AddTransient<CategoryDataContributor, CategoryDataContributor>();
    builder.Services.AddScoped<IBaseRepository<Product>, ProductRepository>();
    builder.Services.AddScoped<IBaseRepository<Category>, CategoryRepository>();
    builder.Services.AddScoped<IProductService, ProductService>();
    builder.Services.AddScoped<ICategoryService, CategoryService>();

    // Cross-Origin Resource Sharing (CORS) config
    builder.Services.AddCors(options =>
        options.AddPolicy("AllowAnyPolicy",
            policy =>
            {
                var allowedHosts = builder.Configuration.GetValue<string>("AllowedHosts")!;
                policy.WithOrigins(allowedHosts)
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

    // Configure database
    builder.Services.AddDbContext<EskitechDbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlite(connectionString);
    });

    // Add Serilog to the logging pipeline
    builder.Services.AddLogging(loggingBuilder =>
    {
        loggingBuilder.ClearProviders();
        loggingBuilder.AddSerilog(dispose: true);
    });

    var app = builder.Build();

    app.UseSerilogRequestLogging();

    // Configure the HTTP request pipeline
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options => options.EnableTryItOutByDefault());
    }

    app.UseCors("AllowAnyPolicy");
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
        Log.Fatal(ex, "Could not migrate the database");
        throw;
    }

    // Seed the database
    scope.ServiceProvider.GetService<CategoryDataContributor>()?.Contribute();
    scope.ServiceProvider.GetService<ProductDataContributor>()?.Contribute();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.Information("Shutting down web application");
    Log.CloseAndFlush();
}
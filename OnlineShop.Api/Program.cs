using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnlineShop.Api;
using OnlineShop.Api.Filters;
using OnlineShop.Application;
using OnlineShop.Application.Events;
using OnlineShop.Application.Profiles;
using OnlineShop.Domain.Entities.Customers;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Persistence.DatabaseContext;
using OnlineShop.Infrastructure.Persistence.Repositories;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    
})

    // Adding Jwt Bearer  
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = true,
            ValidAudience = "https://localhost:5001/",
            ValidIssuer = "https://localhost:5001/",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abcdefghijklmnopqrstuvwxyz123456"))
        };
        options.Audience = "online-shop";
        options.Authority = "https://localhost:5001";
    });
builder.Services.AddAuthorization();
builder.Services.AddDbContext<OnlineShopReadDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration["ConnectionString"]);
        options.EnableSensitiveDataLogging();
    }
);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:5173");
        });
});

builder.Services.AddDbContext<OnlineShopWriteDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionString"]);
    options.EnableSensitiveDataLogging();
}
);

builder.Services.AddApplication();
builder.Services.AddScoped(typeof(IReadRepository<Order>), typeof(OrderReadRepository));
builder.Services.AddScoped(typeof(IWriteRepository<Order>), typeof(OrderWriteRepository));
builder.Services.AddScoped(typeof(IReadRepository<Customer>), typeof(CustomerReadRepository));
builder.Services.AddScoped(typeof(IWriteRepository<Customer>), typeof(CustomerWriteRepository));
builder.Services.AddScoped(typeof(IReadRepository<Product>), typeof(ProductReadRepository));
builder.Services.AddScoped(typeof(IWriteRepository<Product>), typeof(ProductWriteRepository));
builder.Services.AddScoped(typeof(IDomainEventService), typeof(DomainEventService));
builder.Services.AddScoped<ApiExceptionFilterAttribute>();

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
    // Set the comments path for the Swagger JSON and UI.**
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    option.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var onlineShopReadDbContext = scope.ServiceProvider.GetRequiredService<OnlineShopReadDbContext>();
    onlineShopReadDbContext.Database.Migrate();

    var onlineShopWriteDbContext = scope.ServiceProvider.GetRequiredService<OnlineShopWriteDbContext>();
    onlineShopWriteDbContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

await MigrateDatabase(app);

app.Run();

static async Task MigrateDatabase(IHost webApplication)
{
    using var scope = webApplication.Services.GetService<IServiceScopeFactory>()?.CreateScope();
    var onlineShopReadDbContext = scope.ServiceProvider.GetRequiredService<OnlineShopReadDbContext>();
    await onlineShopReadDbContext.Database.MigrateAsync();
    await SeedData.EnsureSeedData(onlineShopReadDbContext);
    var onlineShopWriteDbContext = scope.ServiceProvider.GetRequiredService<OnlineShopWriteDbContext>();
    await onlineShopWriteDbContext.Database.MigrateAsync();
    await SeedData.EnsureSeedData(onlineShopWriteDbContext);
}
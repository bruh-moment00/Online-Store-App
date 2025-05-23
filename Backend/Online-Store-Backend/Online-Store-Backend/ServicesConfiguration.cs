using Microsoft.EntityFrameworkCore;
using Online_Store_Backend.Core.Data.Repository;
using Online_Store_Backend.Database.Contexts;
using Online_Store_Backend.Domain.Categories.Services;
using Online_Store_Backend.Domain.Categories.Services.Interfaces;
using Online_Store_Backend.Domain.Employees.Services;
using Online_Store_Backend.Domain.Employees.Services.Interfaces;
using Online_Store_Backend.Domain.Orders.Services;
using Online_Store_Backend.Domain.Orders.Services.Interfaces;
using Online_Store_Backend.Domain.Permissions.Services;
using Online_Store_Backend.Domain.Permissions.Services.Interfaces;
using Online_Store_Backend.Domain.Products.Services;
using Online_Store_Backend.Domain.Products.Services.Interfaces;
using Online_Store_Backend.Domain.Users.Services;
using Online_Store_Backend.Domain.Users.Services.Interfaces;

namespace Online_Store_Backend
{
    internal static class ServicesConfiguration
    {
        internal static void ConfigureServices(this IServiceCollection services, string connectionString)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<DbContext, OnlineStoreDbContext>();
            services.AddDbContext<OnlineStoreDbContext>(options => options.UseNpgsql(connectionString));

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddScoped<IProductPropValueService, ProductPropValueService>();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IOrderedProductService, OrderedProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IEmployeePermissionService, EmployeePermissionService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}

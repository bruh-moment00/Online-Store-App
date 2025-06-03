using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using Online_Store_Backend.Domain.Authentication.Interfaces;
using Online_Store_Backend.Domain.Authentication;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace Online_Store_Backend
{
    internal static class ServicesConfiguration
    {
        internal static void ConfigureServices(this IServiceCollection services, IConfiguration configuration, string connectionString)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new string[]{}
                    }
                });

                options.CustomSchemaIds(type => type.ToString());
            });

            services.AddCors();
            services.AddScoped<DbContext, OnlineStoreDbContext>();
            services.AddDbContext<OnlineStoreDbContext>(options => options.UseNpgsql(connectionString));

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));

            services.AddScoped<ICategoryService, CategoryService>();
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
            services.AddScoped<IAuthService, AuthService>();    

            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidAudience = configuration["Jwt:Audience"],
                        ValidateLifetime = false,
                    };
                });

            services.AddAuthorization();
        }
    }
}

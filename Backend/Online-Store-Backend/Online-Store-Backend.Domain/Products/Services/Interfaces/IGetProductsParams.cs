using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Online_Store_Backend.Enums;

namespace Online_Store_Backend.Domain.Products.Services.Interfaces
{
    public interface IGetProductsParams
    {
        string? Search { get; set; }
        long? CategoryId { get; set; }
        SortColumnProduct? SortColumn { get; set; } 
        SortOrder? SortOrder { get; set; } 
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}

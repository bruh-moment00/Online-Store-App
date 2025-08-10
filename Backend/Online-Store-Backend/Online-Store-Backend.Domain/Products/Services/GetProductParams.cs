using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Online_Store_Backend.Domain.Products.Services.Interfaces;
using Online_Store_Backend.Enums;

namespace Online_Store_Backend.Domain.Products.Services
{
    public class GetProductParams : IGetProductsParams
    {
        public GetProductParams() { }
        private SortColumnProduct? sortColumn = null;
        public string? Search { get; set; } = null;
        public long? CategoryId { get; set; } = null;
        public SortColumnProduct? SortColumn { 
            get => sortColumn; 
            set 
            {
                sortColumn = value;
                if (sortColumn != null && SortOrder == null)
                {
                    SortOrder = Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.SortOrder.Ascending;
                }
            } 
        }
        public SortOrder? SortOrder { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}

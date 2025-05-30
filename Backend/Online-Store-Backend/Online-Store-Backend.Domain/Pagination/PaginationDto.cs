using Online_Store_Backend.Core.Entity;
using Online_Store_Backend.Domain.Base.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Backend.Domain.Pagination
{
    public class PaginationDto<Dto> where Dto : BaseDto
    {
        public PaginationDto(IEnumerable<Dto> items, int totalCount, int pageNumber, int pageSize, int totalPages)
        {
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
            Items = items;
            TotalPages = totalPages;
        }
        public IEnumerable<Dto> Items { get; }
        public int TotalCount { get; }
        public int TotalPages { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
    }
}

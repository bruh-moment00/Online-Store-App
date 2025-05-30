using Online_Store_Backend.Core.Entity;

namespace Online_Store_Backend.Domain.Pagination
{
    public class PaginationEntity<Entity> where Entity : BaseEntity
    {
        public PaginationEntity(IEnumerable<Entity> items, int pageNumber = 1, int pageSize = 10)
        {
            TotalCount = items.Count();
            PageNumber = pageNumber;
            PageSize = pageSize;
            Items = items.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            TotalPages = (int)Math.Ceiling((double)TotalCount / pageSize);
        }
        public IEnumerable<Entity> Items { get; }
        public int TotalCount { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
    }
}

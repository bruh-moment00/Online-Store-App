using Online_Store_Backend.Domain.Orders.Dto;
using Online_Store_Backend.Domain.Pagination;

namespace Online_Store_Backend.Domain.Orders.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetById(long id);
        Task<PaginationDto<OrderDto>> GetOrders(long? userId ,int pageNumber = 1, int pageSize = 10);
        Task<List<OrderDto>> GetByUserId(long userId);
        Task<long> CreateOrder(long userId);
        Task<bool> UpdateOrder(OrderDto order);
        Task<bool> DeleteOrder(long id);
    }
}

using Online_Store_Backend.Domain.Orders.Dto;

namespace Online_Store_Backend.Domain.Orders.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetById(long id);
        Task<List<OrderDto>> GetAll();
        Task<List<OrderDto>> GetByUserId(long userId);
        Task<long> InsertOrder(OrderDto order);
        Task<bool> UpdateOrder(OrderDto order);
        Task<bool> DeleteOrder(long id);
    }
}

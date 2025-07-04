using Online_Store_Backend.Domain.Orders.Dto;

namespace Online_Store_Backend.Domain.Orders.Services.Interfaces
{
    public interface IOrderedProductService
    {
        Task<OrderedProductDto> GetById(long id);
        Task<List<OrderedProductDto>> GetByOrderId(long orderId);
        Task<long> InsertOrderedProduct(OrderedProductDto orderedProduct);
        Task<bool> UpdateOrderedProduct(OrderedProductDto orderedProduct);
        Task<bool> DeleteOrderedProduct(long id);
    }
}

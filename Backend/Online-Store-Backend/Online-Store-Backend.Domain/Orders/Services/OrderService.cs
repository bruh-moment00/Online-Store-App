using Online_Store_Backend.Core.Data.Repository;
using Online_Store_Backend.Database.Orders.Models;
using Online_Store_Backend.Domain.Orders.Dto;
using Online_Store_Backend.Domain.Orders.Services.Interfaces;

namespace Online_Store_Backend.Domain.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryAsync<Order> orderRepository;
        public OrderService(IRepositoryAsync<Order> orderRepository) => this.orderRepository = orderRepository;
        public async Task<OrderDto> GetById(long id)
        {
            var entity = await this.orderRepository.FindById(id);
            return entity == null ? null : MapEntityToDto(entity);
        }
        public async Task<List<OrderDto>> GetAll()
        {
            var entities = await this.orderRepository.Filter(x => !x.IsDeleted);
            return entities.Select(MapEntityToDto).ToList();
        }
        public async Task<List<OrderDto>> GetByUserId(long userId)
        {
            var entities = await this.orderRepository.Filter(x => x.UserID == userId && !x.IsDeleted);
            return entities.Select(MapEntityToDto).ToList();
        }
        public async Task<long> InsertOrder(OrderDto order)
        {
            var entity = MapDtoToEntity(order);
            return await this.orderRepository.Insert(entity);
        }
        public async Task<bool> UpdateOrder(OrderDto order)
        {
            var entity = MapDtoToEntity(order);
            return await this.orderRepository.Update(entity) != 0;
        }
        public async Task<bool> DeleteOrder(long id) => await this.orderRepository.Delete(id);
        private static OrderDto MapEntityToDto(Order order)
        {
            return new OrderDto
            {
                ID = order.ID,
                CreatedDateTime = order.CreatedDateTime,
                IsActive = order.IsActive,
                IsDeleted = order.IsDeleted,
                UserID = order.UserID,
                TotalPrice = order.TotalPrice,
                Status = order.Status
            };
        }
        private static Order MapDtoToEntity(OrderDto order)
        {
            return new Order
            {
                ID = order.ID,
                UserID = order.UserID,
                TotalPrice = order.TotalPrice,
                Status = order.Status
            };
        }
    }
}

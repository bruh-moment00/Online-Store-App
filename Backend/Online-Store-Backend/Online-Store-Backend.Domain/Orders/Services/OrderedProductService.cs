using Online_Store_Backend.Core.Data.Repository;
using Online_Store_Backend.Database.Orders.Models;
using Online_Store_Backend.Domain.Orders.Dto;
using Online_Store_Backend.Domain.Orders.Services.Interfaces;

namespace Online_Store_Backend.Domain.Orders.Services
{
    public class OrderedProductService : IOrderedProductService
    {
        private readonly IRepositoryAsync<OrderedProduct> orderedProductRepository;
        public OrderedProductService(IRepositoryAsync<OrderedProduct> orderedProductRepository)
        {
            this.orderedProductRepository = orderedProductRepository;
        }
        public async Task<List<OrderedProductDto>> GetByOrderId(long orderId)
        {
            var entities = await this.orderedProductRepository.Filter(x => x.OrderID == orderId && !x.IsDeleted);
            return entities.Select(MapEntityToDto).ToList();
        }
        public async Task<long> InsertOrderedProduct(OrderedProductDto orderedProduct)
        {
            var entity = MapDtoToEntity(orderedProduct);
            return await this.orderedProductRepository.Insert(entity);
        }
        public async Task<bool> UpdateOrderedProduct(OrderedProductDto orderedProduct)
        {
            var entity = MapDtoToEntity(orderedProduct);
            return await this.orderedProductRepository.Update(entity) != 0;
        }
        public async Task<bool> DeleteOrderedProduct(long id) => await this.orderedProductRepository.Delete(id);
        private static OrderedProductDto MapEntityToDto(OrderedProduct orderedProduct)
        {
            return new OrderedProductDto
            {
                ID = orderedProduct.ID,
                CreatedDateTime = orderedProduct.CreatedDateTime,
                IsActive = orderedProduct.IsActive,
                IsDeleted = orderedProduct.IsDeleted,
                UpdateDateTime = orderedProduct.UpdateDateTime,
                OrderID = orderedProduct.OrderID,
                ProductID = orderedProduct.ProductID,
            };
        }
        private static OrderedProduct MapDtoToEntity(OrderedProductDto orderedProduct)
        {
            return new OrderedProduct
            {
                ID = orderedProduct.ID,
                OrderID = orderedProduct.OrderID,
                ProductID = orderedProduct.ProductID,
            };
        }
    }
}

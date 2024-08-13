using Book_store.Domain.Models;
using Book_store.Repository.Interface;
using Book_store.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_store.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public Order GetDetailsForOrder(Guid id)
        {
            return _orderRepository.GetDetailsForOrder(id);
        }
    }
}

using Book_store.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_store.Service.Interface
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetDetailsForOrder(Guid id);
    }
}

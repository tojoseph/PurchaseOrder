using PurchaseOrder.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseOrder.Core.Models;

namespace PurchaseOrder.Services.Interfaces
{
    public interface IOrderService
    {
        Task<bool> CreateOrder(OrderViewModel orderDetails);
        Task<IEnumerable<UpdateOrderViewModel>> GetAllOrders();
        Task<UpdateOrderViewModel> GetOrderById(int orderId);
        Task<bool> UpdateOrder(UpdateOrderViewModel orderDetails);
        Task<bool> DeleteOrder(int orderId);
    }
}

using PurchaseOrder.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Core.Interfaces
{
    public interface IOrderItemsRepository : IGenericRepository<TblOrderItems>
    {
        //public  Task<IEnumerable<TblOrderItems>> GetItemsByOrderId(int OrderId);
    }
}

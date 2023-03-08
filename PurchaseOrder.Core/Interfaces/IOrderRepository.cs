using PurchaseOrder.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseOrder.Core.Interfaces;

namespace PurchaseOrder.Core.Interfaces
{
    public interface IOrderRepository :IGenericRepository<TblOrders>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Core.Models
{
    public class OrderItemsModel
    {
        public int? OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; } = null!;
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal Total { get; set; }
        public int? SubscriptionId { get; set; } = null;
        
    }
}

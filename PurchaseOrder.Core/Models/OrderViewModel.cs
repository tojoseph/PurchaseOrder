using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Core.Models
{
    public class OrderViewModel
    {
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? Remarks { get; set; }
        public decimal? Total { get; set; }
        public decimal? Tax { get; set; }
        public decimal? NetTotal { get; set; }
       //public OrdersModel Orders { get; set; }  
        public List<OrderItemsModel> OrderItems { get; set; }
    }

}

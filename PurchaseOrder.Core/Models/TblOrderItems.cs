using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseOrder.Core.Models;

namespace PurchaseOrder.Core.Models
{
    public class TblOrderItems
    {
        [Key]
        public int Id { get; set; }
       
        public int ProductId { get; set; }
        public string ProductCode { get; set; } = null!;
        public string? ProductName { get; set; }
        public int Qty { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal Total { get; set; }
        public int? SubscriptionId { get; set; } = null;

        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public int OrderId { get; set; } // navigation property
        //[ForeignKey("OrderId")]
        public  TblOrders Order { get; set; }
    }

}

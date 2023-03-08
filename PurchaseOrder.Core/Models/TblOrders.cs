using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseOrder.Core.Models;

namespace PurchaseOrder.Core.Models
{
    public class TblOrders
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? Remarks { get; set; }
        public decimal Total { get; set; }
        public decimal Tax { get; set; }
        public decimal NetTotal { get; set; }

        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [ForeignKey("OrderId")]
        public  ICollection<TblOrderItems> OrderItems { get; set; }
    }
}

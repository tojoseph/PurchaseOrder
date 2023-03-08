using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Core.Models
{
    public class TblProductDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Category { get; set; }
        public string? Remarks { get; set; }
        public int? SubscriptionId { get; set; } = null; 

        public DateTime? CreatedOn { get; set; } = null;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}

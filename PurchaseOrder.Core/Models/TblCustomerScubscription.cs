using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Core.Models
{
    public class TblCustomerScubscription
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int SubscriptionId { get; set; }

        public DateTime? CreatedOn { get; set; } = null;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}

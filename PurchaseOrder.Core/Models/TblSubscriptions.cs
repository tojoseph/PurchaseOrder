using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Core.Models
{
    public  class TblSubscriptions
    {
        public int Id { get; set; }
        public string SubscriptionName { get; set; }
        public string Description { get; set; }

        
        public DateTime? CreatedOn { get; set; } = null;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

    }
}

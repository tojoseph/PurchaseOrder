using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Core.Models
{
    public class CustomerScubscriptionModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int SubscriptionId { get; set; }
    }
}

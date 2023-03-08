

namespace PurchaseOrder.Core.Models
{
    public class ProductDetailsModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Category { get; set; }
        public string? Remarks { get; set; }
        public int? SubscriptionId { get; set; } = null;
    }
   
}

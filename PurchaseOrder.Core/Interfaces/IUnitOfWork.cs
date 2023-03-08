

namespace PurchaseOrder.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        IOrderItemsRepository OrderItems { get; }
        ICustomerScubscriptionRepository CustomerSubscription { get; }
        int Save();
    }
}

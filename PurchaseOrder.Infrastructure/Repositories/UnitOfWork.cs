

using Microsoft.EntityFrameworkCore;
using PurchaseOrder.Core.Interfaces;
using System;

namespace PurchaseOrder.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextClass _dbContext;
        public IProductRepository Products { get; }
        public IOrderRepository Orders { get; }
        public IOrderItemsRepository OrderItems { get; }
        public ICustomerScubscriptionRepository CustomerSubscription { get; }


        public UnitOfWork(DbContextClass dbContext,
                            IProductRepository productRepository,
                            IOrderRepository orders,
                            IOrderItemsRepository orderItems,
                            ICustomerScubscriptionRepository customerSubscription)
        {
            _dbContext = dbContext;
            Products = productRepository;
            Orders = orders;
            OrderItems = orderItems;
            CustomerSubscription = customerSubscription;
        }

        public int Save()
        {
            var res = _dbContext.SaveChanges();
            //and then to detach everything 
            foreach (var entity in _dbContext.ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }
            return res;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}

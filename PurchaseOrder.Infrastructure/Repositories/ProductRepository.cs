using PurchaseOrder.Core.Interfaces;
using PurchaseOrder.Core.Models;

namespace PurchaseOrder.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<TblProductDetails>, IProductRepository
    {
        public ProductRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}

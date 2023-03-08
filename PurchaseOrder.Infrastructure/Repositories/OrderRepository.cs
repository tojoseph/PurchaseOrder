using PurchaseOrder.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseOrder.Core.Interfaces;
using PurchaseOrder.Core.Models;
using PurchaseOrder.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PurchaseOrder.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<TblOrders>, IOrderRepository
    {
        public OrderRepository(DbContextClass dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<TblOrders>> GetAll()
        {
            try
            {
                var orders = await _dbContext.Orders.Include(i => i.OrderItems).ToListAsync();
                return orders;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public override async Task<TblOrders> GetById(int id)
        {
            try
            {
                var orders = await _dbContext.Orders.Include(i => i.OrderItems).Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
                return orders;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}

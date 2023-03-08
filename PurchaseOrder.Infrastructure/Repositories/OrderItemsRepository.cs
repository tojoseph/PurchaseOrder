using Microsoft.EntityFrameworkCore;
using PurchaseOrder.Core.Interfaces;
using PurchaseOrder.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Infrastructure.Repositories
{
    public class OrderItemsRepository : GenericRepository<TblOrderItems>, IOrderItemsRepository
    {
        public OrderItemsRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
        //public override async Task<IEnumerable<TblOrderItems>> GetAll()
        //{
        //    return await _dbContext.Set<TblOrderItems>().Include(i => i.Order).ToListAsync();
        //}

        //public async Task<IEnumerable<TblOrderItems>> GetItemsByOrderId(int OrderId)
        //{
        //    return await _dbContext.Set<TblOrderItems>().Include(i => i.Order).Where(i => i.OrderId.Equals(OrderId)).ToListAsync();
        //}
    }
}

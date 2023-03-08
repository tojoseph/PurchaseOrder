using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseOrder.Core.Interfaces;
using PurchaseOrder.Core.Models;
using PurchaseOrder.Infrastructure.Repositories;

namespace PurchaseOrder.Infrastructure.Repositories
{
    public class CustomerScubscriptionRepository : GenericRepository<TblCustomerScubscription>, ICustomerScubscriptionRepository
    {
        public CustomerScubscriptionRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
    
}

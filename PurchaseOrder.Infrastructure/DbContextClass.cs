using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseOrder.Core.Models;

namespace PurchaseOrder.Infrastructure
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<TblProductDetails> Products { get; set; }
        public DbSet<TblOrderItems> OrderItems { get; set; }
        public DbSet<TblOrders> Orders { get; set; }
        public DbSet<TblCustomerScubscription> CustomerScubscription { get; set; }
        public DbSet<TblSubscriptions> Subscriptions { get; set; }
    }
}

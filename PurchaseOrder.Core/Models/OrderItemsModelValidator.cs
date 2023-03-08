using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Core.Models
{
    public class OrderItemsModelValidator :AbstractValidator<OrderItemsModel>
    {
        public OrderItemsModelValidator()
        {
            RuleFor(orderItem => orderItem.Qty).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}

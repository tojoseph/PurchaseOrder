using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Core.Models
{
    public class OrderViewModelValidator : AbstractValidator<OrderViewModel>
    {
        public OrderViewModelValidator()
        {
           
            RuleForEach(order => order.OrderItems)
                    .NotNull()
                    .SetValidator(new OrderItemsModelValidator());
            // Check name is not null, empty and is between 1 and 250 characters

            RuleFor(order => order.CustomerName).NotNull().NotEmpty();
            RuleFor(order => order.Total).NotNull().NotEmpty().GreaterThan(0);
            
            RuleFor(order => order.OrderItems.Count()).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}

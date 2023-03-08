using PurchaseOrder.Core.Models;
using PurchaseOrder.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseOrder.Core.Interfaces;
using PurchaseOrder.Core.Models;
using AutoMapper;
using FluentValidation;

namespace PurchaseOrder.Services
{
    public class OrderService : IOrderService
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;
        private readonly IValidator<OrderViewModel> _validator;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<OrderViewModel> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<bool> CreateOrder(OrderViewModel orderDetails)
        {
            var validationResult = _validator.Validate(orderDetails);

            if (orderDetails != null && validationResult.IsValid)
            {
                //Map the OrderDetailsViewModel to OrderDetails and insert 
                var orderHeader = _mapper.Map<OrderViewModel, TblOrders>(orderDetails);
                orderHeader.OrderItems = _mapper.Map<List<OrderItemsModel>, List<TblOrderItems>>(orderDetails.OrderItems);
                orderHeader.OrderDate = DateTime.Now;
                orderHeader.CreatedOn = DateTime.Now;
                orderHeader.CreatedBy = 1;

                if (orderHeader.OrderItems != null)
                {
                    foreach (var item in orderHeader.OrderItems)
                    {
                        if (item.SubscriptionId != 0 && item.SubscriptionId != null)
                        {
                            //Add Subscription for the customer
                            TblCustomerScubscription subscription = new TblCustomerScubscription
                            {
                                SubscriptionId = Convert.ToInt32(item.SubscriptionId),
                                CustomerId = Convert.ToInt32(orderHeader.CustomerId)
                            };

                            //remove Order Item as it is subscription product since it is not meant for any physical delivery.
                            await _unitOfWork.CustomerSubscription.Add(subscription);
                        }
                    }
                    await _unitOfWork.Orders.Add(orderHeader);
                }

                // Finally save your unit of work
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public async Task<bool> DeleteOrder(int orderId)
        {
            if (orderId > 0)
            {
                var order = await _unitOfWork.Orders.GetById(orderId);
                if (order != null)
                {
                    _unitOfWork.Orders.Delete(order);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
        public async Task<IEnumerable<UpdateOrderViewModel>> GetAllOrders()
        {
            var orders = await _unitOfWork.Orders.GetAll();
            var result = _mapper.Map<IEnumerable<TblOrders>, IEnumerable<UpdateOrderViewModel>>(orders);
            return result;
        }
        public async Task<UpdateOrderViewModel> GetOrderById(int orderId)
        {
            var order = await _unitOfWork.Orders.GetById(orderId);
            var result = _mapper.Map<TblOrders, UpdateOrderViewModel>(order);
            return result;
        }
        public async Task<bool> UpdateOrder(UpdateOrderViewModel orderDetails)
        {
            if (orderDetails != null)
            {
                var order = await _unitOfWork.Orders.GetById(Convert.ToInt32(orderDetails.Id));

                if (order != null)
                {
                    order = _mapper.Map<UpdateOrderViewModel, TblOrders>(orderDetails,order);
                    _unitOfWork.Orders.Update(order);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}

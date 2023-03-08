using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using PurchaseOrder.Services.Interfaces;
using PurchaseOrder.Core.Models;
using Newtonsoft.Json;

namespace PurchaseOrder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public readonly IOrderService _orderService;
        private readonly ILogger<OrdersController> logger;
        public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            this.logger = logger;
        }
        /// <summary>
        /// Get the list of Orders
        /// </summary>
        /// <return></return>
        [HttpGet]
        public async Task<IActionResult> GetOrdersList()
        {
            logger.LogDebug("Inside GetOrdersList endpoint");

            var orderDetailsList = await _orderService.GetAllOrders();
            if (orderDetailsList == null)
            {
                return NotFound();
            }

            logger.LogDebug($"The response for the  Get Orders List is {JsonConvert.SerializeObject(orderDetailsList)}");

            return Ok(orderDetailsList);
        }
        /// <summary>
        /// Get order by id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var orderDetails = await _orderService.GetOrderById(orderId);

            if (orderDetails != null)
            {
                return Ok(orderDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Add a new order
        /// </summary>
        /// <param name="orderDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderViewModel orderDetails)
        {
          
            var isOrderCreated = await _orderService.CreateOrder(orderDetails);

            if (isOrderCreated)
            {
                logger.LogDebug("Order is created Successfully.");

                return Ok(isOrderCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update the order
        /// </summary>
        /// <param name="orderDetails"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderViewModel orderDetails)
        {
            if (orderDetails != null)
            {
                var isOrderCreated = await _orderService.UpdateOrder(orderDetails);
                if (isOrderCreated)
                {
                    return Ok(isOrderCreated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete order by id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            var isOrderCreated = await _orderService.DeleteOrder(orderId);

            if (isOrderCreated)
            {
                return Ok(isOrderCreated);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

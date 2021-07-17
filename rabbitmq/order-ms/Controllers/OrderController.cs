using MassTransit;
using Microsoft.AspNetCore.Mvc;
using order_ms.infa;
using order_ms.ViewModel;
using rabbitmq;
using rabbitmq_message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace order_ms.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly IOrderDataAccess _OrderDataAccess;

        public OrderController(
          ISendEndpointProvider sendEndpointProvider, IOrderDataAccess OrderDataAccess)
        {
            _sendEndpointProvider = sendEndpointProvider;
            _OrderDataAccess = OrderDataAccess;
        }

        [HttpPost]
        [Route("createorder")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderModel orderModel)
        {
            await _OrderDataAccess.Add(orderModel);
            var endPoint = await _sendEndpointProvider.
                GetSendEndpoint(new Uri("queue:" + BusConstants.OrderQueue));

            await endPoint.Send<IOrderMessage>(new
            {
                OrderId = orderModel.OrderId,
                ProductName = orderModel.ProductName,
                PaymentCardNumber = orderModel.CardNumber
            });

            return Ok("Success");
        }


        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _OrderDataAccess.GetAll();
            return Ok(data);
        }
    }
}

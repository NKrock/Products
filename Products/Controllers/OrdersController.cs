using CommonLibraries.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrders _iorder;
        public OrdersController(IOrders iorder)
        {
            _iorder = iorder;
        }


        [HttpGet("GetAllOrders")]
        public async Task<DataResult<dynamic>> GetAllOrders()
        {
            try
            {
                var customerData = await _iorder.GetAllOrders();


                if (customerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, customerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "No records found.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }


        [HttpGet("GetOrderDetailsById/{​​​​​​​id}​​​​​​​")]
        public async Task<DataResult<dynamic>> GetOrderDetailsById(int id)
        {
            try
            {
                var orderData = await _iorder.GetOrderDetailsById(id);


                if (orderData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, orderData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "No records found.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }


        [HttpPost("SaveOrderDetails")]
        public async Task<DataResult<dynamic>> SaveOrderDetails([FromBody] Orders order)
        {
            try
            {
                var orderData = await _iorder.SaveOrderDetails(order);


                if (orderData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, orderData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "No records found.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }


        [HttpPost("UpdateOrderDetails")]

        public async Task<DataResult<dynamic>> UpdateOrderDetails([FromBody] Orders order)
        {
            try
            {
                var orderData = await _iorder.UpdateOrderDetails(order);


                if (orderData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, orderData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "No records found.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }


        [HttpPost("DeleteOrderDetails")]
        public async Task<DataResult<dynamic>> DeleteOrderDetails([FromBody] Orders order)
        {
            try
            {
                var orderData = await _iorder.DeleteOrderDetails(order);


                if (orderData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, orderData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "No records found.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }
    }
}

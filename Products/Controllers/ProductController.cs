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
    public class ProductController : ControllerBase
    {
        private readonly IProduct _iProduct;
        public ProductController(IProduct iProduct)
        {
            _iProduct = iProduct;
        }


        [HttpGet("GetAllProducts")]
        public async Task<DataResult<dynamic>> GetAllProducts()
        {
            try
            {
                var ProductData = await _iProduct.GetAllProducts();


                if (ProductData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, ProductData);
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


        [HttpGet("GetProductDetailsById/{​​​​​​​id}​​​​​​​")]
        public async Task<DataResult<dynamic>> GetProductDetailsById(int id)
        {
            try
            {
                var ProductData = await _iProduct.GetProductDetailsById(id);


                if (ProductData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, ProductData);
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


        [HttpPost("SaveProductDetails")]
        public async Task<DataResult<dynamic>> SaveProductDetails([FromBody] Product product)
        {
            try
            {
                var ProductData = await _iProduct.SaveProductDetails(product);


                if (ProductData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, ProductData);
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


        [HttpPost("UpdateProductDetails")]

        public async Task<DataResult<dynamic>> UpdateProductDetails([FromBody] Product product)
        {
            try
            {
                var ProductData = await _iProduct.UpdateProductDetails(product);


                if (ProductData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, ProductData);
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


        [HttpPost("DeleteProductDetails")]
        public async Task<DataResult<dynamic>> DeleteProductDetails([FromBody] Product product)
        {
            try
            {
                var ProductData = await _iProduct.DeleteProductDetails(product);


                if (ProductData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, ProductData);
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


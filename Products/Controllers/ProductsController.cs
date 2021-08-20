using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.DBContext;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Controllers
{
    [Route("Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDataUoW _dataUow;
        private readonly DataContext _dataContext;
        public ProductsController(IDataUoW dataUow, DataContext dataContext)
        {
            _dataUow = dataUow;
            _dataContext = dataContext;
        }
        //User Profile Table
        [HttpGet("GetUserProfileList")]
        public async Task<dynamic> GetUserProfileList()
        {
            try 
            {
                var providerData = await _dataUow.UserProfile.GetAll().ToListAsync();
                return providerData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        [HttpGet("GetUserProfileById/{id}")]
        public async Task<DataResult<dynamic>> GetUserProfileById(int id, string fname)
        {
            try
            {
                if (id <= 0)
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, null, new ValidationResultModel() { Message = "Id must not be less than 0" });
                }
                var providerData = await _dataUow.UserProfile.GetAllWithNoTracking().Where(p => p.UserProfileId == id).FirstOrDefaultAsync();

                if (providerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, providerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "Entered data does not match our records. Please try again.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }
        [HttpPost("SaveUserProfile")]
        public async Task<dynamic> SaveUserProfile(UserProfile profile)
        {
            try
            {
                _dataUow.UserProfile.Add(profile);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }
        [HttpPost("UpdateUserProfile")]
        public async Task<dynamic> UpdateUserProfile(UserProfile profile)
        {
            try
            {
                _dataUow.UserProfile.Update(profile);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        [HttpPost("DeleteUserProfile")]
        public async Task<dynamic> DeleteUserProfile(UserProfile profile)
        {
            try
            {
                _dataUow.UserProfile.Delete(profile);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        //Secret Question Table
        [HttpGet("GetSecretQuestionList")]
        public async Task<dynamic> GetSecretQuestionList()
        {
            try
            {
                var providerData = await _dataUow.SecretQuestions.GetAll().ToListAsync();
                return providerData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        [HttpGet("GetSecretQuestionsById/{id}")]
        public async Task<DataResult<dynamic>> GetSecretQuestionsById(int id, string fname)
        {
            try
            {
                if (id <= 0 || string.IsNullOrEmpty(fname))
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, null, new ValidationResultModel() { Message = "Id must not be less than 0" });
                }
                var providerData = await _dataUow.SecretQuestions.GetAllWithNoTracking().Where(p => p.UserProfileId == id).FirstOrDefaultAsync();

                if (providerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, providerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "Entered data does not match our records. Please try again.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }
        [HttpPost("SaveSecretQuestion")]
        public async Task<dynamic> SaveSecretQuestion(SecretQuestions question)
        {
            try
            {
                _dataUow.SecretQuestions.Add(question);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("UpdateSecretQuestion")]
        public async Task<dynamic> UpdateSecretQuestion(SecretQuestions question)
        {
            try
            {
                _dataUow.SecretQuestions.Update(question);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        [HttpPost("DeleteSecretQuestion")]
        public async Task<dynamic> DeleteSecretQuestion(SecretQuestions question)
        {
            try
            {
                _dataUow.SecretQuestions.Delete(question);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        //User details Table
        [HttpGet("GetUserdetailsList")]
        public async Task<dynamic> GetUserdetailsList()
        {
            try
            {
                var providerData = await _dataUow.Userdetails.GetAll().ToListAsync();
                return providerData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        [HttpGet("GetUserDetailsById/{id}")]
        public async Task<DataResult<dynamic>> GetUserDetailsById(int id, string fname)
        {
            try
            {
                if (id <= 0 || string.IsNullOrEmpty(fname))
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, null, new ValidationResultModel() { Message = "Id must not be less than 0" });
                }
                var providerData = await _dataUow.Userdetails.GetAllWithNoTracking().Where(p => p.UserDetailsId == id).FirstOrDefaultAsync();

                if (providerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, providerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "Entered data does not match our records. Please try again.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }
        [HttpPost("SaveUserdetails")]
        public async Task<dynamic> SaveUserdetails(Userdetails details)
        {
            try
            {
                _dataUow.Userdetails.Add(details);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        [HttpPost("UpdateUserdetails")]
        public async Task<dynamic> UpdateUserdetails(Userdetails details)
        {
            try
            {
                _dataUow.Userdetails.Update(details);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        [HttpPost("DeleteUserdetails")]
        public async Task<dynamic> DeleteUserdetails(Userdetails details)
        {
            try
            {
                _dataUow.Userdetails.Delete(details);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        //User Address Table
        [HttpGet("GetUserAddressList")]
        public async Task<dynamic> GetUserAddressList()
        {
            try
            {
                var providerData = await _dataUow.UserAddress.GetAll().ToListAsync();
                return providerData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpGet("GetUserAddressById/{id}")]
        public async Task<DataResult<dynamic>> GetUserAddressById(int id, string fname)
        {
            try
            {
                if (id <= 0 || string.IsNullOrEmpty(fname))
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, null, new ValidationResultModel() { Message = "Id must not be less than 0" });
                }
                var providerData = await _dataUow.UserAddress.GetAllWithNoTracking().Where(p => p.UserProfileId == id).FirstOrDefaultAsync();

                if (providerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, providerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "Entered data does not match our records. Please try again.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }
        [HttpPost("SaveUserAddress")]
        public async Task<dynamic> SaveUserAddress(UserAddress address)
        {
            try
            {
                _dataUow.UserAddress.Add(address);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("UpdateUserAddress")]
        public async Task<dynamic> UpdateUserAddress(UserAddress address)
        {
            try
            {
                _dataUow.UserAddress.Update(address);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("DeleteUserAddress")]
        public async Task<dynamic> DeleteUserAddress(UserAddress address)
        {
            try
            {
                _dataUow.UserAddress.Delete(address);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Product Table
        [HttpGet("GetProductList")]
        public async Task<dynamic> GetProductList()
        {
            try
            {
                var providerData = await _dataUow.Product.GetAll().ToListAsync();
                return providerData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpGet("GetProductsById/{id}")]
        public async Task<DataResult<dynamic>> GetProductsById(int id, string fname)
        {
            try
            {
                if (id <= 0 || string.IsNullOrEmpty(fname))
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, null, new ValidationResultModel() { Message = "Id must not be less than 0" });
                }
                var providerData = await _dataUow.Product.GetAllWithNoTracking().Where(p => p.ProductId == id).FirstOrDefaultAsync();

                if (providerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, providerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "Entered data does not match our records. Please try again.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }
        [HttpPost("SaveProduct")]
        public async Task<dynamic> SaveProduct(Product product)
        {
            try
            {
                _dataUow.Product.Add(product);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("UpdateProduct")]
        public async Task<dynamic> UpdateProduct(Product product)
        {
            try
            {
                _dataUow.Product.Update(product);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("DeleteProduct")]
        public async Task<dynamic> DeleteProduct(Product product)
        {
            try
            {
                _dataUow.Product.Delete(product);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Customers Table
        [HttpGet("GetCustomersList")]
        public async Task<dynamic> GetCustomersList()
        {
            try
            {
                var providerData = await _dataUow.Customers.GetAll().ToListAsync();
                return providerData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpGet("GetCustomersById/{id}")]
        public async Task<DataResult<dynamic>> GetCustomersById(int id, string fname)
        {
            try
            {
                if (id <= 0 || string.IsNullOrEmpty(fname))
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, null, new ValidationResultModel() { Message = "Id must not be less than 0" });
                }
                var providerData = await _dataUow.Customers.GetAllWithNoTracking().Where(p => p.CustomerId == id).FirstOrDefaultAsync();

                if (providerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, providerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "Entered data does not match our records. Please try again.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }
        [HttpPost("SaveCustomers")]
        public async Task<dynamic> SaveCustomers(Customers customer)
        {
            try
            {
                _dataUow.Customers.Add(customer);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("UpdateCustomers")]
        public async Task<dynamic> UpdateCustomers(Customers customer)
        {
            try
            {
                _dataUow.Customers.Update(customer);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("DeleteCustomers")]
        public async Task<dynamic> DeleteCustomers(Customers customer)
        {
            try
            {
                _dataUow.Customers.Delete(customer);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Order Table
        [HttpGet("GetOrdersList")]
        public async Task<dynamic> GetOrdersList()
        {
            try
            {
                var providerData = await _dataUow.Orders.GetAll().ToListAsync();
                return providerData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpGet("GetOrdersById/{id}")]
        public async Task<DataResult<dynamic>> GetOrdersById(int id, string fname)
        {
            try
            {
                if (id <= 0 || string.IsNullOrEmpty(fname))
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, null, new ValidationResultModel() { Message = "Id must not be less than 0" });
                }
                var providerData = await _dataUow.Orders.GetAllWithNoTracking().Where(p => p.OrderId == id).FirstOrDefaultAsync();

                if (providerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, providerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "Entered data does not match our records. Please try again.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }
        [HttpPost("SaveOrders")]
        public async Task<dynamic> SaveOrders(Orders order)
        {
            try
            {
                _dataUow.Orders.Add(order);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("UpdateOrders")]
        public async Task<dynamic> UpdateOrders(Orders order)
        {
            try
            {
                _dataUow.Orders.Update(order);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("DeleteOrders")]
        public async Task<dynamic> DeleteOrders(Orders order)
        {
            try
            {
                _dataUow.Orders.Delete(order);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

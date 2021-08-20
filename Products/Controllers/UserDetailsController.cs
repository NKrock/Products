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
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetails _iuserdetails;
        public UserDetailsController(IUserDetails iuserdetails)
        {
            _iuserdetails = iuserdetails;
        }


        [HttpGet("GetAllUserDetails")]
        public async Task<DataResult<dynamic>> GetAllUserDetails()
        {
            try
            {
                var UserDetailsData = await _iuserdetails.GetAllUserDetails();


                if (UserDetailsData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, UserDetailsData);
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


        [HttpGet("GetUserDetailsById/{​​​​​​​id}​​​​​​​")]
        public async Task<DataResult<dynamic>> GetUserDetailsById(int id)
        {
            try
            {
                var UserDetailsData = await _iuserdetails.GetUserDetailsById(id);


                if (UserDetailsData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, UserDetailsData);
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


        [HttpPost("SaveUserDetails")]
        public async Task<DataResult<dynamic>> SaveUserDetails([FromBody] Userdetails userDetails)
        {
            try
            {
                var UserDetailsData = await _iuserdetails.SaveUserDetails(userDetails);


                if (UserDetailsData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, UserDetailsData);
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


        [HttpPost("UpdateUserDetails")]

        public async Task<DataResult<dynamic>> UpdateUserDetails([FromBody] Userdetails userDetails)
        {
            try
            {
                var UserDetailsData = await _iuserdetails.UpdateUserDetails(userDetails);


                if (UserDetailsData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, UserDetailsData);
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


        [HttpPost("DeleteUserDetails")]
        public async Task<DataResult<dynamic>> DeleteUserDetails([FromBody] Userdetails userDetails)
        {
            try
            {
                var UserDetailsData = await _iuserdetails.DeleteUserDetails(userDetails);


                if (UserDetailsData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, UserDetailsData);
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

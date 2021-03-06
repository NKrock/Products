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

    [ApiController]
    public class SecretQuestionsController : ControllerBase
    {
        private readonly ISecretQuestions _isecretQuestions;
        public SecretQuestionsController(ISecretQuestions isecretQuestions)
        {
            _isecretQuestions = isecretQuestions;
        }
        [HttpGet("GetAllSecretQuestions")]
        public async Task<DataResult<dynamic>> GetAllSecretQuestions()
        {
            try
            {
                var secretQuestionsData = await _isecretQuestions.GetAllSecretQuestions();

                if (secretQuestionsData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, secretQuestionsData);
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

        [HttpGet("GetSecretQuestionById/{id}")]
        public async Task<DataResult<dynamic>> GetSecretQuestionById(int id)
        {
            try
            {
                var secretQuestionsData = await _isecretQuestions.GetSecretQuestionById(id);

                if (secretQuestionsData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, secretQuestionsData);
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

        [HttpPost("SaveSecretQuestion")]
        public async Task<DataResult<dynamic>> SaveSecretQuestion([FromBody] SecretQuestions secretQuestions)
        {
            try
            {
                var secretQuestionsData = await _isecretQuestions.SaveSecretQuestion(secretQuestions);

                if (secretQuestionsData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, secretQuestionsData);
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

        [HttpPost("UpdateSecretQuestion")]
        public async Task<DataResult<dynamic>> UpdateSecretQuestion([FromBody] SecretQuestions secretQuestions)
        {
            try
            {
                var secretQuestionsData = await _isecretQuestions.UpdateSecretQuestion(secretQuestions);

                if (secretQuestionsData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, secretQuestionsData);
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

        [HttpPost("DeleteSecretQuestion")]
        public async Task<DataResult<dynamic>> DeleteSecretQuestion([FromBody] SecretQuestions secretQuestions)
        {
            try
            {
                var secretQuestionsData = await _isecretQuestions.DeleteSecretQuestion(secretQuestions);

                if (secretQuestionsData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, secretQuestionsData);
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

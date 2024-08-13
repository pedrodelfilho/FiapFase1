using AutoMapper;
using FiapFase1.Api.Controllers.Shared;
using FiapFase1.Domain.Entities.Responses;
using FiapFase1.Domain.Exceptions;
using FiapFase1.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FiapFase1.Api.Controllers.v1
{
    public class DDDController : ApiControllerBase
    {
        private readonly IDDDService _idDDService;

        public DDDController(IDDDService idDDService)
        {
            _idDDService = idDDService;
        }


        /// <summary>
        /// Comando responsável em obter todos DDDs 
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("obtertodos")]
        public async Task<ActionResult> ObterTodosDDDs()
        {
            try
            {
                var ddds = await _idDDService.Get();

                return Ok(new BaseResponse
                {
                    Message = "Busca por DDDs realizado com sucesso!",
                    Success = true,
                    Errors = null,
                    Data = ddds
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(ResponseException.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, ResponseException.ApplicationErrorMessage());
            }
        }
    }
}

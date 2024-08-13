using AutoMapper;
using FiapFase1.Api.Controllers.Shared;
using FiapFase1.Domain.Entities.Models;
using FiapFase1.Domain.Entities.Requests;
using FiapFase1.Domain.Entities.Responses;
using FiapFase1.Domain.Exceptions;
using FiapFase1.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FiapFase1.Api.Controllers.v1
{
    public class ContatoController : ApiControllerBase
    {
        private readonly IContatoService _contatoService;
        private readonly IMapper _mapper;

        public ContatoController(IContatoService contatoService, IMapper mapper)
        {
            _contatoService = contatoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Controle responsável por cadastrar novo contato
        /// </summary>
        /// <param name="contatoRequest"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("cadastrar")]
        public async Task<ActionResult> CadastrarContato([FromBody] RegistrarContatoRequest contatoRequest)
        {
            try
            {
                var contato = _mapper.Map<Contato>(contatoRequest);

                var contatoCreated = await _contatoService.Create(contato, contatoRequest.NrDDD);

                return Ok(new BaseResponse
                {
                    Message = "Contato cadastrado com sucesso!",
                    Success = true,
                    Errors = null,
                    Data = contatoCreated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(ResponseException.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseException.ApplicationErrorMessage());
            }


        }

        /// <summary>
        /// Comando responsável por remover contato
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpDelete("remover/{id}")]
        public async Task<ActionResult> RemoverContato(long id)
        {
            try
            {
                await _contatoService.Remove(id);

                return Ok(new BaseResponse
                {
                    Message = "Contato removido com sucesso!",
                    Success = true,
                    Errors = null,
                    Data = id
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

        /// <summary>
        /// Comando responsável em atualizar contato
        /// </summary>
        /// <param name="contatoRequest"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPut("atualizar")]
        public async Task<ActionResult> AtualizarContato([FromBody] AtualizarContatoRequest contatoRequest)
        {
            try
            {
                var contato = _mapper.Map<Contato>(contatoRequest);
                var contatoUpdate = await _contatoService.Update(contato, contatoRequest.NrDDD);

                return Ok(new BaseResponse
                {
                    Message = "Contato atualizado com sucesso!",
                    Success = true,
                    Errors = null,
                    Data = contatoUpdate
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(ResponseException.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseException.ApplicationErrorMessage());
            }
        }

        /// <summary>
        /// Comando responsável em obter todos contatos
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("obtertodos")]
        public async Task<ActionResult> ObterTodosContatos()
        {
            try
            {
                var allContatos = await _contatoService.Get();

                return Ok(new BaseResponse
                {
                    Message = "Busca por contatos realizado com sucesso!",
                    Success = true,
                    Errors = null,
                    Data = allContatos
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

        /// <summary>
        /// Comando responsável por obter contato pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("obterporid/{id}")]
        public async Task<ActionResult> ObterContatoPorId(long id)
        {
            try
            {
                var contato = await _contatoService.Get(id);

                return Ok(new BaseResponse
                {
                    Message = $"Pesquisa realizada com sucesso!",
                    Success = true,
                    Errors = null,
                    Data = contato
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

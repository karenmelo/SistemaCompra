using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;
using SistemaCompra.Application.SolicitacaoCompra.Query.ObterCompra;
using System;

namespace SistemaCompra.API.SolicitacaoCompra
{
    public class SolicitacaoCompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SolicitacaoCompraController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet, Route("solicitacaoCompra/{id}")]
        public IActionResult Obter(Guid id)
        {
            var query = new ObterSolicitacaoCompraQuery() { Id = id };
            var solicitacaoCompraViewModel = _mediator.Send(query);
            return Ok(solicitacaoCompraViewModel);
        }

        [HttpPost, Route("solicitacaoCompra/registrar")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CadastrarSolicitacaoCompra([FromBody] RegistrarSolicitacaoCompraCommand registrarSolicitacaoCompraCommand)
        {
            _mediator.Send(registrarSolicitacaoCompraCommand);
            return StatusCode(201);
        }
    }
}

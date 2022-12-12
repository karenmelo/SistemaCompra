using MediatR;
using System;

namespace SistemaCompra.Application.SolicitacaoCompra.Query.ObterCompra
{
    public class ObterSolicitacaoCompraQuery : IRequest<ObterSolicitacaoCompraViewModel>
    {
        public Guid Id { get; set; }
    }
}

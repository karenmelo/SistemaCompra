using System;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public interface ISolicitacaoCompraRepository
    {
        void RegistrarCompra(SolicitacaoCompra solicitacaoCompra);

        SolicitacaoCompra Obter(Guid id);
    }
}

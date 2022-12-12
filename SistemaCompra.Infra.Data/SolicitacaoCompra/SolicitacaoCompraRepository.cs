using System;
using System.Linq;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.Produto
{
    public class SolicitacaoCompraRepository : SolicitacaoCompraAgg.ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext context;

        public SolicitacaoCompraRepository(SistemaCompraContext context)
        {
            this.context = context;
        }

        public void RegistrarCompra(SolicitacaoCompraAgg.SolicitacaoCompra entity)
        {
            context.Set<SolicitacaoCompraAgg.SolicitacaoCompra>().Add(entity);
        }

        public SolicitacaoCompraAgg.SolicitacaoCompra Obter(Guid id)
        {
            return context.Set<SolicitacaoCompraAgg.SolicitacaoCompra>().Where(c => c.Id == id).FirstOrDefault();
        }
    }
}

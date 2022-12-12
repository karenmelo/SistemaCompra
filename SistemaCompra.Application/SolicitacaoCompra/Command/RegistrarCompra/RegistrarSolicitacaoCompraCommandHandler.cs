using MediatR;
using SistemaCompra.Application.DTO;
using SistemaCompra.Infra.Data.UoW;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarSolicitacaoCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarSolicitacaoCompraCommand, bool>
    {
        private readonly SolicitacaoCompraAgg.ISolicitacaoCompraRepository solicitacaoCompraRepository;
        private readonly ProdutoAgg.IProdutoRepository produtoRepository;

        public RegistrarSolicitacaoCompraCommandHandler(SolicitacaoCompraAgg.ISolicitacaoCompraRepository solicitacaoCompraRepository, IUnitOfWork uow, IMediator mediator, ProdutoAgg.IProdutoRepository produtoRepository) : base(uow, mediator)
        {
            this.solicitacaoCompraRepository = solicitacaoCompraRepository;
            this.produtoRepository = produtoRepository;
        }

        public Task<bool> Handle(RegistrarSolicitacaoCompraCommand request, CancellationToken cancellationToken)
        {
            var solicitacaoCompra = new SolicitacaoCompraAgg.SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor);
            solicitacaoCompra.RegistrarCompra(MapearItem(request.Itens, solicitacaoCompra));
            solicitacaoCompraRepository.RegistrarCompra(solicitacaoCompra);

            Commit();
            PublishEvents(solicitacaoCompra.Events);

            return Task.FromResult(true);
        }

        public IEnumerable<SolicitacaoCompraAgg.Item> MapearItem(IEnumerable<ItemDTO> listaDeItens, SolicitacaoCompraAgg.SolicitacaoCompra solicitacaoCompra)
        {
            foreach (var item in listaDeItens)
            {
                var produto = produtoRepository.Obter(item.ProdutoId);
                solicitacaoCompra.AdicionarItem(produto, item.Quantidade);
            }
            return solicitacaoCompra.Itens;
        }
    }
}

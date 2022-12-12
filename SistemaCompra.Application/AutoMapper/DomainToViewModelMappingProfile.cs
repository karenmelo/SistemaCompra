using AutoMapper;
using SistemaCompra.Application.DTO;
using SistemaCompra.Application.Produto.Query.ObterProduto;
using SistemaCompra.Application.SolicitacaoCompra.Query.ObterCompra;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProdutoAgg.Produto, ObterProdutoViewModel>()
                .ForMember(d => d.Preco, o => o.MapFrom(src => src.Preco.Value));

            CreateMap<SolicitacaoCompraAgg.SolicitacaoCompra, ObterSolicitacaoCompraViewModel>()
               .ForMember(d => d.TotalGeral, o => o.MapFrom(src => src.TotalGeral.Value));

            CreateMap<SolicitacaoCompraAgg.Item, ItemDTO>()
               .ForMember(d => d.Quantidade, o => o.MapFrom(src => src.Qtde))
               .ForMember(d => d.ProdutoId, o => o.MapFrom(src => src.Produto));

            CreateMap<ItemDTO, SolicitacaoCompraAgg.Item>()
               .ForMember(d => d.Qtde, o => o.MapFrom(src => src.Quantidade))
               .ForMember(d => d.Produto, o => o.MapFrom(src => src.ProdutoId));
        }
    }
}

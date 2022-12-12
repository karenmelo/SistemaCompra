using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }
        public CondicaoPagamento CondicaoPagamento { get; private set; }

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
            Itens = new List<Item>();
            TotalGeral = new Money(0);
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            Itens.Add(new Item(produto, qtde));
        }

        public void ValidarExisteItens(IEnumerable<Item> itens)
        {
            if (itens.Count() < Produto.MIN_UNIDADES_ITEM) throw new BusinessRuleException($"A solicitação de compra deve possuir ao menos 1 item!");
        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {
            ValidarExisteItens(itens);
            var t = itens.Select(x => x.Subtotal.Value);
            CalcularValorTotal(itens);
            CondicaoPagamento = ValidarCondicaoPagamento(TotalGeral);
            AddEvent(new CompraRegistradaEvent(Id, itens, TotalGeral.Value));
        }

        private void CalcularValorTotal(IEnumerable<Item> itens)
        {
            foreach (var item in itens)
            {
                TotalGeral = TotalGeral.Add(item.Subtotal);
            }
        }

        public CondicaoPagamento ValidarCondicaoPagamento(Money totalGeral)
        {
            if (totalGeral.Value < 50000) return new CondicaoPagamento(0);

            if (totalGeral.Value > 50000 && totalGeral.Value < 99999) return new CondicaoPagamento(30);

            if (totalGeral.Value > 100000 && totalGeral.Value < 199999) return new CondicaoPagamento(60);

            if (totalGeral.Value > 200000) return new CondicaoPagamento(90);

            return new CondicaoPagamento(0);
        }
    }
}

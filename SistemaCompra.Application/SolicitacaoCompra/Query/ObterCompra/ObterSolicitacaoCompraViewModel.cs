using System;

namespace SistemaCompra.Application.SolicitacaoCompra.Query.ObterCompra
{
    public class ObterSolicitacaoCompraViewModel
    {
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public DateTime Data { get; set; }
        public decimal TotalGeral { get; set; }
        public int Situacao { get; set; }
        public int CondicaoPagamento { get; set; }
    }
}

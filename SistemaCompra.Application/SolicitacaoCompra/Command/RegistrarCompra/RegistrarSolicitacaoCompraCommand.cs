using MediatR;
using SistemaCompra.Application.DTO;
using System.Collections.Generic;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarSolicitacaoCompraCommand : IRequest<bool>
    {
        public string NomeFornecedor { get; set; }
        public string UsuarioSolicitante { get; set; }

        public IEnumerable<ItemDTO> Itens { get; set; }

    }
}

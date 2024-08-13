using FiapFase1.Domain.Entities.Models;
using FiapFase1.Domain.Entities.Requests;

namespace FiapFase1.UI.Interfaces
{
    public interface IContatoService
    {
        Task<Contato> CadastrarContato(RegistrarContatoRequest request);
        Task RemoverContato(long id);
        Task<Contato> AtualizarContato(AtualizarContatoRequest request);
        Task<List<Contato>> ObterTodosContatos();
        Task<Contato> ObterContatoPorId(long id);
    }
}

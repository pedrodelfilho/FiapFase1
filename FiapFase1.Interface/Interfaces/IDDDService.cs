using FiapFase1.Domain.Entities.Models;

namespace FiapFase1.UI.Interfaces
{
    public interface IDDDService
    {
        Task<List<DDD>> ObterTodosDDDs();
    }
}

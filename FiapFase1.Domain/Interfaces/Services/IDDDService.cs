using FiapFase1.Domain.Entities.Models;

namespace FiapFase1.Domain.Interfaces.Services
{
    public interface IDDDService
    {
        Task<DDD> Create(DDD agendamento);
        Task<DDD> Update(DDD agendamento);
        Task Remove(long id);
        Task<DDD> Get(long id);
        Task<List<DDD>> Get();
    }
}

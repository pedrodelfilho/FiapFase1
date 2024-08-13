using FiapFase1.Data.Context;
using FiapFase1.Domain.Entities.Models;
using FiapFase1.Domain.Interfaces.Repositories;

namespace FiapFase1.Data.Repositories
{
    public class ContatoRepository : BaseRepository<Contato>, IContatoRepository
    {
        private readonly DataContext _context;

        public ContatoRepository(DataContext context) : base(context) 
        {
            _context = context;
        }
    }
}

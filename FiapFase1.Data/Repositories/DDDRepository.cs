using FiapFase1.Data.Context;
using FiapFase1.Domain.Entities.Models;
using FiapFase1.Domain.Interfaces.Repositories;

namespace FiapFase1.Data.Repositories
{
    public class DDDRepository : BaseRepository<DDD>, IDDDRepository
    {
        private readonly DataContext _context;

        public DDDRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}

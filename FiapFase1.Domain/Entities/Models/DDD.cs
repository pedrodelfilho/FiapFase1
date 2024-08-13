using System.ComponentModel.DataAnnotations;
using TechChallenge.Domain.Entities;

namespace FiapFase1.Domain.Entities.Models
{
    public class DDD : BaseModel
    {
        [Required]
        public byte NrDDD { get; set; }

        public ICollection<Contato> Contatos { get; set; } = new List<Contato>();

        public static DDD SetDDD(long dddId, byte nrDDD)
        {
            return new DDD
            {
                NrDDD = nrDDD,
                Id = dddId
            };
        }
    }
}

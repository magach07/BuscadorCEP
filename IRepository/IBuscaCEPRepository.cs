using BuscaCEP.Models;
using System.Threading.Tasks;

namespace BuscaCEP.IRepository
{
    public interface IBuscaCEPRepository
    {
        public Task<EnderecoReturn> GetEnderecoByCEP(string cep);
    }
}

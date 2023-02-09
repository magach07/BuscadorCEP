using Refit;
using System.Threading.Tasks;

namespace BuscaCEP.IRefitService
{
    public interface ICepApiService
    {
        [Get("/ws/{cep}/json")]
        Task<CepBuscarDTO> GetAddressAsync(string cep);
    }
}

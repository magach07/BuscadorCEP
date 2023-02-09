using BuscaCEP.IRefitService;
using BuscaCEP.IRepository;
using BuscaCEP.Models;
using Refit;
using System.Threading.Tasks;

namespace BuscaCEP.Repository
{
    public class BuscaCEPRepository : IBuscaCEPRepository
    {
        public async Task<EnderecoReturn> GetEnderecoByCEP (string cep)
        {
            var cepBuscar = RestService.For<ICepApiService>("https://viacep.com.br/");
            var endereco = await cepBuscar.GetAddressAsync(cep);

            EnderecoReturn end = new EnderecoReturn();

            end.Rua = endereco.Logradouro;
            end.Numero = endereco.Complemento;
            end.Bairro = endereco.Bairro;
            end.Cidade = endereco.Localidade;
            end.UF = endereco.Uf;

            return end;
        }
    }
}

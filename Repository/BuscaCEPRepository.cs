using BuscaCEP.IRefitService;
using BuscaCEP.IRepository;
using BuscaCEP.Models;
using Newtonsoft.Json;
using Refit;
using System.Net.Http;
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
            end.DDD = endereco.Ddd;

            return end;
        }

        public async Task<EnderecoReturn> ViaCEPService(string cep)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://viacep.com.br/ws/" + cep + "/json");

            var data = await response.Content.ReadAsStringAsync();

            var json = JsonConvert.DeserializeObject<CepBuscarDTO>(data);

            EnderecoReturn end = new EnderecoReturn();

            end.Rua = json.Logradouro;
            end.Numero = json.Complemento;
            end.Bairro = json.Bairro;
            end.Cidade = json.Localidade;
            end.UF = json.Uf;
            end.DDD = json.Ddd;

            return end;
        }
    }
}

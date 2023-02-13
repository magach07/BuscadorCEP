using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCEP.ApiViaCEP
{
    public class ApiViaCEPService
    {
        public static async Task ViaCEPService (string cep)
        {
            var httpClient = new HttpClient ();

            var response = await httpClient.GetAsync ("https://viacep.com.br/ws/" + cep + "/json");

            var data = await response.Content.ReadAsStringAsync ();
        }
    }
}

using BuscaCEP.IRefitService;
using BuscaCEP.IRepository;
using BuscaCEP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Threading.Tasks;

namespace BuscaCEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscaCEPController : ControllerBase
    {
        private readonly IBuscaCEPRepository _buscaCEPRepository;

        public BuscaCEPController (IBuscaCEPRepository buscaCEPRepository)
        {
            _buscaCEPRepository = buscaCEPRepository;
        }

        [HttpPost]
        [Route("/GetEnderecoWithRefit/")]
        public async Task<EnderecoReturn> GetEnderecoFromCEP(string cep)
        {
            var end = await _buscaCEPRepository.ViaCEPService(cep);

            return end;
        }

        [HttpPost]
        [Route("/GetEnderecoWithoutRefit/")]
        public async Task<EnderecoReturn> GetEnderecoFromCEPWithRefit(string cep)
        {
            var end = await _buscaCEPRepository.GetEnderecoByCEP(cep);

            return end;
        }
    }
}

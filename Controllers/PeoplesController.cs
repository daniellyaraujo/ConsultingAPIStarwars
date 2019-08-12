using ConstruindoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace ConstruindoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class PeoplesController : ControllerBase
    {
        private string _host = "https://swapi.co/api";
        private readonly HttpClient _client;

        public PeoplesController()
        {
            _client = new HttpClient();
        }

        // GET api/values
        //[HttpGet("{id}")]
        //public ActionResult GetPeopleById(int id)
        //{
        //    string url = $"{ _host}/people/{ id}";

        //    var result = _client.GetAsync(url).Result;
        //    var pessoa = result.Content.ReadAsAsync<Pessoas>().Result;

        //    return new OkObjectResult(pessoa);
        //}

        [HttpGet]
        public ActionResult GetPeopleAll()
        {
            string url = $"{_host}/people";

            var result = _client.GetAsync(url).Result;
            var listaPessoas = result.Content.ReadAsAsync<ListPessoas>().Result;

            var OrdenedbyFilms = new List<Pessoas>();
            var soma = 0;
            var qtdPessoas = 0;
            
            foreach (var pessoa in listaPessoas.Results)
            {
                var pesoDaPessoa = pessoa.Mass;

                var especieDaPessoa = pessoa.Species.ToList()[0];

                if (string.Equals(especieDaPessoa, "https://swapi.co/api/species/1/"))
                {
                    soma = pesoDaPessoa + soma;
                    qtdPessoas = qtdPessoas + 1;
                }
            }
            var mediaPeso = soma / qtdPessoas;

            return new OkObjectResult(mediaPeso);
        }
    }
}
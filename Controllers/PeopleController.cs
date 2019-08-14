using ConstruindoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace ConstruindoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class PeopleController : ControllerBase
    {
        private string _host = "https://swapi.co/api";
        private readonly HttpClient _client;

        public PeopleController()
        {
            _client = new HttpClient();
        }

        //api de numero 1
        [HttpGet]
        public ActionResult GetPeopleByFilm()
        {
            string url = $"{_host}/people";
            var result = _client.GetAsync(url).Result;
            var listaPessoas = result.Content.ReadAsAsync<ListPessoas>().Result;
            Pessoas maiorfilme = listaPessoas.Results[0];
            var OrdenedbyFilms = new List<Pessoas>();

            foreach (var pessoa in listaPessoas.Results)
            {
                var filmesDaPessoa = pessoa.Films.Count;
                if (filmesDaPessoa > maiorfilme.Films.Count)
                {
                    maiorfilme = pessoa;
                }
            }
            return new OkObjectResult(maiorfilme);
        }



        // api do exercicio numero 2
        //  GET api/values

        [HttpGet("{id}")]
        public ActionResult GetPeopleById(int id)
        {
            string url = $"{ _host}/people/{ id}";
            var result = _client.GetAsync(url).Result;
            var pessoa = result.Content.ReadAsAsync<Pessoas>().Result;
            return new OkObjectResult(pessoa);
        }


        //api do exercicio de numero 3
        [HttpGet("human")]
        public ActionResult GetHumanMass()
        {
            string url = $"{_host}/people";

            var result = _client.GetAsync(url).Result;
            var listaPessoas = result.Content.ReadAsAsync<ListPessoas>().Result;

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
            var peso = new Peso();
            peso.MediaPeso = soma / qtdPessoas;

            return new OkObjectResult(peso);
        }

    }
}
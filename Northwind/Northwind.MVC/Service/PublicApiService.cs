using Newtonsoft.Json;
using Northwind.MVC.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Northwind.MVC.Service
{
    public class PublicApiService
    {
		private readonly string url = "https://rickandmortyapi.com/api/" ;

        public async Task<AllResultsViewModel> GetAllAsync()
		{
			try
			{
                var json = await CallApiAsync("character/");
                List<ResultsViewModel> results = new List<ResultsViewModel>();
                results.Add(ParsePersonajes(json));
                
                for (int i = 2; i < 8; i++)
                {
                    json = await CallApiAsync("character/?page="+i);
                    results.Add(ParsePersonajes(json));
                }

                AllResultsViewModel allResults = new AllResultsViewModel
                {
                    Results = results,
                };
                return allResults;
            }
			catch (Exception)
			{
				throw;
			}
		}
        public async Task<PersonajesViewModel> GetByIDAsync(int id)
        {
            try
            {
                var json = await CallApiAsync("character/" + id);
                return ParsePersonaje(json);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public PersonajesViewModel ParsePersonaje(string json)
        {
			try
			{
                PersonajesViewModel personaje = JsonConvert.DeserializeObject<PersonajesViewModel>(json);
                return personaje;
			}
			catch (Exception)
			{
				throw;
			}
        }
        public ResultsViewModel ParsePersonajes(string json)
        {
            try
            {
                ResultsViewModel results = JsonConvert.DeserializeObject<ResultsViewModel>(json);
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> CallApiAsync(string peticion)
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(url + peticion);
                return json;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
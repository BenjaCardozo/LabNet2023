using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public async Task<ResultsViewModel> GetPageAsync(int page)
		{
			try
			{
                var json = await CallApiAsync("character?page=" + page);
                while (!IsValidJson(json))
                {
                    json = await CallApiAsync("character?page=" + page);
                }
                ResultsViewModel results = (ParsePersonajes(json));
                return results;
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
                while (!IsValidJson(json))
                {
                    json = await CallApiAsync("character/" + id);
                }
                PersonajesViewModel personaje = ParsePersonaje(json);
                return personaje;
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
        public bool IsValidJson(string json)
        {
            try
            {
                JToken.Parse(json);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }
    }
}
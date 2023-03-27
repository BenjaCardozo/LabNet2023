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

        public async Task<ResultsPersonajesViewModel> GetAllAsync()
		{
			try
			{
                var json = await CallApiAsync("character/");

                return ParsePersonajes(json);
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
        public ResultsPersonajesViewModel ParsePersonajes(string json)
        {
            try
            {
                ResultsPersonajesViewModel results = JsonConvert.DeserializeObject<ResultsPersonajesViewModel>(json);
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
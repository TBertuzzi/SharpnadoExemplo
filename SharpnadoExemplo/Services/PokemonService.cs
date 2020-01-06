using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SharpnadoExemplo.Models;
using HttpExtension;
using System.Diagnostics;

namespace SharpnadoExemplo.Services
{
    public class PokemonService     {         public async Task<List<Pokemon>> GetPokemonsAsync()         {
            List<Pokemon> pokemons = new List<Pokemon>();

            try
            {
                var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                string api = "https://pokeapi.co/api/v2/pokemon/";

                for (int i = 1; i < 20; i++)
                {
                    var response = await httpClient.
                        GetAsync<Pokemon>($"{api}{i}");

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        pokemons.Add(response.Value);
                    }
                    else
                    {
                        Debug.WriteLine(response.Error.Message);
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return pokemons;         }     } 
}

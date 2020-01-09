using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Sharpnado.Presentation.Forms.ViewModels;
using SharpnadoExemplo.Models;
using SharpnadoExemplo.Services;

namespace SharpnadoExemplo.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        //Anterior
        public ObservableCollection<Pokemon> Pokemons { get; }
      //  public ViewModelLoader<ObservableCollection<Teste>> Pokemons { get; }
        private readonly PokemonService _pokemonService;

       


        public MainViewModel()
        {
            //Anterior
            Pokemons = new ObservableCollection<Pokemon>();
            _pokemonService = new PokemonService();

            //Pokemons = new
            //ViewModelLoader<ObservableCollection<Teste>>(null,
            //    null);
        }

       


        public override async Task LoadAsync()
        {
            Ocupado = true;
            try
            {
                //Antiga Logica de Carregamento
                var pokemonsAPI = await _pokemonService.GetPokemonsAsync();

                Pokemons.Clear();

                foreach (var pokemon in pokemonsAPI)
                {
                    pokemon.Image = GetImageStreamFromUrl(pokemon.Sprites.FrontDefault.AbsoluteUri);
                    Pokemons.Add(pokemon);
                }

                // Pokemons.Load(CarregarPokemonsAsync);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro", ex.Message);
            }
            finally
            {
                Ocupado = false;
            }

        }



        private async Task<ObservableCollection<Pokemon>> CarregarPokemonsAsync()
        {
            return new ObservableCollection<Pokemon>(
            await _pokemonService.GetPokemonsAsync());
        }

        public static byte[] GetImageStreamFromUrl(string url)
        {
            try
            {
                using (var webClient = new HttpClient())
                {
                    var imageBytes = webClient.GetByteArrayAsync(url).Result;

                    return imageBytes;

                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return null;

            }
        }
    }
}

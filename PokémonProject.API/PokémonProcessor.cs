using PokémonProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokémonProject.API
{
    public class PokémonProcessor
    {
        public static async Task<PokémonModel> LoadPokémon(string name)
        {
            string url = ApiHelper.ApiClient.BaseAddress.ToString() + name.ToLower();

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    PokémonModel pokémon = await response.Content.ReadAsAsync<PokémonModel>();

                    return pokémon;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}

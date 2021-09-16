using PokémonProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokémonProject.API
{
    public class PokémonManager
    {
        public static List<PokémonModel> Pokémons { get; set; } = new List<PokémonModel>();

        public async Task<PokémonModel> GetPokémon(string name)
        {
            PokémonModel pokemon = new PokémonModel();

            pokemon = await PokémonProcessor.LoadPokémon(name);

            return pokemon;
        }
    }
}

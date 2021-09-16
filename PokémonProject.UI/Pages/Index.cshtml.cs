using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PokémonProject.API;
using PokémonProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokémonProject.UI.Pages
{
    public class IndexModel : PageModel
    {
        public PokémonModel Pokémon { get; set; }
        public SelectList listOfPokemons { get; set; }
        [BindProperty]
        public string PokemonName { get; set; }
        public IActionResult OnGet()
        {
            var list = Enum.GetNames<Pokémon>().ToList();
            listOfPokemons = new SelectList(list);

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            PokémonManager pokémonManager = new PokémonManager();

            Pokémon = await pokémonManager.GetPokémon(PokemonName);
            Pokémon.Image = PokemonName + ".png";

            PokémonManager.Pokémons.Add(Pokémon);

            return RedirectToPage("/ShowPokemon");
        }
    }
}

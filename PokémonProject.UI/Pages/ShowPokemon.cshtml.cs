using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PokémonProject.API;
using PokémonProject.Data;

namespace PokémonProject.UI.Pages
{
    public class ShowPokemonModel : PageModel
    {
        public List<PokémonModel> pokemonList { get; set; }
        public PokémonModel Pokémon { get; set; }
        public void OnGet()
        {
            pokemonList = PokémonManager.Pokémons;


            string stringFavorites = HttpContext.Session.GetString("Favorites");
            var favorites = new List<PokémonModel>();

            if (!String.IsNullOrEmpty(stringFavorites))
            {
                favorites = JsonConvert.DeserializeObject<List<PokémonModel>>(stringFavorites);
            }
        }
        public IActionResult OnPost(string name)
        {
            Pokémon = PokémonManager.Pokémons.Where(c => c.Name == name).FirstOrDefault();
            Pokémon.Favorite = true;

            string stringFavorites = HttpContext.Session.GetString("Favorites");

            var favorites = new List<PokémonModel>();

            if (!String.IsNullOrEmpty(stringFavorites))
            {
                favorites = JsonConvert.DeserializeObject<List<PokémonModel>>(stringFavorites);
            }
            favorites.Add(Pokémon);

            if (ModelState.IsValid)
            {
                stringFavorites = JsonConvert.SerializeObject(favorites);

                HttpContext.Session.SetString("Favorites", stringFavorites);

                return RedirectToPage("/Favorites");
            }
            else
            {
                return Redirect("/ShowPokemon");
            }

        }
    }
}

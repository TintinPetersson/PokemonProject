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
    public class FavoritesModel : PageModel
    {
        public List<PokémonModel> PokemonFavorites { get; set; }
        public PokémonModel Pokémon { get; set; }
        public void OnGet()
        {
            //----Prepare and Get Cookies

            string stringFavorites = HttpContext.Session.GetString("Favorites");

            if (!String.IsNullOrEmpty(stringFavorites))
            {
                PokemonFavorites = JsonConvert.DeserializeObject<List<PokémonModel>>(stringFavorites);
            }
        }
        public IActionResult OnPost(string name)
        {
            string stringFavorites = HttpContext.Session.GetString("Favorites");

            var favorites = new List<PokémonModel>();

            if (!String.IsNullOrEmpty(stringFavorites))
            {
                favorites = JsonConvert.DeserializeObject<List<PokémonModel>>(stringFavorites);
            }

            var pokemonToRemove = favorites.First(c => c.Name == name);

            PokémonManager.Pokémons.Where(c => c.Name == name).FirstOrDefault().Favorite = false;

            favorites.Remove(pokemonToRemove);

            stringFavorites = JsonConvert.SerializeObject(favorites);
            HttpContext.Session.SetString("Favorites", stringFavorites);

            return RedirectToPage("/Favorites");
        }
    }
}

using System;
using System.Collections.Generic;

namespace PokémonProject.Data
{
    public class PokémonModel
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Image { get; set; }
        public bool Favorite { get; set; }
        public List<MoveInfo> Moves { get; set; }
    }
}

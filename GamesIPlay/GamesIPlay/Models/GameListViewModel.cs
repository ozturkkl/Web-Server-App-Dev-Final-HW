
using System.Collections.Generic;

namespace GamesIPlay.Models
{
    public class GameListViewModel
    {
        public List<Genre> Genres {get; set;}
        public List<Game> Games {get; set;}
        public string SelectedGenre {get; set;}
        public string CheckActiveGenre (string genre) => 
            genre == SelectedGenre ? "active" : "";

        public string CheckFavorite(Game game) => game.Favorite ? "fav" : "";
        
    }
}
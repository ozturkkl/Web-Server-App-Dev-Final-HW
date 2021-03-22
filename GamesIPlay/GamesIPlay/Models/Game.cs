using System.ComponentModel.DataAnnotations;

namespace GamesIPlay.Models
{
    public class Game
    {
        public int GameID { get; set; }

        [Required(ErrorMessage = "Please select a genre.")]
        public int GenreID { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Please enter the name of the Game.")]
        public string Name { get; set; }

        public bool Favorite { get; set; }

        [Required(ErrorMessage = "Please enter a description for the game.")]
        public string Description { get; set; }
    }
}
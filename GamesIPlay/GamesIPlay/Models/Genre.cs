using System.ComponentModel.DataAnnotations;

namespace GamesIPlay.Models
{
    public class Genre
    {
        public int GenreID { get; set; }

        [Required(ErrorMessage = "Please enter a genre name.")]
        public string Name { get; set; }
    }
}

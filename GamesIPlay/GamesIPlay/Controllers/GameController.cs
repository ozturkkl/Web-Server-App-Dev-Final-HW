using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GamesIPlay.Models;
using System.Collections.Generic;

namespace GamesIPlay.Controllers
{
    public class GameController : Controller
    {
        private GamesIPlayContext context;
        private List<Genre> genres;

        public GameController(GamesIPlayContext ctx)
        {
            context = ctx;
            genres = context.Genres.OrderBy(g => g.GenreID).ToList();
        }

        public IActionResult Index()
        {
            return RedirectToAction("List", "Game");
        }

        [Route("[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            List<Game> games;
            if (id == "All")
            {
                games = context.Games
                    .OrderBy(g => g.GameID).ToList();
            }
            else
            {
                games = context.Games
                    .Where(g => g.Genre.Name == id)
                    .OrderBy(g => g.GameID).ToList();
            }

            var model = new GameListViewModel {
                Genres = genres,
                Games = games,
                SelectedGenre = id
            };

            return View(model);
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            Game game = new Game();
            game.Genre = context.Genres.Find(1);

            ViewBag.Action = "Add";
            ViewBag.Genres = genres;

            return View("Details", game);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Action = "Update";
            ViewBag.Genres = genres;

            var game = context.Games.Find(id);

            return View("Details", game);
        }
        [HttpPost]
        public IActionResult Update(Game game)
        {
            if (ModelState.IsValid)
            {
                if (game.GameID == 0)
                {
                    context.Games.Add(game);
                }
                else
                {
                    context.Games.Update(game);
                }
                context.SaveChanges();
                TempData["AddedGameID"] = game.GameID;
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                return View("Details");
            }
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Game game = context.Games.Find(id);
            return View(game);
        }
        [HttpPost]
        public IActionResult Delete(Game game)
        {
            context.Games.Remove(game);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
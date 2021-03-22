using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GamesIPlay.Models;

namespace GamesIPlay.Controllers
{
    public class GenreController : Controller
    {
        private GamesIPlayContext context;

        public GenreController(GamesIPlayContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            var genres = context.Genres
                .OrderBy(g => g.GenreID).ToList();

            return View(genres);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Details", new Genre());
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Action = "Update";
            var genre = context.Genres.Find(id);
            return View("Details", genre);
        }
        [HttpPost]
        public IActionResult Update(Genre genre)
        {
            if (ModelState.IsValid)
            {
                if (genre.GenreID == 0)
                {
                    context.Genres.Add(genre);
                }
                else
                {
                    context.Genres.Update(genre);
                }
                context.SaveChanges();
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
            Genre genre = context.Genres.Find(id);
            return View(genre);
        }
        [HttpPost]
        public IActionResult Delete(Genre genre)
        {
            context.Genres.Remove(genre);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
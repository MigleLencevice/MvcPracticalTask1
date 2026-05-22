using Microsoft.AspNetCore.Mvc;
using MvcPracticalTask.Models;
using System.Linq;

namespace MvcPracticalTask.Controllers
{
    public class FilmsController : Controller
    {
        private readonly AppDbContext _context;

        public FilmsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var films = _context.Films.ToList();
            return View(films);
        }

        public IActionResult Details(int id)
        {
            var film = _context.Films.FirstOrDefault(f => f.Id == id);

            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: Films/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Films/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Film film)
        {
            if (ModelState.IsValid)
            {
                _context.Films.Add(film);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(film);
        }

        // GET: Films/Edit/5
        public IActionResult Edit(int id)
        {
            var film = _context.Films.FirstOrDefault(f => f.Id == id);

            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Film film)
        {
            if (id != film.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Films.Update(film);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(film);
        }

        // GET: Films/Delete/5
        public IActionResult Delete(int id)
        {
            var film = _context.Films.FirstOrDefault(f => f.Id == id);

            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var film = _context.Films.FirstOrDefault(f => f.Id == id);

            if (film != null)
            {
                _context.Films.Remove(film);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
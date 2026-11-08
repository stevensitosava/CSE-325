using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StevenMovies.Data;
using StevenMovies.Models;

namespace StevenMovies.Controllers;

public class MoviesController : Controller
{
    private readonly MovieContext _context;

    public MoviesController(MovieContext context)
    {
        _context = context;
    }

      // GET: Movies
    public async Task<IActionResult> Index(string searchString, int? year)
    {
        IQueryable<Movie> movies = _context.Movies;

        // Search movies by title
        if (!string.IsNullOrEmpty(searchString))
        {
            movies = movies.Where(m =>
                m.Title.Contains(searchString));
        }

        // Filter movies by selected year or newer
        if (year.HasValue)
        {
            movies = movies.Where(m =>
                m.ReleaseDate.Year >= year.Value);
        }

        // Get available years for the dropdown
        ViewBag.Years = await _context.Movies
            .Select(m => m.ReleaseDate.Year)
            .Distinct()
            .OrderBy(y => y)
            .ToListAsync();

        ViewBag.SelectedYear = year;
        ViewBag.SearchString = searchString;

        return View(await movies.ToListAsync());
    }

    // GET: Movies/Welcome
    public IActionResult Welcome()
    {
        return Content("Welcome to Steven's Movies!");
    }

    // GET: Movies/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Movies/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Add(movie);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(movie);
    }

    
    // GET: Movies/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await _context.Movies.FindAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    // POST: Movies/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Movie movie)
    {
        if (id != movie.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(movie);
    }

    
    // GET: Movies/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await _context.Movies
            .FirstOrDefaultAsync(m => m.Id == id);

        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    
    // GET: Movies/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await _context.Movies
            .FirstOrDefaultAsync(m => m.Id == id);

        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    // POST: Movies/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var movie = await _context.Movies.FindAsync(id);

        if (movie != null)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }


}

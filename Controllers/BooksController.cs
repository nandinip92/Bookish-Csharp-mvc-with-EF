using Bookish.Models.Data;
using Bookish.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Controllers;

public class BooksController : Controller
{
    private readonly ILogger<BooksController> _logger;
    private readonly Library _library;

    public BooksController(ILogger<BooksController> logger, Library library)
    {
        _logger = logger;
        _library = library;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ViewAll()
    {
        var books = _library.Books.ToList();
        var viewModel = new BooksViewModel { Books = books, };
        return View(viewModel);
    }

    // [HttpGet("[controller]/{id}")]
    public IActionResult ViewIndividual([FromRoute] int id)
    {
        var matchingBook = _library
            .Books.Include(Book => Book.Copies)
            .SingleOrDefault(book => book.Id == id);
        if (matchingBook == null)
        {
            return NotFound();
        }
        return View(matchingBook);
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register([FromForm] Book book)
    {
        _library.Books.Add(book);
        _library.SaveChanges();
        return RedirectToAction(nameof(ViewAll));
    }

    public IActionResult Update()
    {
        var books = _library.Books.Include(Book => Book.Copies).ToList();
        var viewModel = new BooksViewModel { Books = books, };
        return View(viewModel);
        // return View();
    }

    public IActionResult Unregister()
    {
        var books = _library.Books.Include(Book => Book.Copies).ToList();
        var viewModel = new BooksViewModel { Books = books, };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Unregister([FromRoute] int id)
    {
        var matchingBook = _library.Books.Where(book => book.Id == id).Single();
        _library.Books.Remove(matchingBook);
        _library.SaveChanges();
        return RedirectToAction(nameof(ViewAll));
    }
}

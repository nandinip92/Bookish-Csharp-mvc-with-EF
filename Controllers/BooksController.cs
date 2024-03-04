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

    public IActionResult AddCopy([FromRoute] int id)
    {
        var matchingBook = _library.Books.SingleOrDefault(book => book.Id == id);
        if (matchingBook == null)
        {
            return NotFound();
        }
        return View(matchingBook);
    }

    [HttpPost]
    public IActionResult AddCopy([FromRoute] int id, [FromForm] Copy copy)
    {
        copy.BookId = id;
        _library.Copies.Add(copy);
        _library.SaveChanges();
        return RedirectToAction(nameof(AddCopy));
    }
}

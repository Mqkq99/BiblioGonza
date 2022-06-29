using Library.Services.Interfaces;
using Library.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(BookViewModel viewModel)
        {
            string id = _bookService.CreateBook(viewModel).ToString();

            return RedirectToAction("Details", new { id });
        }

        [Route("Books/Details/{id}")]
        public IActionResult Details(string id)
        {
            var book = _bookService.GetBookById(id);

            return View("Details", book);
        }
        public IActionResult List()
        {
            var books = new List<BookViewModel>();
            
            return View("List", books);
        }

    }
}

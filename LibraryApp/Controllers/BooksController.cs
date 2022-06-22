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
            _bookService.CreateBook(viewModel);
            return View("Index");
        }       
    }
}

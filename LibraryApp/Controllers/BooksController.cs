using Library.Services.Interfaces;
using Library.Services.ResultDTOs;
using Library.Services.ViewModels.Books;
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
            ValueResult<string> result = _bookService.Create(viewModel);

            if (result.Success)
            {
                var routeValues = new RouteValueDictionary {
                 { "id", result.Result } };
                return RedirectToAction("Details", routeValues);

            }
            return View("Create", viewModel);
        }
        public IActionResult Details(String id)
        {
            var book = _bookService.GetById(id);
          
            return View(book.Result);
        }

    }
}

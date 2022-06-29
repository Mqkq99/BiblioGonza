using Microsoft.AspNetCore.Mvc;
using Library.Services.Interfaces;
using Library.Services.ViewModels;
using Library.Services.ViewModels.Books;
using Library.Services.ResultDTOs;

namespace LibraryApp.Controllers
{
    public class BookCopiesController : Controller
    {
        private readonly IBookCopyService _bookService;

        public BookCopiesController(IBookCopyService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult Create(string id)
        {
            ValueResult<BookCopyViewModel> viewModel = _bookService.GetById(id);

            return View("Create", viewModel);
        }
        public IActionResult Details(BookViewModel viewModel)
        {
            var book = new BookViewModel { Id = "ASDASD" };

            return RedirectToAction("Details", "Books", new { });
        }
    }
}

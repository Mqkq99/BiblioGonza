using Microsoft.AspNetCore.Mvc;
using Library.Services.Interfaces;
using Library.Services.ViewModels;
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
            BookViewModel viewModel = _bookService.GetBookById(id);
           BookCopyViewModel viewModel1 = new BookCopyViewModel() { Book=viewModel};
            return View("Create", viewModel1);
        }
        public IActionResult Details(BookViewModel viewModel)
        {
            var book = new BookViewModel { Id = "ASDASD" };

            string id = new BookCopyViewModel { Id = "XDXDXD" ,Book=book }.Book.Id;
            return RedirectToAction("Details", "Books", new { id  });
        }



    }
}

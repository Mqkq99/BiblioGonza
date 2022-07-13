using Microsoft.AspNetCore.Mvc;
using Library.Services.Interfaces;
using Library.Services.ViewModels;
using Library.Services.ViewModels.Books;
using Library.Services.ResultDTOs;
using Library.Services.ViewModels.BookCopies;

namespace LibraryApp.Controllers
{
    public class BookCopiesController : Controller
    {
        private readonly IBookCopyService _bookCopyService;

        public BookCopiesController(IBookCopyService bookService)
        {
            _bookCopyService = bookService;
        }
        public IActionResult Create(string bookid)
        {
            ValueResult<BookCopyCreateViewModel> viewModel = _bookCopyService.CreateInizialization(bookid);
            return View("Create", viewModel.Result);
        }
        [HttpPost]
        public IActionResult Create(BookCopyCreateViewModel viewModel, string bookId)
        {
            _bookCopyService.Create(new BookCopyCreateViewModel()
            {
                Edition = viewModel.Edition,
                TotalQuantity = viewModel.TotalQuantity,
            }, bookId);

            return RedirectToAction("Details", "Books", new { id = bookId });
        }

        [HttpPost]
        public JsonResult Search(string title)
        {
            var result = _bookCopyService.Search(title);

            return Json(result.Result.ToList().Take(10));
        }

        public IActionResult Update(string id, string bookId)
        {
            BookViewModel book = _bookCopyService.getBookViewModel(bookId);
            ValueResult<BookCopyCreateViewModel> bookCopy = _bookCopyService.GetById(id);
            bookCopy.Result.Book = book;
            return View("Update", bookCopy.Result);
        }
        public IActionResult UpdateData(BookCopyCreateViewModel viewModel, string bookId)
        {
            BookViewModel book = _bookCopyService.getBookViewModel(bookId);
            ValueResult<BookCopyCreateViewModel> bookCopy = _bookCopyService.Update(viewModel);
            bookCopy.Result.Book = book;

            return RedirectToAction("Details", "Books", new { id = bookCopy.Result.Book.Id });
        }

        [Route("Books/Delete/{id}/{bookId}")]
        public IActionResult Delete(string id, string bookId)
        {
            _bookCopyService.Delete(id);

            return RedirectToAction("Details", "Books", new { id = bookId });
        }
    }
}

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
                
                
            },bookId);

            return RedirectToAction("Details", "Books",  new{id = bookId });
        }

        public IActionResult Update(String id)
        {
            ValueResult<BookCopyCreateViewModel> bookCopy = _bookCopyService.GetById(id);

            return View("Update", bookCopy.Result);
        }
        public IActionResult UpdateData(BookCopyCreateViewModel viewModel)
        {
            ValueResult<BookCopyCreateViewModel> bookCopy = _bookCopyService.Update(viewModel);

            return View("Details", bookCopy.Result);
        }

        [Route("Books/Delete/{id}")]
        public IActionResult Delete(string id)
        {
            var bookCopy = _bookCopyService.GetById(id);
            _bookCopyService.Delete(id);
            var bookId = bookCopy.Result.Book.Id;

            return RedirectToAction("Details", "Books", new {id = bookId});
        }
    }
}

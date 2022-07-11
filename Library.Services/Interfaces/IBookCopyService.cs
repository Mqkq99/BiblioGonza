
using Library.Services.ResultDTOs;
using Library.Services.ViewModels;
using Library.Services.ViewModels.BookCopies;
using Library.Services.ViewModels.Books;


namespace Library.Services.Interfaces
{
    public interface IBookCopyService
    {
        ValueResult<BookCopyCreateViewModel> GetById(string id);
        ValueResult<string> Create(BookCopyCreateViewModel viewModel,string bookId);
        ValueResult<BookCopyCreateViewModel> CreateInizialization(string id);
    }
}


using Library.Services.ResultDTOs;
using Library.Services.ViewModels;
using Library.Services.ViewModels.Books;

namespace Library.Services.Interfaces
{
    public interface IBookCopyService
    {
        ValueResult<BookCopyViewModel> GetById(string id);
        ValueResult<string> Create(BookCopyViewModel viewModel);
    }
}

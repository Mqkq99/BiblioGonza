using Library.Services.ResultDTOs;
using Library.Services.ViewModels.Books;
using LibraryApp.DAL.Model;

namespace Library.Services.Interfaces
{
    public interface IBookService
    {
        ValueResult<BookViewModel> GetById(string id);

        ValueResult<string> Create(BookViewModel viewModel);
        ValueResult<List<BookViewModel>> getAll();
    }
}
using Library.Services.ViewModels;
using LibraryApp.DAL.Model;

namespace Library.Services.Interfaces
{
    public interface IBookService
    {
        BookViewModel GetBookById(Guid id);

        Guid CreateBook(BookViewModel viewModel);
    }
}
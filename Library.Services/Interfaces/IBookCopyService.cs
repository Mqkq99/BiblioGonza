
using Library.Services.ViewModels;

namespace Library.Services.Interfaces
{
    public interface IBookCopyService
    {
        BookCopyViewModel GetCopyBookById(string id);
        string CreateBookCopy(BookCopyViewModel viewModel);
        BookViewModel GetBookById(string id);
    }
}

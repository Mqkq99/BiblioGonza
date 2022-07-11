using Library.Services.ViewModels.Base;
using Library.Services.ViewModels.Books;

namespace Library.Services.ViewModels.BookCopies
{
    public class BookCopyCreateViewModel : BaseViewModel
    {
        public string Edition { get; set; }

        public int TotalQuantity { get; set; }

        public BookViewModel Book { get; set; }
    }
}

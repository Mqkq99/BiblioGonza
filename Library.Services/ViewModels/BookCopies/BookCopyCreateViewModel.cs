using Library.Services.ViewModels.Books;

namespace Library.Services.ViewModels.BookCopies
{
    public class BookCopyCreateViewModel
    {
        public string Edition { get; set; }

        public int Quantity { get; set; }

        public BookViewModel Book { get; set; }
    }
}

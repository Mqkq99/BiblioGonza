using Library.Services.ViewModels.Base;

namespace Library.Services.ViewModels.Books
{
    public class BookViewModel : BaseViewModel
    {


        public string Author { get; set; }

        public string Title { get; set; }

        public List<BookCopyViewModel> Copies { get; set; }
    }
}

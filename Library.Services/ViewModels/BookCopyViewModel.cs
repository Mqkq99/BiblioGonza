
namespace Library.Services.ViewModels
{
    public class BookCopyViewModel: BaseViewModel
    {
        public BookViewModel Book { get; set; }

        public string Edition { get; set; }

        public int Quantity { get; set; }
    }
}

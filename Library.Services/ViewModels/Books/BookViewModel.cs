using Library.Services.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace Library.Services.ViewModels.Books
{
    public class BookViewModel : BaseViewModel
    {
        [Required]
        public string Author { get; set; }
        
        [Required]
        public string Title { get; set; }

        public List<BookCopyViewModel> Copies { get; set; }
    }
}

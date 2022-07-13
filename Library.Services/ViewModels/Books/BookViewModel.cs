using Library.Services.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace Library.Services.ViewModels.Books
{
    public class BookViewModel : BaseViewModel
    {
        [Required]
        [StringLength(35, MinimumLength = 4)]
        public string Author { get; set; }

        [Required]
        [StringLength(70, MinimumLength = 2)]
        public string Title { get; set; }

        public List<BookCopyViewModel> BookCopies { get; set; }
    }
}

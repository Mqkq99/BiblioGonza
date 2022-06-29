using Library.Services.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.ViewModels.Books
{
    public class BookListViewModel : BaseViewModel
    {
        public string Author { get; set; }

        public string Title { get; set; }
    }
}

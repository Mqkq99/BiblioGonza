using Library.Services.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.ViewModels.BookCopies
{
    public class BookCopySearchViewModel : BaseViewModel
    {
        public string Author { get; set; }

        public string Title { get; set; }

        public string Edition { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.ViewModels
{
    public class BookCopyViewModel
    {
        public BookViewModel Book { get; set; }

        public string Edition { get; set; }

        public int Quantity { get; set; }
    }
}

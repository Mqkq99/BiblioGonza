using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAL.Model
{
    public class BookCopy : EntityBase
    {
        public Book Book { get; set; }

        public string Edition { get; set; }

        public int TotalQuantity { get; set; }
        
        public int AvailableQuantity { get; set; }

    }
}

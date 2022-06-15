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
    }
}

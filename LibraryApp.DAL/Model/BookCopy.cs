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

        public int Quantity { get; set; }

        public virtual List<Withdrawal> Withdrawals { get; set; }
    }
}

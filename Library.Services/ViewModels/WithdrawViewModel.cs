using LibraryApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.ViewModels
{
    public class WithdrawViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public BookCopy BookCopy { get; set; }

        public Customer Customer { get; set; }
    }
}

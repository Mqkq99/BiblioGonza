using Library.Services.ViewModels.Books;
using LibraryApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.ViewModels
{
    public class WithdrawalViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string BookCopyId { get; set; }

        public string CustomerId { get; set; }

    }
}

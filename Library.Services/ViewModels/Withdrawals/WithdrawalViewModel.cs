using Library.Services.ViewModels.Base;
using Library.Services.ViewModels.Books;
using LibraryApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.ViewModels.Withdrawals
{
    public class WithdrawalViewModel : BaseViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string BookCopyId { get; set; }

        public string CustomerId { get; set; }

    }
}

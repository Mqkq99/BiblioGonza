using Library.Services.ViewModels.Base;
using Library.Services.ViewModels.Books;
using Library.Services.ViewModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.ViewModels.Withdrawals
{
    public class WithdrawalDetailViewModel : BaseViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public BookCopyViewModel BookCopyViewModel { get; set; }

        public CustomerListViewModel CustomerViewModel { get; set; }
    }
}

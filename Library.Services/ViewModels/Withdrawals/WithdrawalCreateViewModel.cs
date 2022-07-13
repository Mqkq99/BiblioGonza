using Library.Services.ViewModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.ViewModels.Withdrawals
{
    public class WithdrawalCreateViewModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public CustomerListViewModel Customer { get; set; }

        public string CustomerId { get; set; }

        public string BookId { get; set; }
    }
}

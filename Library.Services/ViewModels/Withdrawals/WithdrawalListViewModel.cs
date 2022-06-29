using Library.Services.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.ViewModels.Withdrawals
{
    public class WithdrawalListViewModel : BaseViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string BookTitle { get; set; }

        public string CustomerId { get; set; }
    }
}

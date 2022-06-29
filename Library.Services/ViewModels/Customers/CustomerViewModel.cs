using Library.Services.ViewModels.Base;

namespace Library.Services.ViewModels.Customers
{
    public class CustomerViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public List<WithdrawalViewModel> Withdrawals { get; set; }
    }
}

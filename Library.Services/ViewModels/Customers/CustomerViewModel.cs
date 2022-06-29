using Library.Services.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace Library.Services.ViewModels.Customers
{
    public class CustomerViewModel : BaseViewModel
    {
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(15, MinimumLength = 8)]
        public string PhoneNumber { get; set; }

        [StringLength(12, MinimumLength = 8)]
        [Required]
        public string Dni { get; set; }

        public List<WithdrawalViewModel> Withdrawals { get; set; }
    }
}

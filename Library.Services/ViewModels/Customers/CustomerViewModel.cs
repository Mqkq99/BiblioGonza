﻿using Library.Services.ViewModels.Base;
using Library.Services.ViewModels.Withdrawals;
using System.ComponentModel.DataAnnotations;

namespace Library.Services.ViewModels.Customers
{
    public class CustomerViewModel : BaseViewModel
    {
        [Required]
        [StringLength(10, MinimumLength = 6)]
        public override string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Address { get; set; }
       
        [StringLength(15, MinimumLength = 8)]
        public string PhoneNumber { get; set; }

        public List<WithdrawalListViewModel>? Withdrawals   { get; set; }
    }
}

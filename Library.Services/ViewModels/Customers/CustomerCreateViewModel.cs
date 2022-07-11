using Library.Services.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.ViewModels.Customers
{
    public class CustomerCreateViewModel:BaseViewModel
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

    }
}

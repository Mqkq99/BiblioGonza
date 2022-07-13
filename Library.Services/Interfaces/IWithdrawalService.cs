using Library.Services.ResultDTOs;
using Library.Services.ViewModels.Withdrawals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IWithdrawalService
    {
        public ValueResult<WithdrawalDetailViewModel> GetById(string id);

        public ValueResult<string> Create(WithdrawalCreateViewModel viewModel);

        public ValueResult<WithdrawalCreateViewModel> GetCreateData(string customerId);
    }
}

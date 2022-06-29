﻿using Library.Services.ResultDTOs;
using Library.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IWithdrawalService
    {
        public ValueResult<WithdrawalViewModel> GetById(string id);

        public ValueResult<string> Create(WithdrawalViewModel viewModel);
    }
}
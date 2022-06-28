﻿using Library.Services.ViewModels;
using LibraryApp.DAL.Model;

namespace Library.Services.Interfaces
{
    public interface ICustomerService
    {

        CustomerViewModel GetCustomerById(string id);

        string CreateCustomer(CustomerViewModel viewModel);

        List<CustomerViewModel> getAllCustomer();
        void Delete(string id);
    }
}

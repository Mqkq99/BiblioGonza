using Library.Services.ResultDTOs;
using Library.Services.ViewModels.Customers;
using LibraryApp.DAL.Model;

namespace Library.Services.Interfaces
{
    public interface ICustomerService
    {

        ValueResult<CustomerViewModel> GetById(string id);

        ValueResult<string> Create(CustomerCreateViewModel viewModel);

        ValueResult<List<CustomerListViewModel>> getAll();

        ValueResult<bool> Delete(string id);

        ValueResult<CustomerViewModel> Update(CustomerViewModel viewModel);
    }
}

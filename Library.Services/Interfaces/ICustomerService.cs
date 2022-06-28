using Library.Services.ViewModels;
using LibraryApp.DAL.Model;

namespace Library.Services.Interfaces
{
    public interface ICustomerService
    {

        CustomerViewModel GetCustomerById(Guid id);

        Guid CreateCustomer(CustomerViewModel viewModel);
        IEnumerable<Customer> getAllCustomer();
        void Delete(Guid id);
    }
}

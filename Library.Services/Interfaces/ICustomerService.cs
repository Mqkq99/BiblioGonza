using LibraryApp.DAL.Model;

namespace Library.Services.Interfaces
{
    public interface ICustomerService
    {

        Customer GetCustomerById(Guid id);

        Guid CreateCustomer(ICustomerService viewModel);
    }
}

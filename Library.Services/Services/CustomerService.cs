using Library.Services.Interfaces;
using Library.Services.ViewModels;
using LibraryApp.DAL;
using LibraryApp.DAL.Model;

namespace Library.Services.Services
{
    internal class CustomerService : ICustomerService
    {
        private LibraryDbContext _context { get; set; }

        public CustomerService(LibraryDbContext context)
        {
            _context = context != null ? context : throw new ArgumentNullException(nameof(context));
        }
        public Guid CreateCustomer(CustomerViewModel viewModel)
        {
            Customer customer = new Customer() { };

            throw new NotImplementedException();
        }

        public Customer GetCustomerById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

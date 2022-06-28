using Library.Services.Interfaces;
using Library.Services.ViewModels;
using LibraryApp.DAL;
using LibraryApp.DAL.Model;

namespace Library.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private LibraryDbContext _context { get; set; }

        public CustomerService(LibraryDbContext context)
        {
            _context = context != null ? context : throw new ArgumentNullException(nameof(context));
        }
        public string CreateCustomer(CustomerViewModel viewModel)
        {
            Customer customer = new Customer() { Address = viewModel.Address, Name = viewModel.Name, PhoneNumber = viewModel.PhoneNumber, Id = viewModel.Id };

            _context.Add(customer);

            _context.SaveChanges();

            return viewModel.Id;
        }

        public CustomerViewModel GetCustomerById(string id)
        {
            var customer = _context.Customers.Where(x => x.Id == id).FirstOrDefault();

            CustomerViewModel viewModel = new CustomerViewModel() { Address = customer.Address, Name = customer.Name, PhoneNumber = customer.PhoneNumber };

            return viewModel;
        }
        public List<CustomerViewModel> getAllCustomer()
        {
            var list = _context.Customers;
            List<CustomerViewModel> listUser = new List<CustomerViewModel>();
            foreach (var customer in list)
            {
                listUser.Add(new CustomerViewModel() { Address = customer.Address, Name = customer.Name,Id=customer.Id});
            }

            return listUser;
        }

        public void Delete(string id)
        {
            var customer = _context.Customers.Where(x => x.Id == id).FirstOrDefault();
            _context.Customers.Remove(customer);
        }

    }
}

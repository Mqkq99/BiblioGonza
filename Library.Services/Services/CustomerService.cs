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
        public Guid CreateCustomer(CustomerViewModel viewModel)
        {
            Customer customer = new Customer() { Address = viewModel.Address, Name = viewModel.Name, PhoneNumber = viewModel.PhoneNumber };

            customer.Id = Guid.NewGuid();

            _context.Add(customer);

            _context.SaveChanges();

            return customer.Id;
        }

        public CustomerViewModel GetCustomerById(Guid id)
        {
            var customer = _context.Customers.Where(x => x.Id == id).FirstOrDefault();

            CustomerViewModel viewModel = new CustomerViewModel() { Address = customer.Address, Name = customer.Name, PhoneNumber = customer.PhoneNumber };

            return viewModel;
        }
        public IEnumerable<Customer> getAllCustomer()
        {
            var list = _context.Customers;
            List<CustomerViewModel> listModel = new List<CustomerViewModel>;
            foreach (var item in list)
            {
                listModel.Add(new CustomerViewModel() { Address = item.Address, Name = item.Name,   
            }
            return list;
        }

        public void Delete(Guid id)
        {
            var customer = _context.Customers.Where(x => x.Id == id).FirstOrDefault();
            _context.Customers.Remove(customer);
        }

    }
}

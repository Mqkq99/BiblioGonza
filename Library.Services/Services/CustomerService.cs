using AutoMapper;
using Library.Services.Interfaces;
using Library.Services.ViewModels;
using LibraryApp.DAL;
using LibraryApp.DAL.Model;

namespace Library.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private LibraryDbContext _context { get; set; }

        private IMapper _mapper { get; set; }

        public CustomerService(
            LibraryDbContext context,
            IMapper mapper
            )
        {
            _context = context != null ? context : throw new ArgumentNullException(nameof(context));
            _mapper = mapper != null ? mapper : throw new ArgumentNullException(nameof(mapper));
        }
        public string CreateCustomer(CustomerViewModel viewModel)
        {
            Customer customer = _mapper.Map<Customer>(viewModel);

            _context.Add(customer);

            _context.SaveChanges();

            return viewModel.Id;
        }

        public CustomerViewModel GetCustomerById(string id)
        {
            var viewModel = _mapper.Map<CustomerViewModel>(_context.Customers.Where(x => x.Id == id).FirstOrDefault());

            return viewModel;
        }

        //public List<CustomerViewModel> getAllCustomers()
        //{
        //    var customerList = _mapper.Map<List<CustomerViewModel>>(_context.Customers);
            


        //    return listUser;
        //}
        
        //public CustomerViewModel Edit(CustomerViewModel viewModel)
        //{

        //}

        public void Delete(string id)
        {
            var customer = _context.Customers.Where(x => x.Id == id).FirstOrDefault();
            _context.Customers.Remove(customer);
        }

    }
}

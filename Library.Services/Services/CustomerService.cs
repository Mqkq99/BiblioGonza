using AutoMapper;
using Library.Services.Interfaces;
using Library.Services.ResultDTOs;
using Library.Services.ViewModels.Customers;
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

        public ValueResult<CustomerViewModel> GetById(string id)
        {
            try
            {
                var customer = _context.Customers.Where(x => x.Id == id && !x.Disabled).FirstOrDefault();

                if(customer != null)
                {
                    var viewModel = _mapper.Map<CustomerViewModel>(customer);

                    return ValueResult<CustomerViewModel>.Ok(viewModel);
                }
                else
                    return ValueResult<CustomerViewModel>.NotFound();
            }
            catch (Exception ex)
            {
                return ValueResult<CustomerViewModel>.Error(ex.Message);
            }
        }

        public ValueResult<string> Create(CustomerCreateViewModel viewModel)
        {
            var viewModelReady= _mapper.Map<CustomerViewModel>(viewModel);
            
            try
            {
                Customer customer = _mapper.Map<Customer>(viewModelReady);

                _context.Add(customer);

                _context.SaveChanges();

                return ValueResult<string>.Ok(customer.Id);
            }
            catch (Exception ex)
            {
                return ValueResult<string>.Error(ex.Message);
            }
            }

        public ValueResult<List<CustomerListViewModel>> getAll()
        {
            try
            {
                List<CustomerListViewModel> customerList = _mapper.Map<List<CustomerListViewModel>>(_context.Customers.Where(x => !x.Disabled));

                return ValueResult<List<CustomerListViewModel>>.Ok(customerList);
            }
            catch (Exception ex)
            {
                return ValueResult<List<CustomerListViewModel>>.Error(ex.Message);
            }
        }

        public ValueResult<CustomerViewModel> Update(CustomerViewModel viewModel)
        {
            try
            {
                Customer customer = _mapper.Map<Customer>(viewModel);

                _context.Update(customer);
                _context.SaveChanges();

                return ValueResult<CustomerViewModel>.Ok(viewModel); ;
            }
            catch (Exception ex)
            {
                return ValueResult<CustomerViewModel>.Error(ex.Message);
            }
        }

        public ValueResult<bool> Delete(string id)
        {
            try
            {
                var customer = _context.Customers.Where(x => x.Id == id).FirstOrDefault();

                if (customer != null)
                {
                    customer.Disabled = true;
                    _context.Update(customer);
                    _context.SaveChanges();

                    return ValueResult<bool>.Ok(true);
                }
                else
                {
                    return ValueResult<bool>.NotFound();
                }
            }
            catch (Exception ex)
            {
                return ValueResult<bool>.Error(ex.Message);
            }
        }
    }
}

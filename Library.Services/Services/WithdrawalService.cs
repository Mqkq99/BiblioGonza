using AutoMapper;
using Library.Services.Interfaces;
using Library.Services.ResultDTOs;
using Library.Services.ViewModels;
using LibraryApp.DAL;
using LibraryApp.DAL.Model;

namespace Library.Services.Services
{
    public class WithdrawalService : IWithdrawalService
    {
        private LibraryDbContext _context { get; set; }

        private IMapper _mapper { get; set; }

        public WithdrawalService(
            LibraryDbContext context,
            IMapper mapper
            )
        {
            _context = context != null ? context : throw new ArgumentNullException(nameof(context));
            _mapper = mapper != null ? mapper : throw new ArgumentNullException(nameof(mapper));
        }

        public ValueResult<WithdrawalViewModel> GetById(string id)
        {
            try
            {
                var withdrawal = _context.Withdrawals.Where(x => x.Id == id && !x.Disabled).FirstOrDefault();

                if (withdrawal != null)
                {
                    var viewModel = _mapper.Map<WithdrawalViewModel>(withdrawal);

                    return ValueResult<WithdrawalViewModel>.Ok(viewModel);
                }
                else
                    return ValueResult<WithdrawalViewModel>.NotFound();
            }
            catch (Exception ex)
            {
                return ValueResult<WithdrawalViewModel>.Error(ex.Message);
            }
        }

        public ValueResult<string> Create(WithdrawalViewModel viewModel)
        {
            try
            {
                viewModel.StartDate = DateTime.Now;
                viewModel.EndDate = DateTime.Now.AddDays(15);

                var customer = _context.Customers.Where(x => x.Id == viewModel.CustomerId && !x.Disabled).FirstOrDefault();

                if(customer == null)
                    return ValueResult<string>.Error("Error creando la reserva, el usuario seleccionado es inexistente");

                var bookCopy = _context.BookCopies.Where(x => x.Id == viewModel.BookCopyId && !x.Disabled && x.TotalQuantity > 0).FirstOrDefault();

                if (bookCopy == null)
                    return ValueResult<string>.Error("Error creando la reserva, la copia del libro seleccionado es inexistente o no tiene un ejemplar disponible");

                var withdrawal = _mapper.Map<Withdrawal>(viewModel);

                withdrawal.Customer = customer;
                withdrawal.BookCopy = bookCopy;

                _context.Add(withdrawal);

                _context.SaveChanges();

                return ValueResult<string>.Ok(withdrawal.Id);
            }
            catch (Exception ex)
            {
                return ValueResult<string>.Error(ex.Message);
            }
        }
    }
}

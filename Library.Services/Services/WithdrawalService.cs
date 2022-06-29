using AutoMapper;
using Library.Services.ResultDTOs;
using Library.Services.ViewModels;
using LibraryApp.DAL;
using LibraryApp.DAL.Model;

namespace Library.Services.Services
{
    public class WithdrawalService
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
                var withdrawal = _mapper.Map<Withdrawal>(viewModel);

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

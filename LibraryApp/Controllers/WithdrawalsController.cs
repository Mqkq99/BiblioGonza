using Library.Services.Interfaces;
using Library.Services.ResultDTOs;
using Library.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class WithdrawalsController : Controller
    {
        private readonly IWithdrawalService _withdrawalService;

        public WithdrawalsController(IWithdrawalService withdrawalService)
        {
            _withdrawalService = withdrawalService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(WithdrawalViewModel viewModel)
        {
            ValueResult<string> id = _withdrawalService.Create(viewModel);

            return View(viewModel);
        }
    }
}

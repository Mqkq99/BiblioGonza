using Library.Services.Interfaces;
using Library.Services.ResultDTOs;
using Library.Services.ViewModels.Withdrawals;
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

        [Route("Withdrawals/Create/{id}")]
        public IActionResult Create(string id)
        {
            var result = _withdrawalService.GetCreateData(id);
            return View(result.Result);
        }

        [HttpPost]
        public IActionResult CreateWithdrawal([FromForm] WithdrawalCreateViewModel viewModel)
        {
            ValueResult<string> id = _withdrawalService.Create(viewModel);

            var routeValues = new RouteValueDictionary {
                 { "id", viewModel.CustomerId } };

            return RedirectToAction("Details", "Customers" ,routeValues);
        }

        public IActionResult GetById(string id)
        {
            ValueResult<WithdrawalDetailViewModel> viewModel = _withdrawalService.GetById(id);

            return View();
        }
               
    }
}

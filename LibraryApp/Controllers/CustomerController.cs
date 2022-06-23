using Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(ICustomerService viewModel)
        {
            _customerService.CreateCustomer(viewModel);
            return View("Index");
        }


    }
}


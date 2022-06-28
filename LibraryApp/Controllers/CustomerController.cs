using Library.Services.Interfaces;
using Library.Services.ViewModels;
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
        public IActionResult Create(CustomerViewModel viewModel)
        {
            var id = _customerService.CreateCustomer(viewModel);

            return RedirectToAction("Profile", new { id });
        }

        [Route("Customer/Profile/{id}")]
        public IActionResult Profile(Guid id)
        {
            var customer = _customerService.GetCustomerById(id);
            ViewData["Name"] = customer.Name;
            ViewData["Phone"] = customer.PhoneNumber;
            ViewData["Address"] = customer.Address;

            return View("Profile");
        }

        public IActionResult ShowUsers()
        {
            var users = _customerService.getAllCustomer();
          
            return View("ShowUsers",users);
        }

        [HttpPost]
        public IActionResult Delete(CustomerViewModel customer)
        {
            _customerService.Delete(customer.Id);
            var users = _customerService.getAllCustomer();

            return View("ShowUsers", users);
        }


    }
}


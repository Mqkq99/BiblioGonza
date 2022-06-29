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
            string id = _customerService.CreateCustomer(viewModel).ToString();

            return RedirectToAction("Details", new { id });
        }
        public IActionResult Details(string id)
        {
            var customer = _customerService.GetCustomerById(id);

            return View("Details", customer);
        }

        //[HttpPost]
        //public IActionResult Update(CustomerViewModel viewModel)
        //{
        //    CustomerViewModel customer = _customerService.Update(viewModel);

        //    return View("Details", customer);
        //}

        public IActionResult List()
        {
           var users = _customerService.getAll();

           return View("List",users);
        }

        //[HttpPost]
        //public IActionResult Delete(CustomerViewModel customer)
        //{
        //    _customerService.Delete(customer.Id);
        //    var users = _customerService.getAllCustomer();

        //    return View("ShowUsers", users);
        //}


    }
}


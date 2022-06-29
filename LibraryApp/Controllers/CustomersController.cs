using Library.Services.Interfaces;
using Library.Services.ResultDTOs;
using Library.Services.ViewModels.Customers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
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
            ValueResult<string> result = _customerService.Create(viewModel);

            if (result.Success)
            {
                var routeValues = new RouteValueDictionary {
                 { "id", result.Result } };
                return RedirectToAction("Details",routeValues);

            }
            return View("Create", viewModel);
        }



        public IActionResult Details(string id)
        {
            var customer = _customerService.GetById(id);

            return View("Details", customer.Result);
        }

        //public IActionResult Update(CustomerViewModel viewModel)
        //{
        //    CustomerViewModel customer = _customerService.Update(viewModel);

        //    return View("Details", customer);
        //}

        public IActionResult List()
        {
            var users = _customerService.getAll();

            return View("List", users.Result);
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            _customerService.Delete(id);
            var users = _customerService.getAll();

            return View("ShowUsers", users);
        }


    }
}


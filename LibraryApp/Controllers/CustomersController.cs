﻿using Library.Services.Interfaces;
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
        public IActionResult Create(CustomerCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
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
            if(id == null)
            {
                return View("Error");
            }
            var customer = _customerService.GetById(id);

            return View("Details", customer.Result);
        }

        [Route("Update/{id}")]
        public IActionResult Update(string id)
        {
            ValueResult<CustomerViewModel> customer = _customerService.GetById(id);

            return View("Update", customer.Result);
        }

        [HttpPost]
        public IActionResult UpdateData(CustomerViewModel viewModel)
        {
            ValueResult<CustomerViewModel> customer = _customerService.Update(viewModel);

            return View("Details", customer.Result);
        }

        public IActionResult List()
        {
            ValueResult<List<CustomerListViewModel>> users = _customerService.getAll();

            return View("List", users.Result);
        }

        [Route("Customer/Delete/{id}")]
        public IActionResult Delete(string id)
        {
            _customerService.Delete(id);
            var users = _customerService.getAll();

            return View("List", users.Result);
        }

        [HttpPost]
        public JsonResult Search(string dni)
        {
            var result = _customerService.Search(dni);

            return Json(result.Result.ToList().Take(10));
        }
    }
}


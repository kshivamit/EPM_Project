using EPM.Core.CustomerManagement;
using EPM.Repository.CustomerManagement;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPM.UI.Controllers.CustomerManagement
{
    public class CustomerController : Controller
    {
        private readonly ICustomer _ICustomerRepository;
        public CustomerController(ICustomer customerRepository)
        {
            _ICustomerRepository = customerRepository;
        }
        public IActionResult Index(int Id)
        {
            if(Id == 0)
            {
                return View("~/Views/CustomerManagement/Customer.cshtml");
            }
            else
            {
                var response = _ICustomerRepository.GetCustomerById(Id);
                return View("~/Views/CustomerManagement/Customer.cshtml",response);
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer model)
        {
            if (model.Id == 0)
            {
                var response = await _ICustomerRepository.CreateCustomer(model);
            }
            else
            {
                var response = await _ICustomerRepository.UpadateCustomer(model);
            }
            return RedirectToAction("GetCustomer", "Customer");

        }
        public async Task<IActionResult> DeleteCustomer(int Id)
        {
            var response = await _ICustomerRepository.DeleteCustomer(Id);
            return Json(response);
        }
        public IActionResult GetCustomer()
        {
            var response = _ICustomerRepository.GetCustomer();
            return View("~/Views/CustomerManagement/CustomerList.cshtml", response);
        }
    }
}
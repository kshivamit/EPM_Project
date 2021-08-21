using EPM.Core.EmployeeManagement;
using EPM.Repository.EmployeeManagement;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPM.UI.Controllers.EmployeeManagement
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _IEmployeeRepository;
        public EmployeeController(IEmployee employeeRepository)
        {
            _IEmployeeRepository = employeeRepository;
        }
        public IActionResult Index(int Id)
        {
            if(Id == 0)
            {
                return View("~/Views/EmployeeManagement/Employee.cshtml");
            }
            else
            {
                var response =_IEmployeeRepository.GetEmployeeById(Id);
                return View("~/Views/EmployeeManagement/Employee.cshtml",response);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee model)
        {
            if (model.Id == 0)
            {
                var response = await _IEmployeeRepository.CreateEmployee(model);
            }
            else
            {
                var response = await _IEmployeeRepository.UpadateEmployee(model);
            }
            return RedirectToAction("GetEmployee", "Employee");
        }
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            var response = await _IEmployeeRepository.DeleteEmployee(Id);
            return Json(response);
        }
        public IActionResult GetEmployee()
        {
            var response = _IEmployeeRepository.GetEmployee();
            return View("~/Views/EmployeeManagement/EmployeeList.cshtml", response);
        }
    }
}

using EPM.Core.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPM.Repository.EmployeeManagement
{
    public interface IEmployee
    {
        Task<bool> CreateEmployee(Employee model);
        Task<bool> DeleteEmployee(int Id);
        Task<bool> UpadateEmployee(Employee model);
        Employee GetEmployeeById(int Id);
        IEnumerable<Employee> GetEmployee();
    }
}
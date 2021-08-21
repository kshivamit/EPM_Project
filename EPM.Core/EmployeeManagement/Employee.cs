using EPM.Core.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EPM.Core.EmployeeManagement
{
    public class Employee : BaseModel<int>
    {
        [Required(ErrorMessage = "Employee name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Employee email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Employee phone is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Employee Code is required")]
        public string EmpCode { get; set; }
    }
}

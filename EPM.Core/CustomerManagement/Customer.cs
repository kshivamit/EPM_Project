using EPM.Core.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EPM.Core.CustomerManagement
{
    public class Customer : BaseModel<int>
    {

        [Required(ErrorMessage = "Customer name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Customer phone is required")]
        public string Phone { get; set; }
    }
}

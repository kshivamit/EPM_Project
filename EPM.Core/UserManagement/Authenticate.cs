using EPM.Core.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EPM.Core.UserManagement
{
    public class Authenticate : BaseModel<int>
    {
        [Required(ErrorMessage = "User name is required.")]
        [MaxLength(50, ErrorMessage = "User name is too large.")]
        [MinLength(5, ErrorMessage = "User name is too small.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password doesn't match.")]
        public String ConfirmPassword { get; set; }
    }
}

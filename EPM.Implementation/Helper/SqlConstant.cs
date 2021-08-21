using System;
using System.Collections.Generic;
using System.Text;

namespace EPM.Implementation.Helper
{
    public static class SqlConstant
    {
        public static string CreateUser = @"Insert into Authenticate (UserName, Password, CreatedBy) 
                                           values(@UserName, @Password, 1)";
        public static string IsAuthenticate = @"Select Count(1) Password from Authenticate
                                             where UserName=@username and Password=@password and IsActive=1 and IsDeleted=0";

        public static string CreateCustomer = @"Insert into Customer (Name, Email,Phone, CreatedBy) 
                                           values(@Name, @Email,@Phone, 1)";
        public static string DeleteCustomer = @"Delete from Customer where Id=@Id";
        public static string UpdateCustomer = @"Update Customer SET Name=@Name, Email=@Email, Phone=@Phone Where Id=@Id";
        public static string GetCustomer = @"Select Id, Name, Email, Phone from Customer";

        public static string CreateEmployee = @"Insert into Employee (Name, Email, Phone, EmpCode, CreatedBy) 
                                              values(@Name, @Email, @Phone, @EmpCode, 1)";
        public static string DeleteEmployee = @"Delete from Employee where Id=@Id";
        public static string UpdateEmployee = @"Update Employee SET Name=@Name, Email=@Email, Phone=@Phone,
                                                EmpCode=@EmpCode Where Id=@Id";
        public static string GetEmployee = @"Select Id, Name, Email, Phone, EmpCode from Employee";
    }
}

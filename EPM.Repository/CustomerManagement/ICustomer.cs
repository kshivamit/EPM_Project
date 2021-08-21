using EPM.Core.CustomerManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPM.Repository.CustomerManagement
{
    public interface ICustomer
    {
        Task<bool> CreateCustomer(Customer model);
        Task<bool> DeleteCustomer(int Id);
        Task<bool> UpadateCustomer(Customer model);

        Customer GetCustomerById(int Id);
        IEnumerable<Customer> GetCustomer();
    }
}

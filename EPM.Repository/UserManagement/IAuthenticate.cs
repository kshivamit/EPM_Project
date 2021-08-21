using EPM.Core.UserManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPM.Repository.UserManagement
{
     public interface IAuthenticate
    {
        Task<bool> CreateUser(Authenticate model);
        Task<bool> IsAuthenticate(Authenticate model);
    }
}

using EPM.Core.UserManagement;
using EPM.Implementation.Helper;
using EPM.Repository.UserManagement;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EPM.Implementation.UserManagement
{
    public class AuthenticateImplementation : IAuthenticate
    {
        private readonly string _connectionString;
        public AuthenticateImplementation(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionStrings:dbConnection").Value;
        }
        public async Task<bool> CreateUser(Authenticate model)
        {
            SqlParameter[] parameter =
            {
                new SqlParameter("@userName",model.UserName),
                new SqlParameter("@password",model.Password),
            };
            var response = await SqlHelper.ExecuteNonQuery(_connectionString, SqlConstant.CreateUser,
                System.Data.CommandType.Text,parameter);
            return Convert.ToInt32(response) > 0;
        }

        public async Task<bool> IsAuthenticate(Authenticate model)
        {
            SqlParameter[] parameter =
            {
                new SqlParameter("@userName",model.UserName),
                new SqlParameter("@password",model.Password),
            };
            var response = await SqlHelper.ExecuteScalar(_connectionString, SqlConstant.IsAuthenticate,
                System.Data.CommandType.Text, parameter);
            return Convert.ToInt32(response) > 0;
        }
    }
}

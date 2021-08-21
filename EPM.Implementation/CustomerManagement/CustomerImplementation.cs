using EPM.Core.CustomerManagement;
using EPM.Implementation.Helper;
using EPM.Repository.CustomerManagement;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EPM.Implementation.CustomerManagement
{
    public class CustomerImplementation : ICustomer
    {
        private readonly string _connectionString;
        public CustomerImplementation(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionStrings:dbConnection").Value;
        }
        public async Task<bool> CreateCustomer(Customer model)
        {
            SqlParameter[] parameter = {
                new SqlParameter("@Name",model.Name),
                new SqlParameter("@Email",model.Email),
                new SqlParameter("@Phone",model.Phone),
            };
            var response = await SqlHelper.ExecuteNonQuery(_connectionString,
                SqlConstant.CreateCustomer, System.Data.CommandType.Text, parameter);

            return Convert.ToInt32(response) > 0;
        }

        public async Task<bool> DeleteCustomer(int Id)
        {
            SqlParameter[] parameter = {
                new SqlParameter("@Id", Id)
            };
            var response = await SqlHelper.ExecuteNonQuery(_connectionString, SqlConstant.DeleteCustomer,
                System.Data.CommandType.Text, parameter);
            return Convert.ToInt32(response) > 0;
        }

        public IEnumerable<Customer> GetCustomer()
        {
            var models = new List<Customer>();
            string commandText = @"Select Id, Name, Email, Phone from Customer";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(commandText, con);
                cmd.CommandType = System.Data.CommandType.Text;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var model = new Customer();
                        model.Id = Convert.ToInt32(reader["Id"]);
                        model.Name = (reader["Name"]).ToString();
                        model.Email = (reader["Email"]).ToString();
                        model.Phone = (reader["Phone"]).ToString();

                        models.Add(model);
                    }
                }
            }
            return models;
        }

        public Customer GetCustomerById(int Id)
        {
            var model = new Customer();
            string selectCommand = @"Select Id,Name,Email,Phone from Customer where Id=@Id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(selectCommand, con);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", Id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        model.Id = Convert.ToInt32(reader["Id"]);
                        model.Name = (reader["Name"]).ToString();
                        model.Email = (reader["Email"]).ToString();
                        model.Phone = (reader["Phone"]).ToString();
                    }
                }
                return model;
            }
        }

        public async Task<bool> UpadateCustomer(Customer model)
        {
            SqlParameter[] parameter = {
                new SqlParameter("@Id",model.Id),
                new SqlParameter("@Name",model.Name),
                new SqlParameter("@Email",model.Email),
                new SqlParameter("@Phone",model.Phone),
            };
            var response = await SqlHelper.ExecuteNonQuery(_connectionString,
                SqlConstant.UpdateCustomer, System.Data.CommandType.Text, parameter);

            return Convert.ToInt32(response) > 0;
        }
    }
}
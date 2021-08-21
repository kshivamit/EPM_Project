using EPM.Core.EmployeeManagement;
using EPM.Implementation.Helper;
using EPM.Repository.EmployeeManagement;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EPM.Implementation.EmployeeManagement
{
    public class EmployeeImplementation : IEmployee
    {
        private readonly string _connectionString;
        public EmployeeImplementation(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionStrings:dbConnection").Value;
        }
        public async Task<bool> CreateEmployee(Employee model)
        {
            SqlParameter[] parameter = {
                new SqlParameter("@Name",model.Name),
                new SqlParameter("@Email",model.Email),
                new SqlParameter("@Phone",model.Phone),
                new SqlParameter("@EmpCode",model.EmpCode),
            };
            var response = await SqlHelper.ExecuteNonQuery(_connectionString,
                SqlConstant.CreateEmployee, System.Data.CommandType.Text, parameter);

            return Convert.ToInt32(response) > 0;
        }

        public async Task<bool> DeleteEmployee(int Id)
        {
            SqlParameter[] parameter = {
                new SqlParameter("@Id", Id)
            };
            var response = await SqlHelper.ExecuteNonQuery(_connectionString, SqlConstant.DeleteEmployee,
                System.Data.CommandType.Text, parameter);
            return Convert.ToInt32(response) > 0;
        }

        public IEnumerable<Employee> GetEmployee()
        {
            var models = new List<Employee>();
            string commandText = @"Select Id, Name, Email, Phone, EmpCode from Employee";
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
                        var model = new Employee();
                        model.Id = Convert.ToInt32(reader["Id"]);
                        model.Name = (reader["Name"]).ToString();
                        model.Email = (reader["Email"]).ToString();
                        model.Phone = (reader["Phone"]).ToString();
                        model.EmpCode = (reader["EmpCode"]).ToString();

                        models.Add(model);
                    }
                }
            }
            return models;
        }

        public Employee GetEmployeeById(int Id)
        {
            var model = new Employee();
            string selectCommand = @"Select Id,Name,Email,Phone,EmpCode from Employee where Id=@Id";
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
                        model.EmpCode = (reader["EmpCode"]).ToString();
                    }
                }
                return model;
            }
        }

        public async Task<bool> UpadateEmployee(Employee model)
        {
            SqlParameter[] parameter = {
                new SqlParameter("@Id",model.Id),
                new SqlParameter("@Name",model.Name),
                new SqlParameter("@Email",model.Email),
                new SqlParameter("@Phone",model.Phone),
                new SqlParameter("@EmpCode",model.EmpCode),
            };
            var response = await SqlHelper.ExecuteNonQuery(_connectionString,
                SqlConstant.UpdateEmployee, System.Data.CommandType.Text, parameter);

            return Convert.ToInt32(response) > 0;
        }
    }
}

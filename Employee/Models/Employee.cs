using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Employee Name!")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Enter Employee Designation!")]
        public string EmployeeDesignation { get; set; }

        [Required(ErrorMessage = "Enter Employee Contact!")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Enter Employee Address!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter Employee Joining Date!")]
        public DateTime DOJ { get; set; }

        static string strConnectionString = "Data Source=172.22.17.10;Initial Catalog=Employee;User ID=dtsuser;Password=dtsuser";

        public static IEnumerable<Employee> GetEmployees()
        {
            List<Employee> employeeList = new List<Employee>();

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                employeeList = con.Query<Employee>("GetEmployeeDetails").ToList();
            }

            return employeeList;
        }

        public static Employee GetEmployeeById(int? id)
        {
            Employee employee = new Employee();
            if (id == null)
                return employee;

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", id);
                employee = con.Query<Employee>("GetEmployeeByID", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return employee;
        }

        public static int AddEmployee(Employee employee)
        {
            int rowAffected = 0;
            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeName", employee.EmployeeName);
                parameters.Add("@EmployeeDesignation", employee.EmployeeDesignation);
                parameters.Add("@Contact", employee.Contact);
                parameters.Add("@Address", employee.Address);
                parameters.Add("@DOJ", employee.DOJ);

                rowAffected = con.Execute("InsertEmployee", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }

        public static int UpdateEmployee(Employee employee)
        {
            int rowAffected = 0;

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", employee.Id);
                parameters.Add("@EmployeeName", employee.EmployeeName);
                parameters.Add("@EmployeeDesignation", employee.EmployeeDesignation);
                parameters.Add("@Contact", employee.Contact);
                parameters.Add("@Address", employee.Address);
                parameters.Add("@DOJ", employee.DOJ);
                rowAffected = con.Execute("UpdateEmployee", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }

        public static int DeleteEmployee(int id)
        {
            int rowAffected = 0;
            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                rowAffected = con.Execute("DeleteEmployee", parameters, commandType: CommandType.StoredProcedure);

            }

            return rowAffected;
        }
    }
}

using AssignmentAPI.Models;
using AssignmentAPI.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAPI.Services
{
    public class EmployeeService
    {
        #region Get Employee list
        public static async Task<List<Employee>> ShowEmployeeList()
        {
            #region Declaration
            List<Employee> employees = null;
            DataTable dt = new DataTable();
            SqlConnection con = null;
            List<SqlParameter> param = new List<SqlParameter>();
            #endregion
            try
            {
                #region Interacting with database
                con = await SqlConnectionHelper.GetConnection().ConfigureAwait(false);
                SqlCommand cmd = new SqlCommand("ShowEmployee", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                if (param != null)
                {
                    cmd.Parameters.AddRange(param.ToArray());
                }
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                #endregion

                #region Wrap data
                if (dt.Rows.Count > 0)
                {
                    employees = new List<Employee>();
                    foreach (DataRow row in dt.Rows)
                    {
                        Employee employee = new Employee();
                        employee.EmployeeCode = row["EmployeeCode"] as string ?? string.Empty;
                        employee.Name = row["Name"] as string ?? string.Empty;
                        employee.Department = row["Department"] as string ?? string.Empty;
                        employee.Gender = row["Gender"] as string ?? string.Empty;
                        employee.DOB = row["DOB"] as DateTime? ?? null;
                        employee.JoiningDate = row["JoiningDate"] as DateTime? ?? null;
                        employee.PreviousExperince = row["PreviousExperince"] as decimal? ?? 0;
                        employee.Salary = row["Salary"] as decimal? ?? 0;
                        employee.Address = row["Address"] as string ?? string.Empty;
                        employees.Add(employee);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                #region Close connection
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                #endregion
            }
            return employees;
        }
        #endregion

        #region save new employee
        public static async Task<string> SaveEmployee(Employee employee)
        {
            #region Declaration
            string outputMessage = "";
            SqlConnection con = null;
            SqlCommand cmd = null;
            List<SqlParameter> param = new List<SqlParameter>
            {
                new SqlParameter{ParameterName = "@EmployeeCode", DbType = DbType.String, Value =  employee.EmployeeCode as string ?? string.Empty},
                new SqlParameter{ParameterName = "@Name", DbType = DbType.String, Value =  employee.Name as string ?? string.Empty},
                new SqlParameter{ParameterName = "@Department", DbType = DbType.String, Value = employee.Department as string ?? string.Empty},
                new SqlParameter{ParameterName = "@Gender", DbType = DbType.String, Value = employee.Gender as string ?? string.Empty},
                new SqlParameter{ParameterName = "@DOB", DbType = DbType.Date, Value = employee.DOB as DateTime? ?? null},
                new SqlParameter{ParameterName = "@JoiningDate", DbType = DbType.Date, Value = employee.JoiningDate as DateTime? ?? null},
                 new SqlParameter{ParameterName = "@PreviousExperince", DbType = DbType.Decimal, Value=employee.PreviousExperince as decimal? ?? 0},
                 new SqlParameter{ParameterName = "@Salary", DbType = DbType.Decimal, Value=employee.Salary as decimal? ?? 0},
                 new SqlParameter{ParameterName = "@Address", DbType = DbType.String, Value=employee.Address as string ?? string.Empty},
                new SqlParameter{ParameterName = "@OutputMessage", DbType = DbType.String, Direction = ParameterDirection.Output, Size = 2000}
            };

            #endregion
            try
            {
                #region Interacting with database
                con = await SqlConnectionHelper.GetConnection().ConfigureAwait(false);
                cmd = new SqlCommand("SaveEmployee")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = con,
                };
                cmd.Parameters.AddRange(param.ToArray());
                cmd.ExecuteNonQuery();
                outputMessage = cmd.Parameters["@OutputMessage"].Value.ToString();
                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                #region Close connection
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                #endregion
            }
            return outputMessage;
        }
        #endregion
        
    }
}
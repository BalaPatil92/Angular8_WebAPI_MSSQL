using AssignmentAPI.Models;
using AssignmentAPI.Services;
using AssignmentAPI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAPI.BusinessLayer
{
    public class EmployeeBL
    {
        #region Get  employee list
        public static async Task<ResponseWraper> GetEmployeeList()
        {
            ResponseWraper resp = new ResponseWraper();
            try
            {
                resp.Data = await EmployeeService.ShowEmployeeList().ConfigureAwait(false);
                if (resp.Data == null)
                {
                    throw new Exception("no employee list found");
                }
                else
                {
                    resp.Status = true;
                }
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = ex.Message;
            }
            return resp;
        }
        #endregion

        #region save employee  detail
        public static async Task<ResponseWraper> SaveEmployee(Employee employee)
        {
            ResponseWraper resp = new ResponseWraper();
            try
            {
                string message = await EmployeeService.SaveEmployee(employee).ConfigureAwait(false);
                switch (message)
                {
                    case "Employee data update successfully":
                        resp.Message = message;
                        resp.Status = true;
                        break;
                    case "Employee data save successfully":
                        resp.Message = message;
                        resp.Status = true;
                        break;
                    default:
                        throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                resp.Message = ex.Message;
                resp.Status = false;
            }
            return resp;
        }
        #endregion
    }
}
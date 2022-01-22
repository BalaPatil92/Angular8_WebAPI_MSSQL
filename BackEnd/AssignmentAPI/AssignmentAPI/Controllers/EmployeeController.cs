using AssignmentAPI.BusinessLayer;
using AssignmentAPI.Models;
using AssignmentAPI.Services;
using AssignmentAPI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AssignmentAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        [Route("~/api/v1/employee")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IHttpActionResult> GetEmployees()
        {
            ResponseWraper resp = new ResponseWraper();
            resp = await EmployeeBL.GetEmployeeList();
            if (resp.Status)
            {
                return Content(HttpStatusCode.OK, resp);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, resp);
            }
        }

        [Route("~/api/v1/employee")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IHttpActionResult> SaveEmployee(Employee employee)
        {
            ResponseWraper resp = new ResponseWraper();
            resp = await EmployeeBL.SaveEmployee(employee);
            if (resp.Status)
            {
                return Content(HttpStatusCode.OK, resp);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, resp);
            }
        }
    }
}

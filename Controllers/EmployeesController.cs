using AuthManual.BasicAuth;
using AuthManual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthManual.Controllers
{
    [RoutePrefix("api/Employees")]
    [BasicAuthAttr]
    public class EmployeesController : ApiController
    {
        //GetFewEmployees
        [Route("GetFewEmployees")]
        [BasicAuthorAttr(Roles = "User")]
        public HttpResponseMessage GetFewEmployees() 
        {
            return Request.CreateResponse(HttpStatusCode.OK, Employee.GetEmployees().Where(e => e.Id < 3));
        }
        //Get More Employees
        [Route("GetMoreEmployees")]
        [BasicAuthorAttr(Roles = "Admin")]
        public HttpResponseMessage GetMoreEmployees()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Employee.GetEmployees().Where(e => e.Id < 5));
        }

        //Get all Employees
        [Route("GetAllEmployees")]
        [BasicAuthorAttr(Roles = "SuperAdmin")]
        public HttpResponseMessage GetAllEmployees()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Employee.GetEmployees());
        }
    }
}

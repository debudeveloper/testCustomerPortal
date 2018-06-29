using DynamoDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DynamoDbContext.Controllers
{
    [RoutePrefix("dynamodb")]

    public class HomeController : ApiController
    {
        private static ITest _service;

       public HomeController(ITest service)
        {
            _service = service;
        }
        public HomeController()
        {

        }
        [HttpGet]
        [Route("testing", Name = "Test")]
        public IHttpActionResult Test()
        {
             var res = _service.GetName();
             DdService _dbService = new DdService();
            _dbService.Dbservice();
            return Ok();
        }

        [HttpGet]
        [Route("testing2", Name = "Test2")]
        public IHttpActionResult Test2(int Id)
        {
            var res = _service.GetName();
            DdService _dbService = new DdService();
            _dbService.Dbservice();
            return Ok(2);
        }
    }
}

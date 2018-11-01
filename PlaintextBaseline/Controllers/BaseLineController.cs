using PlaintextBaseline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace PlaintextBaseline.Controllers
{
    public class BaseLineController : ApiController
    {
        [HttpGet]
        [Route("api/baseline/plaintext")]
        public async Task<string> GetPlainText()
        {
            return "Hello World!";
        }

        [HttpGet]
        [Route("api/baseline/json")]
        public async Task<object> GetBasicJson()
        {
            return new People()
            {
                FirstName = "Hello",
                LastName = "World",
                Gendar = Gendaer.Male,
                Age = 56
            };
        }
    }
}
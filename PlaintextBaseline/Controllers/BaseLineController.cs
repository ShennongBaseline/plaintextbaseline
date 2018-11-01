using PlaintextBaseline.Models;
using PlaintextBaseline.Services;
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
                Gender = "M",
                Age = 56
            };
        }

        [HttpGet]
        [Route("api/baseline/redisjson")]
        public async Task<object> GetRedisJson(string key)
        {
            return RedisService.Instance.Get<People>(key);
        }

        [HttpGet]
        [Route("api/baseline/redisjsonasync")]
        public async Task<object> GetRedisJsonAsync([FromUri]string key)
        {
            return RedisService.Instance.GetAsync<People>(key);
        }
    }
}
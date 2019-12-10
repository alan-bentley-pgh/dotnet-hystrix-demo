using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
namespace CircuitBreakerDemo.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IMyCircuitBreakerCommand _myCircuitBreakerCommand;

        public ValuesController(IMyCircuitBreakerCommand myCircuitBreakerCommand)
        {
            _myCircuitBreakerCommand = myCircuitBreakerCommand;
        }

         // GET api/values
        [HttpGet("{name}")]
        public async Task<IEnumerable<string>> Get(string name)
        {
            string a = await _myCircuitBreakerCommand.GetMessage(name);
            return new string[] { a };
        }
        
    }
}

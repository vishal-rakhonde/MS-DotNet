using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApi.Controllers
{
    //localhost:1234/api/Values
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {


        // GET: api/<ValuesController>
        [HttpGet]
        //localhost:1234/api/Values
        public IEnumerable<string> Get()
        {
            //return Employee.GetAllEmployees();
            return new string[] { "Hello", "World" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        //localhost:1234/api/Values/5
        public string Get(int id)
        {
            return "value" + id;
        }

        // POST api/<ValuesController>
        [HttpPost]
        //localhost:1234/api/Values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        //localhost:1234/api/Values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        //localhost:1234/api/Values/5
        public void Delete(int id)
        {
        }
    }
}

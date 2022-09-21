using Microsoft.AspNetCore.Mvc;
using asp_ht4.Interfaces;
using asp_ht4.Models;

namespace asp_ht4.Controllers
{
    public class FloraController : Controller
    {
        private IProvider _iprovider;

        public FloraController(IProvider iprovider)
        {
            _iprovider = iprovider;
        }

        //get

        [HttpGet("Get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var get = _iprovider.Read(id);
            return View(get);
        }

        //post

        [HttpPost]
        public ActionResult<Flora> Post([FromBody] Flora flora)
        {
            if (flora == null)
            {
                return BadRequest();
            }

            _iprovider.Create(flora);
            return Ok(flora);
        }

        //put 
        [HttpPut]
        public void Put([FromBody] Flora flora)
        {
            _iprovider.Update(flora);
        }

        //delete
        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            _iprovider.Delete(id);
        }
    }
}

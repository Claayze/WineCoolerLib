using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWineCooler.Manager;
using WineCoolerLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestWineCooler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineCoolersController : ControllerBase
    {
        private readonly WineCoolersManager mgr = new WineCoolersManager();
        // GET: api/<WineCoolersController>
        [HttpGet]
        public ActionResult<IEnumerable<Cooler>> GetAllCoolers()
        {
            try
            {
                return mgr.GetAllCoolers();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<WineCoolersController>/5
        [HttpGet("{id}")]
        public Cooler GetCooler(int id)
        {
            return mgr.GetCooler(id);
        }

        // POST api/<WineCoolersController>
        [HttpPost]
        public IActionResult AddCooler(int bottlesInStorage, int temp, int capacityOfBottles)
        {
            try
            {
                int maxId = mgr.GetAllCoolers().Max(x => x.CoolerId);
                Cooler cooler1 = new Cooler();
                cooler1.CoolerId = maxId + 1;
                cooler1.CapacityOfBottles = capacityOfBottles;
                cooler1.Temp = temp;
                cooler1.BottlesInStorage = capacityOfBottles;
                mgr.AddCooler(cooler1);

            }
            catch (Exception)
            {
                BadRequest();
            }

            return Ok();
        }

        // DELETE api/<WineCoolersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool delete = mgr.Delete(id);
            if (delete)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}

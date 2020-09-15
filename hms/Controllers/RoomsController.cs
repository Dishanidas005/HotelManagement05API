using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hms.Models;
using hms.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        IRoomsRep db;

        public RoomsController(IRoomsRep _db)
        {
            db = _db;
            _log4net = log4net.LogManager.GetLogger(typeof(RoomsController));

        }
        // GET: api/Rooms
        [HttpGet]
        public IActionResult Get()

        {



            try

            {

                var obj = db.GetDetails();

                if (obj == null)

                    return NotFound();

                return Ok(obj);

            }

            catch (Exception)

            {

                return BadRequest();

            }

        }


        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public IActionResult Get1(int id)

        {

           Rooms data = new Rooms();

            try

            {

                data = db.GetDetail(id);

                if (data == null)

                {

                    return BadRequest(data);

                }

                return Ok(data);

            }

            catch (Exception)

            {

                return BadRequest(data);

            }

        }

        // POST: api/Rooms
        [HttpPost]
        public IActionResult Post([FromBody]Rooms obj)

        {

            if (ModelState.IsValid)

            {

                try

                {

                    var res = db.AddDetail(obj);

                    if (res != 0)

                        return Ok(res);



                    return NotFound();

                }

                catch (Exception)

                {

                    return BadRequest();

                }

            }

            return BadRequest();

        }

        // PUT: api/Rooms/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)

        {

            try

            {

                var result = db.Delete(id);

                if (result == 0)

                {

                    return NotFound(result);

                }

                return Ok(result);

            }

            catch (Exception)

            {



                return BadRequest(id);

            }

        }
    }
}

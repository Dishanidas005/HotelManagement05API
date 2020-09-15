using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hms.Models;
using hms.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase

    {
        readonly log4net.ILog _log4net;
        IUserRep db;
        public UsersController(IUserRep _db)
        {
            db = _db;
            _log4net = log4net.LogManager.GetLogger(typeof(UsersController));

        }
        // GET: api/Users
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

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)

        {

            Users data = new Users();

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

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody]Users obj)

        {

            if (ModelState.IsValid)

            {

                try

                {

                    var res = db.AddDetail(obj);

                    if (res != null)

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

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Users user)

        {

            if (ModelState.IsValid)

            {

                try

                {

                    var result = db.UpdateDetail(id, user);

                    if (result != 1)

                        return NotFound();



                    return Ok(result);

                }

                catch (Exception ex)

                {

                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")

                    {

                        return NotFound();

                    }



                    return BadRequest();

                }

            }



            return BadRequest();

        }





        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)

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

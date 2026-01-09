using EksamensSkabelon;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EksempelREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        //Det er bedre at injecte et interface, fordi det giver løs kobling,
        //bedre testbarhed og gør koden nemmere at udskifte og vedligeholde.
        private IClassRepo _repo;

        public ItemsController(IClassRepo rep)
        { 
            // Dependency Injection
            _repo = rep;
        }

        //kun til documentation i swagger 
        //swagger giver fejl hvis ikke disse er tilstede
        //httpGet, HttpPost osv. angiver hvilken HTTP-metode der skal bruges
        //tells ASP.NET Core which action to invoke when a client makes a GET request that matches the route.
        /*
        [HttpGet] => GET /api/items
        [HttpGet("{id}")] => GET /api/items/3
        [HttpGet("search")] => GET /api/items/search
         */
        [HttpGet]
        //producesResponseType er kun til dokumentation
        [ProducesResponseType(StatusCodes.Status200OK)]
        //Statuskoderne er en type ActionResult
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        //ActionResult<T> gør at vi kan returnere både data og HTTP statuskoder
        public ActionResult<IEnumerable<Class1>> Get()
        {
            List<Class1> entries = _repo.GetAll();
            if (entries.Count == 0) { return NoContent(); }
            else { return Ok(entries); }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Class1> Get(int id)
        {
            Class1? item = _repo.GetById(id);
            if (item == null) { return NotFound(); }
            else { return Ok(item); }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Class1> Post(Class1 item)
        {
            try
            {
                _repo.Add(item);
                string uri = Url.RouteUrl(RouteData.Values) + "/" + item.Id;
                return Created(uri, item);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Class1> Delete(int id)
        {
            Class1? item = _repo.Delete(id);
            if (item == null) { return NotFound(); }
            else { return Ok(item); }
        }


    }
}

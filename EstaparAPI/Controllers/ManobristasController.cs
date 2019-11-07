using Estapar.Domain.Entities;
using Estapar.Service.Services;
using Estapar.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Estapar.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/Manobristas")]
    public class ManobristasController : ControllerBase
    {
        private BaseService<Manobrista> service = new BaseService<Manobrista>();

        [HttpPost]
        public IActionResult Post([FromBody] Manobrista item)
        {
            try
            {
                service.Post<ManobristaValidator>(item);

                return new ObjectResult(item.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Manobrista item)
        {
            try
            {
                service.Put<ManobristaValidator>(item);

                return new ObjectResult(item);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);

                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(service.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(service.Get(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
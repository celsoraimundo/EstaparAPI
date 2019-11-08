using Estapar.Domain.Entities;
using Estapar.Service.Services;
using Estapar.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Estapar.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/Veiculos")]
    public class VeiculosController : ControllerBase
    {
        private BaseService<Veiculo> service;

        public VeiculosController(BaseService<Veiculo> svc)
        {
            service = svc;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Veiculo item)
        {
            try
            {
                service.Post<VeiculoValidator>(item);

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
        public IActionResult Put([FromBody] Veiculo item)
        {
            try
            {
                service.Put<VeiculoValidator>(item);

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
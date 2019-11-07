﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Estapar.Domain.Entities;
using Estapar.Infra.Data.Context;
using Estapar.Service.Services;
using Estapar.Service.Validators;

namespace Estapar.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/VeiculosManobras")]
    public class VeiculoManobrasController : ControllerBase
    {
        private BaseService<VeiculoManobra> service = new BaseService<VeiculoManobra>();

        [HttpPost]
        public IActionResult Post([FromBody] VeiculoManobra item)
        {
            try
            {
                service.Post<VeiculoManobraValidator>(item);

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
        public IActionResult Put([FromBody] VeiculoManobra item)
        {
            try
            {
                service.Put<VeiculoManobraValidator>(item);

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
using Northwind.MVC.Models;
using Northwind.MVC.Service;
using Northwind.Util.Exceptions;
using System;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Northwind.WebAPI.Controllers
{
    public class ShippersController : ApiController
    {
        private readonly ShippersService _service;

        public ShippersController()
        {
            _service = new ShippersService();
        }
        [HttpGet]
        [Route("api/Shippers")]
        public IHttpActionResult GetShippers()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (MyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Shippers/{id}")]
        [ResponseType(typeof(ShippersViewModel))]
        public IHttpActionResult GetShippers(int id)
        {
            try
            {
                ShippersViewModel shippers = _service.GetById(id);
                return Ok(shippers);
            }
            catch (MyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        [Route("api/Shippers/{id}")]
        public IHttpActionResult UpdateShipper(int id, ShippersViewModel shippers)
        {
            try
            {
                shippers.ShipperId = id;
                if(shippers == null)
                {
                    throw new MyException("El expedidor no existe.");
                }
                _service.Edit(shippers);
                return Ok(shippers);
            }
            catch (MyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (_service.GetById(id) == null)
                {
                    return BadRequest(ex.Message);
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Shippers", Name = "PostShippers")]
        [ResponseType(typeof(ShippersViewModel))]
        public IHttpActionResult PostShippers(ShippersViewModel shippers)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _service.Insert(shippers);
                return CreatedAtRoute("PostShippers", new { controller ="Categories", id = shippers.ShipperId }, shippers);
            }
            catch (MyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete]
        [Route("api/Shippers/{id}")]
        [ResponseType(typeof(ShippersViewModel))]
        public IHttpActionResult DeleteShippers(int id)
        {
            try
            {
                ShippersViewModel shippers = _service.GetById(id);
                _service.Delete(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (MyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }
    }
}
using Northwind.Data;
using Northwind.MVC.Models;
using Northwind.MVC.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Northwind.WebAPI.Controllers
{
    public class ShippersController : ApiController
    {
        private ShippersService _service;

        public ShippersController()
        {
            _service = new ShippersService();
        }
        // GET: api/Shippers
        public List<ShippersViewModel> GetShippers()
        {
            return _service.GetAll();
        }

        // GET: api/Shippers/5
        [ResponseType(typeof(Shippers))]
        public IHttpActionResult GetShippers(int id)
        {
            ShippersViewModel shippers = _service.GetById(id);
            if (shippers == null)
            {
                return NotFound();
            }

            return Ok(shippers);
        }

        // PUT: api/Shippers/5
        [ResponseType(typeof(Shippers))]
        public IHttpActionResult PutShippers(int id, ShippersViewModel shippers)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != shippers.ShipperId)
                {
                    return BadRequest();
                }

                _service.Edit(shippers);
            }
            catch (Exception)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Shippers
        [ResponseType(typeof(Shippers))]
        public IHttpActionResult PostShippers(ShippersViewModel shippers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _service.Insert(shippers);
            return CreatedAtRoute("DefaultApi", new { id = shippers.ShipperId }, shippers);
        }

        // DELETE: api/Shippers/5
        [ResponseType(typeof(Shippers))]
        public IHttpActionResult DeleteShippers(int id)
        {
            ShippersViewModel shippers = _service.GetById(id);
            if (shippers == null)
            {
                return NotFound();
            }
            _service.Delete(id);
            return Ok(shippers);
        }

    }
}
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
    public class CategoriesController : ApiController
    {
        private readonly CategoriesService _service;
        public CategoriesController() 
        {
            _service = new CategoriesService();
        }
        [HttpGet]
        [Route("api/Categories")]
        public IHttpActionResult GetCategories()
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
        [Route("api/Categories/{id}")]
        [ResponseType(typeof(CategoriesViewModel))]
        public IHttpActionResult GetCategories(int id)
        {
            try
            {
                CategoriesViewModel categories = _service.GetById(id);
                return Ok(categories);
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
        [Route("api/Categories/{id}")]
        public IHttpActionResult UpdateCategory(int id, CategoriesViewModel categories)
        {
            try
            {
                categories.CategoryID= id;
                if (categories == null)
                {
                    throw new MyException("La categoria no existe");
                }
                _service.Edit(categories);
                return Ok(categories);
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
        [Route("api/Categories", Name = "PostCategories")]
        [ResponseType(typeof(CategoriesViewModel))]
        public IHttpActionResult PostCategories (CategoriesViewModel categories)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _service.Insert(categories);
                return CreatedAtRoute("PostCategories", new {id = categories.CategoryID}, categories);
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
        [Route("api/Categories/{id}")]
        [ResponseType(typeof(CategoriesViewModel))]
        public IHttpActionResult DeleteCategories(int id)
        {
            try
            {
                CategoriesViewModel categories = _service.GetById(id);
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
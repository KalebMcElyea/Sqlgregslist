using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Sqlgregslist.Models;
using Sqlgregslist.Services;

namespace Sqlgregslist.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly CarsService _service;
        public CarsController(CarsService service)
        {
            _service = service;
        }

        [HttpGet] //MY GET ALL METHOD
        public ActionResult<IEnumerable<Car>> GetAll()
        {
            try
            {
                var data = _service.GetAll();
                return Ok(data);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")] //GET BY ID METHOD
        public ActionResult<Car> GetById(int id)
        {
            try
            {
                return Ok(_service.GetById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost] // POST
        public ActionResult<Car> Create([FromBody] Car newCar)
        {
            try
            {
                return Ok(_service.Create(newCar));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")] // PUT
        public ActionResult<Car> Edit([FromBody] Car editCar, int id)
        {
            try
            {
                editCar.Id = id;
                return Ok(_service.Edit(editCar));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")] // DELETE
        public ActionResult<Car> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    }
}
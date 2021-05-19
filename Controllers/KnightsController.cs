using System;
using System.Collections.Generic;
using week10day3afternoon.Models;
using week10day3afternoon.Services;
using Microsoft.AspNetCore.Mvc;

namespace week10day3afternoon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KnightsController : ControllerBase
    {
        private readonly KnightsService _service;

        public KnightsController(KnightsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Knight>> GetAll()
        {
            try
            {
                IEnumerable<Knight> data = _service.GetAll();
                return Ok(data);
            }
            catch (System.Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Knight> GetOne(int id)
        {
            Knight data = _service.GetOne(id);
            return Ok(data);
        }

        [HttpPost]
        public ActionResult<Knight> Create([FromBody] Knight newKnight)
        {
            try
            {
                Knight data = _service.Create(newKnight);
                return Ok(data);
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Knight> Edit(int id, [FromBody] Knight updated)
        {
            updated.Id = id;
            Knight data = _service.Edit(updated);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public ActionResult<Knight> Delete(int id)
        {
            _service.Delete(id);
            return Ok("Successfuly deleted");
        }
    }
}
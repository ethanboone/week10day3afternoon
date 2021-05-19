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
                IEnumerable<Knight> knights = _service.GetAll();
                return Ok(knights);
            }
            catch (System.Exception error)
            {

                return BadRequest(error.Message);
            }
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
    }
}
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseEntitiesController<TEntity> : ControllerBase
    {
        IBaseService<TEntity> _baseService;
        public BaseEntitiesController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }
        // GET: api/<BaseEntitiesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_baseService.GetEntities());
        }

        // GET api/<BaseEntitiesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_baseService.GetEntityById(Guid.Parse(id)));
        }

        // POST api/<BaseEntitiesController>
        [HttpPost]
        public IActionResult Post([FromBody] TEntity entity)
        {
            return Ok(_baseService.AddEntity(entity));
        }

        // PUT api/<BaseEntitiesController>/5
        [HttpPut]
        public IActionResult Put( [FromBody] TEntity entity)
        {
            return Ok(_baseService.UpdateEntity(entity));
        }

        // DELETE api/<BaseEntitiesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(_baseService.DeleteEntity(Guid.Parse(id)));
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WSClinica.Data;
using WSClinica.Models;
using System.Linq;

namespace WSClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private readonly DBClinicaContext context;
        public EspecialidadController(DBClinicaContext context)
        {
            this.context = context;
        }

        //GET 
        [HttpGet]
        public ActionResult<IEnumerable<Especialidad>> Get()
        {
            return context.Especialidades.ToList();
        }

        // GET BY ID
        [HttpGet("{id}")]
        public ActionResult<Especialidad> GetById(int id)
        {
            Especialidad especialidad = context.Especialidades.SingleOrDefault(e => e.Id == id);
            return especialidad;
        }

        //PUT 
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Especialidad especialidad)
        {
            if (id != especialidad.Id)
            {
                return BadRequest();
            }
            context.Entry(especialidad).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();
        }

        //POST
        [HttpPost]
        public ActionResult Post(Especialidad especialidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Especialidades.Add(especialidad);
            context.SaveChanges();

            return Ok();
        }

        //Delete
        [HttpDelete("{id}")]
        public ActionResult<Especialidad> Delete(int id)
        {
            var especialidad = context.Especialidades.FirstOrDefault(e => e.Id == id);

            if (especialidad == null)
            {
                return NotFound();
            }

            context.Especialidades.Remove(especialidad);
            context.SaveChanges();

            return Ok();
        }
    }
}

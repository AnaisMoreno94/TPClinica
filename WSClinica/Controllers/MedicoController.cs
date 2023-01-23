using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WSClinica.Data;
using WSClinica.Models;

namespace WSClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly DBClinicaContext context;
        public MedicoController(DBClinicaContext context)
        {
            this.context = context;
        }

        //GET 
        [HttpGet]
        public ActionResult<IEnumerable<Medico>> Get()
        {
            return context.Medicos.ToList();
        }

        // GET BY ID
        [HttpGet("{id}")]
        public ActionResult<Medico> GetById(int id)
        {
            Medico medico
                = (from a in context.Medicos
                   where a.Id == id
                   select a).SingleOrDefault();
            return medico;
        }

        //PUT 
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Medico medico)
        {
            if (id != medico.Id)
            {
                return BadRequest();
            }
            context.Entry(medico).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();
        }

        //POST
        [HttpPost]
        public ActionResult Post(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Medicos.Add(medico);
            context.SaveChanges();

            return Ok();
        }

        //Delete
        [HttpDelete("{id}")]
        public ActionResult<Medico> Delete(int id)
        {
            var medico = (from a in context.Medicos
                          where a.Id == id
                          select a).SingleOrDefault();

            if (medico == null)
            {
                return NotFound();
            }
            context.Medicos.Remove(medico);
            context.SaveChanges();

            return medico;
        }
    }
}

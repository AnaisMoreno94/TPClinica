using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WSClinica.Models;
using System.Linq;
using WSClinica.Data;

namespace WSClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaController : ControllerBase
    {
        private readonly DBClinicaContext context;
        public ClinicaController(DBClinicaContext context)
        {
            this.context = context;
        }

        //GET 
        [HttpGet]
        public ActionResult<IEnumerable<Clinica>> Get()
        {
            return context.Clinicas.ToList();
        }

        // GET BY ID
        [HttpGet("{id}")]
        public ActionResult<Clinica> GetById(int id)
        {
            Clinica clinica
                = (from a in context.Clinicas
                   where a.Id == id
                   select a).SingleOrDefault();
            return clinica;
        }

        //PUT 
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Clinica clinica)
        {
            if (id != clinica.Id)
            {
                return BadRequest();
            }
            context.Entry(clinica).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();
        }

        //POST
        [HttpPost]
        public ActionResult Post(Clinica clinica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Clinicas.Add(clinica);
            context.SaveChanges();

            return Ok();
        }

        //Delete
        [HttpDelete("{id}")]
        public ActionResult<Clinica> Delete(int id)
        {
            var clinica = (from a in context.Clinicas
                           where a.Id == id
                           select a).SingleOrDefault();

            if (clinica == null)
            {
                return NotFound();
            }
            context.Clinicas.Remove(clinica);
            context.SaveChanges();

            return clinica;
        }
    }
}

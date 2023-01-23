using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WSClinica.Data;
using WSClinica.Models;
using System.Linq;

namespace WSClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        //Inyeccion de dependencia
        //propiedad
        private readonly DBClinicaContext context;

        //constructor
        public HabitacionController(DBClinicaContext context)
        {
            this.context = context;
        }
        //Inyeccion de dependencia--fin

        //Traer todos

        [HttpGet]
        public ActionResult<IEnumerable<Habitacion>> Get()
        {
            return context.Habitaciones.ToList();
        }


        //Traer 1 por Id
        [HttpGet("{id}")]
        public ActionResult<Habitacion> GetbyId(int id)
        {
            Habitacion habitacion = (from h in context.Habitaciones
                                     where h.Id == id
                                     select h).SingleOrDefault();
            return habitacion;
        }

        //Insertar

        [HttpPost]
        public ActionResult Post(Habitacion habitacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Habitaciones.Add(habitacion);
            context.SaveChanges();
            return Ok();
        }

        //Modificar
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Habitacion habitacion)
        {
            if (id != habitacion.Id)
            {
                return BadRequest();
            }
            context.Entry(habitacion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return NoContent();
        }


        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<Habitacion> Delete(int id)
        {
            var habitacion = (from h in context.Habitaciones
                              where h.Id == id
                              select h).SingleOrDefault();
            if (habitacion == null)
            {
                return NotFound();
            }
            context.Habitaciones.Remove(habitacion);
            context.SaveChanges();
            return habitacion;
        }

    }
}

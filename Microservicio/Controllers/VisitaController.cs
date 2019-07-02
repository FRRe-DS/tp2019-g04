using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ORT;

namespace Microservicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitaController : ControllerBase
    {

        private Model _context;

        public VisitaController(Model context)
        {
            _context = context;
        }

        // GET: api/Visita
        [HttpGet("{id}")]
        public Visita GetVisitaId(int id)
        {
            Visita V = new Visita(_context);
            var Visit = V.BuscarVisitaPorId(id);
            return Visit;
        }

        // GET: api/Visita/5
        [HttpGet("{id}/M")]
        public List<Visita> Get(int id)
        {
            Visita V = new Visita(_context);
            List<Visita> Vis = V.BuscarVisitaPorMedicoId(id);
            return Vis;
        }

        // POST: api/Visita
        [HttpPost]
        public bool Post(Visita visita)
        {
            Visita V = new Visita(_context);
            var estado =  V.GuardarVisita(visita);
            if (estado == true)
            {
                return true;
            }
            else { return false; }
        }

        // PUT: api/Visita/5
        [HttpPut]
        public bool Put(Visita visita)
        {
            Visita V = new Visita(_context);
            var estado = V.ActualizarVisita(visita);
            if (estado == true)
            {
                return true;
            }
            else { return false; }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            Visita V = new Visita(_context);
            var VisitaB = V.BuscarVisitaPorId(id);
            var estado = V.BorrarVisita(VisitaB);
            if (estado == true)
            {
                return true;
            }
            else { return false; }
        }
    }
}

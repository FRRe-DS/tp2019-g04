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
        [HttpGet]
        public ActionResult<List<Visita>> Get([FromBody] string HC, DateTime FechaDesde, DateTime FechaHasta)
        {
            HistoriaClinica Vis = JsonConvert.DeserializeObject<HistoriaClinica>(HC);
            Visita V = new Visita(_context);
            var Visit = V.BuscarVisitaPorFecha(Vis.Visitas, FechaDesde, FechaHasta);
            return Visit;
        }

        // GET: api/Visita/5
        [HttpGet("{id}")]
        public ActionResult<List<Visita>> Get(int id)
        {
            Visita V = new Visita(_context);
            List<Visita> Vis = V.BuscarVisitaPorMedicoId(id);
            return Vis;
        }

        // POST: api/Visita
        [HttpPost]
        public void Post([FromBody] string Vi)
        {
            Visita Vis = JsonConvert.DeserializeObject<Visita>(Vi);
            Visita V = new Visita(_context);
            V.GuardarVisita(Vis);
        }

        // PUT: api/Visita/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string Vi)
        {
            Visita Vis = JsonConvert.DeserializeObject<Visita>(Vi);
            Visita V = new Visita(_context);
            V.ActualizarVisita(Vis);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Visita V = new Visita(_context);
            var VisitaB = V.BuscarVisitaPorId(id);
            V.BorrarVisita(VisitaB);
        }
    }
}

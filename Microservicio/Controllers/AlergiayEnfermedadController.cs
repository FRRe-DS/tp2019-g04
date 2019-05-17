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
    public class AlergiayEnfermedadController : ControllerBase
    {

        private Model _context;

        public AlergiayEnfermedadController(Model context)
        {
            _context = context;
        }

        // GET: api/AlergiayEnfermedad
        [HttpGet]
        public ActionResult<AlergiayEnfermedad> Get(string Nombre)
        {
            AlergiayEnfermedad AE = new AlergiayEnfermedad(_context);
            var AyE = AE.BuscarAyEporNombre(Nombre);
            return AyE;
        }

        // GET: api/AlergiayEnfermedad/5
        [HttpGet("{id}")]
        public ActionResult<List<AlergiayEnfermedad>> Get(string Tipo,int Id)
        {
            AlergiayEnfermedad AE = new AlergiayEnfermedad(_context);
            var AyE = AE.BuscarAlergiaOEnfermedad(Tipo);
            return AyE;
        }

        // POST: api/AlergiayEnfermedad
        [HttpPost]
        public void Post([FromBody] string AyE)
        {
            AlergiayEnfermedad AE = JsonConvert.DeserializeObject<AlergiayEnfermedad>(AyE);
            AlergiayEnfermedad ae = new AlergiayEnfermedad(_context);
            ae.GuardarAlergiayEnfermedad(AE);
        }

        // PUT: api/AlergiayEnfermedad/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string AyE)
        {
            AlergiayEnfermedad AE = JsonConvert.DeserializeObject<AlergiayEnfermedad>(AyE);
            AlergiayEnfermedad ae = new AlergiayEnfermedad(_context);
            ae.ActualizarAlergiayEnfermedad(AE);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            AlergiayEnfermedad ae = new AlergiayEnfermedad(_context);
            var AyE = ae.BuscarAyEporId(id);
            ae.BorrarAlergiayEnfermedad(AyE);
        }
    }
}

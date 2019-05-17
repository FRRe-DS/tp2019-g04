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
    public class LineaRecetaController : ControllerBase
    {
        private Model _context;

        public LineaRecetaController(Model context)
        {
            _context = context;
        }

        // GET: api/LineaReceta
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LineaReceta/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/LineaReceta
        [HttpPost]
        public void Post([FromBody] string lr)
        {
            LineaReceta LR = JsonConvert.DeserializeObject<LineaReceta>(lr);
            LineaReceta LinR = new LineaReceta(_context);
            LinR.GuardarLineaReceta(LR);
        }

        // PUT: api/LineaReceta/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string lr)
        {
            LineaReceta LR = JsonConvert.DeserializeObject<LineaReceta>(lr);
            LineaReceta LinR = new LineaReceta(_context);
            LinR.ActualizarLineaReceta(LR);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            LineaReceta LinR = new LineaReceta(_context);
            var LR = LinR.BuscarLRporId(id);
            LinR.BorrarLineaReceta(LR);
        }
    }
}

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
    public class RecetController : ControllerBase
    {
        private Model _context;

        public RecetController(Model context)
        {
            _context = context;
        }
        // GET: api/Recet
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Recet/5
        [HttpGet("{id}")]
        public Receta Get(int id)
        {
            Receta R = new Receta(_context);
            Receta LHC = R.BuscarRecetaPorId(id);
            return LHC;
        }

        // POST: api/Recet
        [HttpPost]
        public void Post([FromBody] string Receta)
        {
            Receta Recet = JsonConvert.DeserializeObject<Receta>(Receta);
            Receta HC = new Receta(_context);
            HC.GuardarReceta(Recet);
        }

        // PUT: api/Recet/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string Receta)
        {
            Receta Recet = JsonConvert.DeserializeObject<Receta>(Receta);
            Receta HC = new Receta(_context);
            HC.ActualizarReceta(Recet);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Receta R = new Receta(_context);
            Receta LHC = R.BuscarRecetaPorId(id);
            R.BorrarReceta(LHC);
        }
    }
}

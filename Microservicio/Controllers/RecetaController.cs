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
    public class RecetaController : ControllerBase
    {

        private Model _context;

        public RecetaController(Model context)
        {
            _context = context;
        }

        // GET: api/Receta
        [HttpGet]
        public ActionResult<List<Receta>> Get()
        {
            
            return null;
        }

        // GET: api/Receta/5
        [HttpGet("{id}")]
        public ActionResult<Receta> Get(int id)
        {
            Receta R = new Receta(_context);
            Receta LHC = R.BuscarRecetaPorId(id);
            return LHC;
        }

        // POST: api/Receta
        [HttpPost]
        public void Post([FromBody] string Receta)
        {
            Receta  Recet = JsonConvert.DeserializeObject<Receta>(Receta);
            Receta HC = new Receta(_context);
            HC.GuardarReceta(Recet);
        }

        // PUT: api/Receta/5
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

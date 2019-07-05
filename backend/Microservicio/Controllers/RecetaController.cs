using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Receta> Get()
        {
            Receta R = new Receta(_context);
            var LHC = R.BuscarReceta();
            return LHC;
        }

        // GET: api/Receta/5
        [HttpGet("{id}")]
        public Receta Get(int id)
        {
            Receta R = new Receta(_context);
            Receta LHC = R.BuscarRecetaPorId(id);
            return LHC;
        }

        // POST: api/Receta
        [HttpPost]
        public bool Post(Receta receta)
        {
            Receta HC = new Receta(_context);
            var estado = HC.GuardarReceta(receta);
            if (estado == true)
            {
                return true;
            }
            else { return false; }
        }

        // PUT: api/Receta
        [HttpPut]
        public bool Put(Receta recet)
        {
            Receta HC = new Receta(_context);
            var estado = HC.ActualizarReceta(recet);
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
            Receta R = new Receta(_context);
            Receta LHC = R.BuscarRecetaPorId(id);
            var estado = R.BorrarReceta(LHC);
            if (estado == true)
            {
                return true;
            }
            else { return false; }
        }
    }
}

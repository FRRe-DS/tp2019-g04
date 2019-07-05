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
        public string Get()
        {
            //LineaReceta LR = new LineaReceta(_context);
            //var TLR = LR.GetHistoriasClinicas();
            //return LHC;
            return "VALUE";
        }

        // GET: api/LineaReceta/5
        [HttpGet("{id}")]
        public List<LineaReceta> Get(int id)
        {
            LineaReceta LR = new LineaReceta(_context);
            var TLR = LR.BuscarLRporReceta(id);
            return TLR;
        }

        // POST: api/LineaReceta
        [HttpPost]
        public bool Post(LineaReceta LR)
        {

            LineaReceta LinR = new LineaReceta(_context);
            var estado = LinR.GuardarLineaReceta(LR);
            if (estado == true)
            {
                return true;
            }
            else { return false; }
        }

        // PUT: api/LineaReceta/5
        [HttpPut]
        public bool Put(LineaReceta LR)
        {
            LineaReceta LinR = new LineaReceta(_context);
            var estado =LinR.ActualizarLineaReceta(LR);
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
            LineaReceta LinR = new LineaReceta(_context);
            var LR = LinR.BuscarLRporId(id);
            var estado=LinR.BorrarLineaReceta(LR);
            if (estado == true)
            {
                return true;
            }
            else { return false; }
        }
    }
}

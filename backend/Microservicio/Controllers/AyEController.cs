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
    [Route("api/alergiayenfermedad")]
    [ApiController]
    public class AyEController : ControllerBase
    {
        private Model _context;

        public AyEController(Model context)
        {
            _context = context;
        }

        // GET: api/AyE
        [HttpGet]
        public List<AlergiayEnfermedad> Get()
        {
            AlergiayEnfermedad AE = new AlergiayEnfermedad(_context);
            var AyE = AE.BuscarAlergiasyEnfermedades();
            return AyE;
        }

        // GET: api/AyE/5
        [HttpGet("{tipo}")]
        public List<AlergiayEnfermedad> Get(string tipo)
        {
            AlergiayEnfermedad AE = new AlergiayEnfermedad(_context);
            var AyE = AE.BuscarAlergiaOEnfermedad(tipo);
            return AyE;
        }

        // POST: api/AyE
        [HttpPost]
        public bool Post(AlergiayEnfermedad AyE)
        {
            AlergiayEnfermedad ae = new AlergiayEnfermedad(_context);
            var estado = ae.GuardarAlergiayEnfermedad(AyE);
            if (estado == true)
            {
                return true;
            }
            else { return false; }
        }

        // PUT: api/AyE/5
        [HttpPut]
        public bool Put(AlergiayEnfermedad AyE)
        {
            
            AlergiayEnfermedad ae = new AlergiayEnfermedad(_context);
            var estado=ae.ActualizarAlergiayEnfermedad(AyE);
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
            AlergiayEnfermedad ae = new AlergiayEnfermedad(_context);
            var AyE = ae.BuscarAyEporId(id);
            var estado= ae.BorrarAlergiayEnfermedad(AyE);
            if (estado == true)
            {
                return true;
            }
            else { return false; }
        }
    }
}

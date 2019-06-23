using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ORT;

namespace Microservicio.Controllers
{
    [Route("api/fede")]
    [ApiController]
    public class AyEdeHCController : ControllerBase
    {
        private Model _context;

        public AyEdeHCController(Model context)
        {
            _context = context;
        }
        // GET: api/AyEdeHC
        [HttpGet]
        public IEnumerable<AyEdeHistoriaClinica> Get()
        {
            AyEdeHistoriaClinica AyEdeHC = new AyEdeHistoriaClinica(_context);
            var LAyEdeHC = AyEdeHC.GetAyEdeHistoriasClinicas();
            return LAyEdeHC;
        }

        // GET: api/AyEdeHC/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AyEdeHC
        [HttpPost]
        public bool Post(AyEdeHistoriaClinica AyEdeHC )
        {
            AyEdeHistoriaClinica AyEdeHist = new AyEdeHistoriaClinica(_context);
            var estado = AyEdeHist.GuardarAyEdeHistoriaClinica(AyEdeHC);
            if (estado == true)
            {
                return true;
            }
            else { return false; }
        }

        // PUT: api/AyEdeHC/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{idHC}/{idAyE}")]
        public bool Delete(int idHC, int idAyE)
        {
            AyEdeHistoriaClinica AyEdeHC = new AyEdeHistoriaClinica(_context);
            var LAyEdeHC = AyEdeHC.GetAyEdeHistoriasClinicasPorId(idHC,idAyE);
            var estado = AyEdeHC.BorrarAyEdeHistoriaClinica(LAyEdeHC);

            if (estado == true)
            {
                return true;
            }
            else { return false; }
        }
    }
}

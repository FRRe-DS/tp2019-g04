using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ORT;

namespace Microservicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private Model _context;

        public ValuesController(Model context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public  IEnumerable<HistoriaClinica> Get()
        {
            HistoriaClinica HC = new HistoriaClinica(_context);
            var LHC = HC.GetHistoriasClinicas();
            return LHC;
        }

        // GET api/values/5
        [HttpGet("{id}" , Name = "Get")]
        public IEnumerable<HistoriaClinica> Get(int id)
        {
            HistoriaClinica HC = new HistoriaClinica(_context);
            var LHC = HC.GetHistoriasClinicasPorPaciente(id);
            return LHC;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string HistC)
        {
            HistoriaClinica HistClinicas = JsonConvert.DeserializeObject<HistoriaClinica>(HistC);
            HistoriaClinica HC = new HistoriaClinica(_context);
            HC.GuardarHistoriaClinica(HistClinicas);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string HistC)
        {
            HistoriaClinica HistClinicas = JsonConvert.DeserializeObject<HistoriaClinica>(HistC);
            HistoriaClinica HC = new HistoriaClinica(_context);
            HC.ActualizarHistoriaClinica(HistClinicas);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            HistoriaClinica HC = new HistoriaClinica(_context);
            var LHC = HC.GetHistoriasClinicasPorId(id);
            HC.BorrarHistoriaClinica(LHC);
            
        }
    }
}

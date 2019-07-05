using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ORT;

namespace Microservicio.Controllers
{
    [Route("api/historiaclinica")]
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

        [HttpGet("{id}/M")]
        public IEnumerable<HistoriaClinica> GetMedicoId(int id)
        {
            Visita V = new Visita(_context);
            List<Visita> Vis = V.BuscarVisitaPorMedicoId(id);
            HistoriaClinica HC = new HistoriaClinica(_context);
            var LHC = HC.GetHistoriaClinicaPorMedico(Vis);
            return LHC;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public HistoriaClinica Get(int id)
        {
            HistoriaClinica HC = new HistoriaClinica(_context);
            var LHC = HC.GetHistoriaClinicaPorPaciente(id);
            return LHC;
        }

        // POST api/values
        [HttpPost]
        public bool Post(HistoriaClinica HistC)
        {
            HistoriaClinica HC = new HistoriaClinica(_context);
            var estado = HC.GuardarHistoriaClinica(HistC);
            if(estado==true)
            {
                return true;
            }else { return false; }
        }

        // PUT api/values
        [HttpPut]
        public bool Put(HistoriaClinica HistC)
        {
            HistoriaClinica HC = new HistoriaClinica(_context);
            var estado = HC.ActualizarHistoriaClinica(HistC);
            if (estado == true)
            {
                return true;
            }
            else { return false; }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            HistoriaClinica HC = new HistoriaClinica(_context);
            var LHC = HC.GetHistoriasClinicasPorId(id);
            var estado = HC.BorrarHistoriaClinica(LHC);

            if (estado == true)
            {
                return true;
            }
            else { return false; }
        }
    }

    [Route("api/historiasmedico")]
    [ApiController]
    public class HistoriaMedico : ControllerBase
    {

        private Model _context;

        public HistoriaMedico(Model context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IEnumerable<HistoriaClinica> GetMedicoId(int id)
        {
            Visita V = new Visita(_context);
            List<Visita> Vis = V.BuscarVisitaPorMedicoId(id);
            HistoriaClinica HC = new HistoriaClinica(_context);
            var LHC = HC.GetHistoriaClinicaPorMedico(Vis);
            return LHC;
        }
    }

    }

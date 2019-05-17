using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORT
{
    public class HistoriaClinica
    {
        public int Id { get; set; }
        public int PacienteId { get; set;}
        public DateTime FechaInicio { get; set; }
        public List<AlergiayEnfermedad> AlergiasyEnfermedades { get; set; }
        public List<Visita> Visitas { get; set; }
        public string Observaciones { get; set; }


        private Model _context;
        public HistoriaClinica(Model context)
        {
            _context = context;
        }
        public List<HistoriaClinica> GetHistoriasClicinas()
        {
            var historiasClinicas = _context.HistoriasClinicas
                .Include(x=>x.AlergiasyEnfermedades)
                                     .ToList();
            return historiasClinicas;
        }

        public HistoriaClinica GetHistoriasClicinasPorPaciente(int PacId)
        {
            var historiaClinica = _context.HistoriasClinicas
                                  .SingleOrDefault(x => x.PacienteId == PacId);
            return historiaClinica;
        }

        public void GuardarHistoriaClinica(HistoriaClinica HC)
        {
            _context.HistoriasClinicas.Add(HC);
            _context.SaveChanges();
        }

        public void ActualizarHistoriaClinica(HistoriaClinica HC)
        {
            _context.HistoriasClinicas.Update(HC);
            _context.SaveChanges();

        }

        public void BorrarHistoriaClinica(HistoriaClinica HC)
        {
            _context.HistoriasClinicas.Remove(HC);
            _context.SaveChanges();
        }
    }
}

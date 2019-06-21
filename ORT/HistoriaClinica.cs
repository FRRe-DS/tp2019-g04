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
        public string GrupoSanguineo { get; set; }
       

        private Model _context;
        public HistoriaClinica(Model context)
        {
            _context = context;
        }
        public List<HistoriaClinica> GetHistoriasClinicas()
        {
            var historiasClinicas = _context.HistoriasClinicas
                                    .Include(x=>x.AlergiasyEnfermedades)
                                    .Include(x=> x.Visitas)
                                     .ToList();
            return historiasClinicas;
        }

        public HistoriaClinica GetHistoriaClinicaPorPaciente(int PacId)
        {
            var historiaClinica =   _context.HistoriasClinicas
                                    .Include(x => x.AlergiasyEnfermedades)
                                    .Include(x => x.Visitas)
                                    .SingleOrDefault(x => x.PacienteId == PacId);
            return historiaClinica;
        }

        public HistoriaClinica GetHistoriasClinicasPorId(int Id)
        {
            var historiaClinica = _context.HistoriasClinicas
                .Include(x => x.AlergiasyEnfermedades)
                                    .Include(x => x.Visitas)
                                  .SingleOrDefault(x => x.Id == Id);
            return historiaClinica;
        }

        public bool GuardarHistoriaClinica(HistoriaClinica HC)
        {
            try
            {
                _context.HistoriasClinicas.Add(HC);
                _context.SaveChanges();
                return true;
            }catch(Exception) { return false;}
        }

        public bool ActualizarHistoriaClinica(HistoriaClinica HC)
        {
            try
            {
                _context.HistoriasClinicas.Update(HC);
                _context.SaveChanges();
                return true;
            }catch(Exception) { return false; }
        }

        public bool BorrarHistoriaClinica(HistoriaClinica HC)
        {
            try
            {
                _context.HistoriasClinicas.Remove(HC);
                _context.SaveChanges();
                return true;
            }catch(Exception) { return false; }
        }
    }
}

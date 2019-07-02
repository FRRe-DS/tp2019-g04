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
        public List<Visita> Visitas { get; set; }
        public string Observaciones { get; set; }
        public string GrupoSanguineo { get; set; }
        public List<AyEdeHistoriaClinica> AlergiasyEnfermedades { get; set; }


        private Model _context;
        public HistoriaClinica(Model context)
        {
            _context = context;
        }
        public List<HistoriaClinica> GetHistoriasClinicas()
        {
            try{
            var historiasClinicas = _context.HistoriasClinicas
                                   .Include(x=>x.AlergiasyEnfermedades)
                                        .ThenInclude(x=>x.AlergiayEnfermedad)
                                    .Include(x=> x.Visitas)
                                    .ThenInclude(x=>x.Receta)
                                    .ThenInclude(x=>x.LineaRecetas)
                                     .ToList();
            return historiasClinicas;
            }catch(Exception){return null;}
        }

        public HistoriaClinica GetHistoriaClinicaPorPaciente(int PacId)
        {
            try{
            var historiaClinica =   _context.HistoriasClinicas
                                   .Include(x => x.AlergiasyEnfermedades)
                                        .ThenInclude(x=>x.AlergiayEnfermedad)
                                    .Include(x => x.Visitas)
                                    .SingleOrDefault(x => x.PacienteId == PacId);
            return historiaClinica;
            }catch(Exception){return null;}
        }

        public List<HistoriaClinica> GetHistoriaClinicaPorMedico(List<Visita> V)
        {
            try
            {
                List<HistoriaClinica> HC = new List<HistoriaClinica>();
                foreach (var a in V)
                {
                    var historiaClinica = _context.HistoriasClinicas                                    
                                        .SingleOrDefault(y => y.Id == a.HistoriaClinicaId );
                    if (historiaClinica != null)
                    {
                        HC.Add(historiaClinica);
                    }
                }
                
                return HC.Distinct().ToList();
            }
            catch (Exception) { return null; }
        }

        public HistoriaClinica GetHistoriasClinicasPorId(int Id)
        {
            try{
            var historiaClinica = _context.HistoriasClinicas
                                    .Include(x => x.AlergiasyEnfermedades)
                                        .ThenInclude(x=>x.AlergiayEnfermedad)
                                    .Include(x => x.Visitas)
                                  .SingleOrDefault(x => x.Id == Id);
            return historiaClinica;
            }catch (Exception){return null;}
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

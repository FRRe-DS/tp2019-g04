using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace ORT
{
    public class Visita
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Diagnostico { get; set; }
        public string Sintomas { get; set; }
        public int MedicoId { get; set; }
        public int HistoriaClinicaId { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }
        public int PartidaMedicamentoId { get; set; }


        public int? RecetaId { get; set; }
        public Receta Receta { get; set; }

        private Model _context;
        public Visita(Model context)
        {
            _context = context;
        }

        public bool GuardarVisita(Visita V)
        {
            try
            {
                _context.Visitas.Add(V);
                _context.SaveChanges();
                return true;
            }catch (Exception) { return false; }
        }

        public Visita BuscarVisitaPorId (int id)
        {
            try{
                var Visita = _context.Visitas
                .Include(x=> x.Receta)
                .SingleOrDefault(x => x.Id == id);
            return Visita;
            }catch (Exception){return null;}
            
        }

        public List<Visita> BuscarVisitaPorFecha(List<Visita> VisitasHC, DateTime FechaDesde, DateTime FechaHasta)
        {
            try{
                var RangoDeVisitas = VisitasHC
                .Where(x => x.Fecha >= FechaDesde)
                .Where(x => x.Fecha <= FechaHasta).ToList();
            return RangoDeVisitas;
            }catch(Exception){return null;}
            
        }

        public List<Visita> BuscarVisitaPorMedicoId(int idMedico)
        {
            try{
                var VisitasMedico = _context.Visitas
                .Include(x=>x.Receta)
                .Where(x => x.MedicoId == idMedico).ToList();
            return VisitasMedico;
            } catch(Exception){return null;}
            
        }

        public bool ActualizarVisita(Visita V)
        {
            try
            {
                _context.Visitas.Update(V);
                _context.SaveChanges();
                return true;
            }
            catch(Exception) { return false; }

        }
        public bool BorrarVisita(Visita V)
        {
            try
            {
                _context.Visitas.Remove(V);
                _context.SaveChanges();
                return true;
            }catch(Exception) { return false; }
        }
    }
}

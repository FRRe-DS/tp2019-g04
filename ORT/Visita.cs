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
        public int RecetaId { get; set; }
        public Receta Receta { get; set; }
        public bool PartidaMedicamentoRealizado { get; set; }



        private Model _context;
        public Visita(Model context)
        {
            _context = context;
        }

        public void GuardarVisita(Visita V)
        {
            _context.Visitas.Add(V);
            _context.SaveChanges();
        }

        public Visita BuscarVisitaPorId (int id)
        {
            var Visita = _context.Visitas
                .Include(x=> x.Receta)
                .SingleOrDefault(x => x.Id == id);
            return Visita;
        }

        public List<Visita> BuscarVisitaPorFecha(List<Visita> VisitasHC, DateTime FechaDesde, DateTime FechaHasta)
        {
            var RangoDeVisitas = VisitasHC
                .Where(x => x.Fecha >= FechaDesde)
                .Where(x => x.Fecha <= FechaHasta).ToList();
            return RangoDeVisitas;
        }

        public List<Visita> BuscarVisitaPorMedicoId(int idMedico)
        {
            var VisitasMedico = _context.Visitas
                .Include(x=>x.Receta)
                .Where(x => x.MedicoId == idMedico).ToList();
            return VisitasMedico;
        }

        public void ActualizarVisita(Visita V)
        {
            _context.Visitas.Update(V);

            _context.SaveChanges();

        }
        public void BorrarVisita(Visita V)
        {
            _context.Visitas.Remove(V);

            _context.SaveChanges();

        }
    }
}

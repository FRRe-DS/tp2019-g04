using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORT
{
    public class AyEdeHistoriaClinica
    {
        public int HistoriaClinicaId { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }

        public int AlergiayEnfermedadId { get; set; }
        public AlergiayEnfermedad AlergiayEnfermedad { get; set; }

        private Model _context;
        public AyEdeHistoriaClinica(Model context)
        {
            _context = context;
        }

        public bool GuardarAyEdeHistoriaClinica(AyEdeHistoriaClinica AyEdeHC)
        {
            try
            {
                _context.AyEdeHistoriasClinicas.Add(AyEdeHC);
                _context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool BorrarAyEdeHistoriaClinica(AyEdeHistoriaClinica AyEdeHC)
        {
            try
            {
                _context.AyEdeHistoriasClinicas.Remove(AyEdeHC);
                _context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public List<AyEdeHistoriaClinica> GetAyEdeHistoriasClinicas()
        {
            try
            {
                var ayEdeHistoriasClinicas = _context.AyEdeHistoriasClinicas
                                        .Include(x => x.HistoriaClinica)
                                        .Include(x => x.AlergiayEnfermedad)
                                         .ToList();
                return ayEdeHistoriasClinicas;
            }
            catch (Exception) { return null; }
        }

        public AyEdeHistoriaClinica GetAyEdeHistoriasClinicasPorId(int IdHistoriaClinica, int IdAyE)
        {
            try
            {
                var ayEdeHC = _context.AyEdeHistoriasClinicas
                    .SingleOrDefault(x => x.HistoriaClinicaId == IdHistoriaClinica && x.AlergiayEnfermedadId==IdAyE);
                return ayEdeHC;
            }
            catch (Exception) { return null; }
        }

        public List<AyEdeHistoriaClinica> GetAlergiasyEnfermedadesPorHC(int idHC)
        {
            try
            {
                var ayEporHC = _context.AyEdeHistoriasClinicas
                .Where(x => x.HistoriaClinicaId == idHC)
                    .Include(x => x.AlergiayEnfermedad).ToList();
                return ayEporHC;
            }
            catch (Exception) { return null; }


        }


    }


    
    
}

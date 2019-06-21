using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORT
{
    public class LineaReceta
    {
        public int Id { get; set; }
        public int MedicamentoId { get; set; }
        public int CantidadRecetado {get;set;}
        public int RecetaId { get; set;}
        public  Receta Receta { get; set;}

        private Model _context;

        public LineaReceta(Model context)
        {
            _context = context;
        }

        public LineaReceta BuscarLRporId(int id)
        {
            try{
            var LR = _context.LineasRecetas
                .SingleOrDefault(x => x.Id == id);
            return LR;
            }catch(Exception){return null;}
        }
        public List<LineaReceta> BuscarLRporReceta(int RecetaId)
        {
            try{
            var LR = _context.LineasRecetas
                .Where(x => x.RecetaId == RecetaId).ToList();
            return LR;
            }catch (Exception){return null;}
        }

        public bool GuardarLineaReceta (LineaReceta LN)
        {
            try
            {
                _context.LineasRecetas.Add(LN);
                _context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
        public bool ActualizarLineaReceta(LineaReceta LN)
        {
            try
            {
                _context.LineasRecetas.Update(LN);
                _context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
        public bool BorrarLineaReceta(LineaReceta LN)
        {
            try
            { 
            _context.LineasRecetas.Remove(LN);
            _context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

    }
}

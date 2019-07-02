using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ORT
{
    public class Receta
    {
        public int Id { get; set; }
        public List<LineaReceta> LineaRecetas { get; set; }
        public int VisitaId { get; set; }
        public Visita Visita { get; set; }

        private Model _context;

        public Receta(Model context)
        {
            _context = context;
        }

        public Receta BuscarRecetaPorId(int Id)
        {
            try{
            var Receta = _context.Recetas
                .Include(x=> x.LineaRecetas)
                .Include(x=>x.Visita)
                .ThenInclude(x=> x.HistoriaClinica)
                .SingleOrDefault(X => X.Id == Id);
            return Receta;
            } catch(Exception){return null;}
        }

        public List<Receta> BuscarReceta()
        {
            try{
            var Receta = _context.Recetas
                .Include(x => x.LineaRecetas)
                .Include(x => x.Visita)
                .ThenInclude(x => x.HistoriaClinica)
                .ToList();
            return Receta;
            } catch(Exception){return null;}
        }

        public bool GuardarReceta(Receta R)
        {
            try
            {
                _context.Recetas.Add(R);
                _context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
        public bool ActualizarReceta(Receta R)
        {

            try
            {
                _context.Recetas.Update(R);
                _context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
     

        }
        public bool BorrarReceta(Receta R)
        {
            try
            {
                _context.Recetas.Remove(R);
                _context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }

        }
    }
}

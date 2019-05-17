using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORT
{
    public class Receta
    {
        public int Id { get; set; }
        public List<LineaReceta> LineaRecetas { get; set; }

        private Model _context;

        public Receta(Model context)
        {
            _context = context;
        }

        public Receta BuscarRecetaPorId(int Id)
        {
            var Receta = _context.Recetas
                .SingleOrDefault(X => X.Id == Id);
            return Receta;
        }

        public void GuardarReceta(Receta R)
        {
            _context.Recetas.Add(R);

            _context.SaveChanges();

        }
        public void ActualizarReceta(Receta R)
        {
            _context.Recetas.Update(R);

            _context.SaveChanges();

        }
        public void BorrarReceta(Receta R)
        {
            _context.Recetas.Remove(R);

            _context.SaveChanges();

        }
    }
}

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
            var LR = _context.LineasRecetas
                .SingleOrDefault(x => x.Id == id);
            return LR;
        }
        public void GuardarLineaReceta (LineaReceta LN)
        {
            _context.LineasRecetas.Add(LN);

            _context.SaveChanges();
        }
        public void ActualizarLineaReceta(LineaReceta LN)
        {
            _context.LineasRecetas.Update(LN);

            _context.SaveChanges();

        }
        public void BorrarLineaReceta(LineaReceta LN)
        {
            _context.LineasRecetas.Remove(LN);

            _context.SaveChanges();
        }

    }
}

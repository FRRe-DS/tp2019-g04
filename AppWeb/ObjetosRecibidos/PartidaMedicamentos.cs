using System;
using System.Collections.Generic;
using System.Text;

namespace ORT
{
    public class PartidaMedicamentos
    {
        public int Id { get; set; }
        public int CantidadDeMedicamentosEntregados { get; set; }
        public int Medicamentos { get; set; }


        private Model _context;
        public PartidaMedicamentos(Model context)
        {
            _context = context;
        }

    }
}

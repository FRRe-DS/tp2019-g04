using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORT
{
    public class AlergiayEnfermedad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int HistoriaClinicaId { get; set; }
        //public List<HistoriaClinica> HistoriaClinica { get; set;}

        private Model _context;

        public AlergiayEnfermedad(Model context)
        {
            _context = context;
        }

        public AlergiayEnfermedad BuscarAyEporNombre(string NombreAE)
        {
           
            var AlergiayEnfermedad = _context.AlergiasyEnfermedades
                                    .SingleOrDefault(x => x.Nombre == NombreAE)
                                    ;
            return AlergiayEnfermedad;
        }

        public AlergiayEnfermedad BuscarAyEporId(int Id)
        {

            var AlergiayEnfermedad = _context.AlergiasyEnfermedades
                                    .SingleOrDefault(x => x.Id == Id)
                                    ;
            return AlergiayEnfermedad;
        }

        public List<AlergiayEnfermedad> BuscarAlergiaOEnfermedad (string tipo)
        {
            var AoE = _context.AlergiasyEnfermedades
                 .Where(x => x.Tipo == tipo)
                 .ToList();
            return AoE;

        }

        public void GuardarAlergiayEnfermedad(AlergiayEnfermedad AE)
        {
            _context.AlergiasyEnfermedades.Add(AE);

            _context.SaveChanges();

        }

        public void ActualizarAlergiayEnfermedad(AlergiayEnfermedad AE)
        {
            _context.AlergiasyEnfermedades.Update(AE);

            _context.SaveChanges();

        }

        public void BorrarAlergiayEnfermedad(AlergiayEnfermedad AE)
        {
            _context.AlergiasyEnfermedades.Remove(AE);

            _context.SaveChanges();

        }
    }
}

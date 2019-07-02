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
        public List<AyEdeHistoriaClinica> HistoriasClinicas { get; set; }

        private Model _context;

        public AlergiayEnfermedad(Model context)
        {
            _context = context;
        }

        public AlergiayEnfermedad BuscarAyEporNombre(string NombreAE)
        {
           try{
            var AlergiayEnfermedad = _context.AlergiasyEnfermedades
                                    .SingleOrDefault(x => x.Nombre == NombreAE)
                                    ;
            return AlergiayEnfermedad;
            }catch(Exception) {return null;}
        }

        public AlergiayEnfermedad BuscarAyEporId(int Id)
        {
            try{
            var AlergiayEnfermedad = _context.AlergiasyEnfermedades
                                    .SingleOrDefault(x => x.Id == Id)
                                    ;
            return AlergiayEnfermedad;
            }catch(Exception) {return null;}
        }

        public List<AlergiayEnfermedad> BuscarAlergiaOEnfermedad (string tipo)
        {
            try{
            var AoE = _context.AlergiasyEnfermedades
                 .Where(x => x.Tipo.Contains(tipo))
                 .ToList();
            return AoE;
            }catch(Exception){return null;}

        }

        public List<AlergiayEnfermedad> BuscarAlergiasyEnfermedades()
        {
            try{
            var AoE = _context.AlergiasyEnfermedades
                 .ToList();
            return AoE;
            }catch(Exception){return null;}

        }
        public bool GuardarAlergiayEnfermedad(AlergiayEnfermedad AE)
        {
            try
            {
                _context.AlergiasyEnfermedades.Add(AE);
                _context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool ActualizarAlergiayEnfermedad(AlergiayEnfermedad AE)
        {
            try
            {
                _context.AlergiasyEnfermedades.Update(AE);
                _context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool BorrarAlergiayEnfermedad(AlergiayEnfermedad AE)
        {
            try
            {
                _context.AlergiasyEnfermedades.Remove(AE);
                _context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}

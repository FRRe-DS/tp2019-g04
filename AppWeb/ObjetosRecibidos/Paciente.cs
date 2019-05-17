using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace ORT
{
    public class Paciente
    {
        public int Id { get; set; }
        public string NombreyApellido { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public int Telefono { get; set;}
        public int Celular { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int DNI { get; set; }
        public string Sexo { get; set; }

        private Model _context;

        public Paciente(Model context)
        {
            _context = context;
        }
    }
}


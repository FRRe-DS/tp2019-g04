using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace ORT
{
    public class Model : DbContext
    {
        public Model(DbContextOptions<Model> options) : base(options) { }
        public DbSet<HistoriaClinica> HistoriasClinicas { get; set; }
        public DbSet<Visita> Visitas { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<LineaReceta> LineasRecetas { get; set; }
        public DbSet<AlergiayEnfermedad> AlergiasyEnfermedades { get; set; }
    }
}

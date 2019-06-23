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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<HistoriaClinica>()
                .HasIndex(u => u.PacienteId)
                .IsUnique();

            //builder.Entity<Receta>()
            //    .HasOne(p => p.Visita)
            //    .WithOne(i => i.Receta)
            //    .HasForeignKey<Receta>(b => b.VisitaId)
            //    .IsRequired();

            builder.Entity<Receta>()
                 .HasIndex(u => u.VisitaId)
                 .IsUnique();
        }
    }
}

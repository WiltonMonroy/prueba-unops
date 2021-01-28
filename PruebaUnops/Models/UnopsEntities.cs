using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PruebaUnops.Models
{
    public partial class UnopsEntities : DbContext
    {
        public UnopsEntities()
            : base("name=UnopsEntities")
        {
        }

        public virtual DbSet<CLASIFICACION> CLASIFICACION { get; set; }
        public virtual DbSet<ESTADO> ESTADO { get; set; }
        public virtual DbSet<INCIDENCIA> INCIDENCIA { get; set; }
        public virtual DbSet<PERFIL> PERFIL { get; set; }
        public virtual DbSet<PRIORIDAD> PRIORIDAD { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CLASIFICACION>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<ESTADO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<INCIDENCIA>()
                .Property(e => e.ASUNTO)
                .IsUnicode(false);

            modelBuilder.Entity<INCIDENCIA>()
                .Property(e => e.HORAS)
                .IsUnicode(false);

            modelBuilder.Entity<PERFIL>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<PRIORIDAD>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<PRIORIDAD>()
                .HasOptional(e => e.INCIDENCIA)
                .WithRequired(e => e.PRIORIDAD);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);
        }
    }
}

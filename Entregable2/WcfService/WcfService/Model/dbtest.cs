using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WcfService.Model
{
    public partial class dbtest : DbContext
    {
        public dbtest()
            : base("name=dbtest")
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Prestamo> Prestamo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(e => e.numero_identificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.tipo_identificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.primer_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.segundo_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.primer_apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.segundo_apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Direccion>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Prestamo>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Prestamo>()
                .Property(e => e.monto_solicitado)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Prestamo>()
                .Property(e => e.moneda)
                .IsUnicode(false);

            modelBuilder.Entity<Prestamo>()
                .Property(e => e.monto_aprobado)
                .HasPrecision(10, 4);
        }
    }
}

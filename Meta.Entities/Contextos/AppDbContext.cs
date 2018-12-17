using Meta.Entities.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.Entities.Contextos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region LLAVES COMPUESTA

            modelBuilder.Entity<UsuarioEntidad>().HasKey(x => new { x.UsuarioId, x.EntidadId });

            #endregion

            #region DELETE FK

            modelBuilder.Entity<Regla>().HasOne<Pasarela>(a => a.Pasarela).WithMany(p => p.Reglas).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Regla>().HasOne<RedPago>(a => a.RedPago).WithMany(p => p.Reglas).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Regla>().HasOne<Entidad>(a => a.Entidad).WithMany(p => p.Reglas).OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Regla>().HasOne<Grupo>(a => a.Grupo).WithMany(p => p.Reglas).OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Regla>().HasOne<Pais>(a => a.Pais).WithMany(p => p.Reglas).OnDelete(DeleteBehavior.Restrict);

            #endregion


        }


        public DbSet<Rol> Roles { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Entidad> Entidades { get; set; }
        public DbSet<Localizacion> Localizaciones { get; set; }
        public DbSet<Pasarela> Pasarelas { get; set; }
        public DbSet<RedPago> RedPagos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioEntidad> UsuarioEntidades { get; set; }
        public DbSet<GrupoPais> GrupoPaises { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<TransaccionEstado> TransaccionEstados { get; set; }
        public DbSet<Regla> Reglas { get; set; }
        public DbSet<Afiliacion> Afiliaciones { get; set; }
        public DbSet<Divisa> Divisas { get; set; }


    }
}

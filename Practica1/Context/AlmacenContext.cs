using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using Practica1.Model;
using Practica1.Context;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Practica1.Context
{
    public class AlmacenContext : DbContext
    {
        //Creacion de las tablas
        public DbSet<Usuario> usuarios {get; set;}
        public DbSet<Producto> productos { get; set; }
        public DbSet<Inventario> inventarios { get; set; }
        public DbSet<Almacen> almacenes { get; set; }

        //Escribir la configuracion para entrar a la base de datos.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server = localhost; database = almacen; password = newjeans");
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(a => a.NumeroSKU);
                entity.Property(a => a.Nombre);
                entity.Property(a => a.Descripcion);
                entity.Property(a => a.Foto);
            });


        }
    }
}

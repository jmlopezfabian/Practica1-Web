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
            optionsBuilder.UseMySQL("server = localhost; database = almacen; user=root;password = Pasword123456");
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>(entidad =>
            {
                entidad.HasKey(a => a.NumeroSKU);
                entidad.Property(a => a.Nombre);
                entidad.Property(a => a.Descripcion);
                entidad.Property(a => a.Foto);
            });

            modelBuilder.Entity<Usuario>(entidad =>
            {
                entidad.HasKey(a => a.Id);
                entidad.Property(a => a.NombreUsuario);
                entidad.Property(a => a.NombreCompleto);
                entidad.Property(a => a.Contrasena);
                entidad.Property(a => a.NivelAcceso);
            });

            modelBuilder.Entity<Inventario>(entidad =>
            {
                entidad.HasKey(a => a.Numero);
                entidad.Property(a => a.Producto);
                entidad.Property(a => a.Cantidad);
                entidad.Property(a => a.Due);
            });

            modelBuilder.Entity<Almacen>(entidad =>
            {
                entidad.HasKey(a => a.numero);
                entidad.Property(a => a.nombre);
                entidad.Property(a => a.inventarios);
            });


        }
    }
}

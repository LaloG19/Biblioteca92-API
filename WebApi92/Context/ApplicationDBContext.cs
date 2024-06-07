using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace WebApi92.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options): base(options)
        {

        }

        //Modelos a mapear
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Insertar en la tabla usuarios
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Lalo",
                    UserName = "admin",
                    Password = "admin",
                    FkRol = 1
                });

            //Insertar en la tabla roles
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRol =     1,
                    Nombre = "Administrador"
                });

            modelBuilder.Entity<Libro>().HasData(
                new Libro
                {
                    PkLibro = 1,
                    Nombre = "El principito",
                    Descripcion = "Un libro muy interesante",
                    Editorial = "Santillana",
                    FkAutor = 1
                });

            modelBuilder.Entity<Autor>().HasData(
                new Autor
                {
                    PkAutor = 1,
                    Nombre = "Antoine de Saint-Exupéry",
                    Nacionalidad = "Francesa"
                });
        }
    }
}

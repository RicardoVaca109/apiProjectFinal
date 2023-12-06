using apiBodega.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace apiBodega.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext( 
            DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<User> usuarios { get; set; }
        public DbSet<Empresa> empresas { get; set; }
        public DbSet<Producto> products { get; set; }
        public DbSet<Pedidos>  pedidos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(

                new User
                {
                    IdUser = 1,
                    UserMail = "rick1234@gmail.com",
                    UserPassword = "admin4321",
                    
                },
                
                new User
                {
                    IdUser = 2,
                    UserMail = "cris1234@gmail.com",
                    UserPassword = "admin1234",
                    
                });

            modelBuilder.Entity<Empresa>().HasData(

                new Empresa
                {
                    EmpresaID = 1,
                    NombreEmpresa = "Supermaxi",
                    Resumen = "Empresa de viveres y consumo"

                },
                new Empresa
                {
                    EmpresaID = 2,
                    NombreEmpresa = "ElectronicaEc",
                    Resumen = "Empresa que vende componentes eléctricos"

                });
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    ProductoId = 1,
                    Nombre = "Clorox",
                    Descripcion = "Cloro para uso doméstico",
                    Precio = 5.99,
                    CtdenStock = 300,
                    ProveedorId = 1,

                },
                new Producto
                {
                    ProductoId = 2,
                    Nombre = "Lava",
                    Descripcion = "Detergente en crema ideal para el lavado manual de vajilla",
                    Precio = 6.99,
                    CtdenStock = 89,
                    ProveedorId = 1,

                },
                new Producto
                {
                    ProductoId = 3,
                    Nombre = " Kit Brochas antiestáticas",
                    Descripcion = "Brochas para limpieza de componentes eléctricos",
                    Precio = 3.50,
                    CtdenStock = 4,
                    ProveedorId = 2,


                },
                new Producto
                {
                    ProductoId = 4,
                    Nombre = "Alcohol Isopropilico",
                    Descripcion = "Alcohol Isopropilico al 90%",
                    Precio = 6.80,
                    CtdenStock = 34,
                    ProveedorId = 2,
                }
                );
            modelBuilder.Entity<Pedidos>().HasData(
                
                new Pedidos
                {
                    ClienteId = 1,
                    CtdProducto = 54,
                    ProveedorId = 2,
                }
                
                
                
                );
            }
        
    }
}

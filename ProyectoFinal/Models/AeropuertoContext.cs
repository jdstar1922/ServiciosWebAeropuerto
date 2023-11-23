using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.ModelsBanco;

namespace ProyectoFinal.Models
{
    public class AeropuertoContext : DbContext
    {
        public AeropuertoContext(DbContextOptions<AeropuertoContext> options) : base(options)
        {
        }
        public DbSet<Aerolinea> Aerolineas { get; set; } = null!;
        public DbSet<Agencia> Agencias { get; set; } = null!;
        public DbSet<Bitacora> Bitacoras { get; set; } = null!;
        public  DbSet<CompraEasyPay> ComprasEasyPay { get; set;} = null!;
        public DbSet<CompraTarjeta> ComprasTarjeta { get; set; } = null!;
        public DbSet<Consecutivo> Consecutivos { get; set; } = null!;
        public DbSet<Error> Errores { get; set; } = null!;
        public DbSet<Mantenimiento> Mantenimientos { get; set; } = null!;
        public DbSet<Pais> Paises { get; set; } = null!;
        public  DbSet<Puerta> Puertas { get; set; } = null!;
        public DbSet<Reserva> Reservas { get; set; } = null!;
        public DbSet<Rol> Roles { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Vuelo> Vuelos { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mantenimiento>()
            .HasOne(e => e.Bitacora)
            .WithOne(e => e.Mantenimiento)
            .HasForeignKey<Bitacora>(e => e.cod_registro);
            modelBuilder.Entity<Mantenimiento>()
            .HasOne(e => e.Consecutivo)
            .WithOne(e => e.Mantenimiento)
            .HasForeignKey<Consecutivo>(e => e.id_consecutivo);
            modelBuilder.Entity<Mantenimiento>()
            .HasOne(e => e.Error)
            .WithOne(e => e.Mantenimiento)
            .HasForeignKey<Error>(e => e.id_error);
           
            modelBuilder.Entity<Aerolinea>()
                .HasOne(e=>e.Pais)
                .WithMany(e=>e.Aerolineas)
                .HasForeignKey(e=>e.id_pais)
                .OnDelete(DeleteBehavior.ClientNoAction);
                
        }
        public DbSet<ProyectoFinal.ModelsBanco.Cuenta>? Cuenta { get; set; }
        public DbSet<ProyectoFinal.ModelsBanco.Transaccion>? Transaccion { get; set; }
        public DbSet<ProyectoFinal.ModelsBanco.UsuarioBanco>? Usuario { get; set; }

    }
}

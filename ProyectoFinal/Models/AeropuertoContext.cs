using Microsoft.EntityFrameworkCore;

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
        public DbSet<CompraEasyPay> ComprasEasyPay { get; set;} = null!;
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
                .HasForeignKey<Mantenimiento>(e => e.cod_registro);
            modelBuilder.Entity<Mantenimiento>()
                .HasOne(e => e.Consecutivo)
                .WithOne(e => e.Mantenimiento)
                .HasForeignKey<Mantenimiento>(e => e.id_consecutivo);
            modelBuilder.Entity<Mantenimiento>()
                .HasOne(e => e.Error)
                .WithOne(e => e.Mantenimiento)
                .HasForeignKey<Mantenimiento>(e => e.id_error);
            modelBuilder.Entity<Aerolinea>()
                .HasOne(e=>e.Pais)
                .WithMany(e=>e.Aerolineas)
                .HasForeignKey(e=>e.id_pais)
                .OnDelete(DeleteBehavior.ClientNoAction);
            modelBuilder.Entity<Usuario>()
                .HasOne(e => e.Rol)
                .WithMany(e => e.usuarios)
                .HasForeignKey(e => e.id_rol);
            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.CompraEasyPays)
                .WithOne(e => e.usuario)
                .HasForeignKey(e => e.id_usuario);
            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.CompraTarjetas)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.id_usuario);
            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Reservas)
                .WithOne(e => e.usuario)
                .HasForeignKey(e => e.id_usuario);
            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Vuelos)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.id_usuario);
            modelBuilder.Entity<Reserva>()
                .HasOne(e => e.Vuelo)
                .WithOne(e => e.Reserva)
                .HasForeignKey<Reserva>(e => e.cod_vuelo)
                .OnDelete(DeleteBehavior.ClientNoAction);
            modelBuilder.Entity<Vuelo>()
                .HasOne(e => e.puerta)
                .WithMany(e => e.vuelo)
                .HasForeignKey(e => e.cod_puerta);
            modelBuilder.Entity<Vuelo>()
                .HasOne(e => e.Pais)
                .WithMany(e => e.Vuelos)
                .HasForeignKey(e => e.id_pais);
            modelBuilder.Entity<Vuelo>()
                .HasOne(e => e.Aerolinea)
                .WithMany(e => e.Vuelos)
                .HasForeignKey(e => e.id_aerolinea);

            modelBuilder.Entity<Pais>()
                .HasMany(e => e.Agencias)
                .WithOne(e => e.Pais)
                .HasForeignKey(e => e.id_pais);

            modelBuilder.Entity<Pais>()
                .HasMany(e => e.Aerolineas)
                .WithOne(e => e.Pais)
                .HasForeignKey(e => e.id_pais);
        }

    }
}

using Microsoft.EntityFrameworkCore;


namespace ProyectoFinal.ModelsBanco
{
    public class BancoContext: DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<Cuenta> Cuentas { get; set; } = null!;
        public DbSet<UsuarioBanco> Usuarios { get; set; } = null!;
        public DbSet<Transaccion> Transacciones { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioBanco>()
                .HasOne(e => e.Cuenta)
                .WithOne(e => e.UsuarioBanco)
                .HasForeignKey<UsuarioBanco>(e => e.num_cuenta);
            modelBuilder.Entity<Transaccion>()
                .HasOne(e => e.Cuenta)
                .WithMany(e => e.Transaccions)
                .HasForeignKey(e => e.num_cuenta);
        }
    }
}

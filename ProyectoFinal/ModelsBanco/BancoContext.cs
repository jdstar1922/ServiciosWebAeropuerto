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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    id_movimientos = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nom_movimientos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad_enviada = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.id_movimientos);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Cedula_usuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nom_usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pri_apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    seg_apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Cedula_usuario);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    num_cuenta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tipo_cuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad_dinero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_movimientos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transaccionid_movimientos = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.num_cuenta);
                    table.ForeignKey(
                        name: "FK_Cuentas_Transacciones_Transaccionid_movimientos",
                        column: x => x.Transaccionid_movimientos,
                        principalTable: "Transacciones",
                        principalColumn: "id_movimientos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_Transaccionid_movimientos",
                table: "Cuentas",
                column: "Transaccionid_movimientos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Transacciones");
        }
    }
}

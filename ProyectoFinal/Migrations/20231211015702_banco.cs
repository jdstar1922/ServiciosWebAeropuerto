using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class banco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    num_cuenta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tipo_cuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad_dinero = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.num_cuenta);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    id_movimientos = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nom_movimientos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad_enviada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    num_cuenta = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.id_movimientos);
                    table.ForeignKey(
                        name: "FK_Transacciones_Cuentas_num_cuenta",
                        column: x => x.num_cuenta,
                        principalTable: "Cuentas",
                        principalColumn: "num_cuenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Cedula_usuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nom_usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pri_apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    seg_apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    num_cuenta = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Cedula_usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Cuentas_num_cuenta",
                        column: x => x.num_cuenta,
                        principalTable: "Cuentas",
                        principalColumn: "num_cuenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_num_cuenta",
                table: "Transacciones",
                column: "num_cuenta");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_num_cuenta",
                table: "Usuarios",
                column: "num_cuenta",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cuentas");
        }
    }
}

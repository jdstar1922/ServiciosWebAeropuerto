using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations.Aeropuerto
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mantenimientos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id_error = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_consecutivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cod_registro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion_mantenimiento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    id_pais = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nom_pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bandera_pais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.id_pais);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id_rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id_rol);
                });

            migrationBuilder.CreateTable(
                name: "Bitacoras",
                columns: table => new
                {
                    cod_registro = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    date_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipo_registro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion_registro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    detalle_registro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacoras", x => x.cod_registro);
                    table.ForeignKey(
                        name: "FK_Bitacoras_Mantenimientos_cod_registro",
                        column: x => x.cod_registro,
                        principalTable: "Mantenimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consecutivos",
                columns: table => new
                {
                    id_consecutivo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    descripcion_consecutivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prefijo_consecutivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rango_Inicial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rango_Final = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor_consecutivo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consecutivos", x => x.id_consecutivo);
                    table.ForeignKey(
                        name: "FK_Consecutivos_Mantenimientos_id_consecutivo",
                        column: x => x.id_consecutivo,
                        principalTable: "Mantenimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Errores",
                columns: table => new
                {
                    id_error = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fecha_error = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mensaje_error = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errores", x => x.id_error);
                    table.ForeignKey(
                        name: "FK_Errores_Mantenimientos_id_error",
                        column: x => x.id_error,
                        principalTable: "Mantenimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agencias",
                columns: table => new
                {
                    cod_agencia = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nom_agencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logo_agencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Paisid_pais = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencias", x => x.cod_agencia);
                    table.ForeignKey(
                        name: "FK_Agencias_Paises_Paisid_pais",
                        column: x => x.Paisid_pais,
                        principalTable: "Paises",
                        principalColumn: "id_pais");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nom_usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pri_apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    seg_apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo_usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contra_usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pregunta_seguridad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    respuesta_seguridad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_rol = table.Column<int>(type: "int", nullable: false),
                    Rolid_rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_Rolid_rol",
                        column: x => x.Rolid_rol,
                        principalTable: "Roles",
                        principalColumn: "id_rol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aerolineas",
                columns: table => new
                {
                    id_aerolinea = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nom_aerolinea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logo_aerolinea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cod_agencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agenciacod_agencia = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    id_pais = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aerolineas", x => x.id_aerolinea);
                    table.ForeignKey(
                        name: "FK_Aerolineas_Agencias_Agenciacod_agencia",
                        column: x => x.Agenciacod_agencia,
                        principalTable: "Agencias",
                        principalColumn: "cod_agencia");
                    table.ForeignKey(
                        name: "FK_Aerolineas_Paises_id_pais",
                        column: x => x.id_pais,
                        principalTable: "Paises",
                        principalColumn: "id_pais");
                });

            migrationBuilder.CreateTable(
                name: "ComprasEasyPay",
                columns: table => new
                {
                    num_cuenta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cod_seguridad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contra_easy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuarioid_usuario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasEasyPay", x => x.num_cuenta);
                    table.ForeignKey(
                        name: "FK_ComprasEasyPay_Usuarios_usuarioid_usuario",
                        column: x => x.usuarioid_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComprasTarjeta",
                columns: table => new
                {
                    num_tarjeta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fecha_expiracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cvv_tarjeta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuarioid_usuario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasTarjeta", x => x.num_tarjeta);
                    table.ForeignKey(
                        name: "FK_ComprasTarjeta_Usuarios_Usuarioid_usuario",
                        column: x => x.Usuarioid_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Puertas",
                columns: table => new
                {
                    cod_puerta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    num_puerta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    detalle_puerta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado_puerta = table.Column<int>(type: "int", nullable: false),
                    nom_estadoP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_aerolinea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aerolineaid_aerolinea = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puertas", x => x.cod_puerta);
                    table.ForeignKey(
                        name: "FK_Puertas_Aerolineas_Aerolineaid_aerolinea",
                        column: x => x.Aerolineaid_aerolinea,
                        principalTable: "Aerolineas",
                        principalColumn: "id_aerolinea");
                });

            migrationBuilder.CreateTable(
                name: "Vuelos",
                columns: table => new
                {
                    cod_vuelo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fecha_vuelo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estado_vuelo = table.Column<int>(type: "int", nullable: false),
                    nom_estadoV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cod_puerta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    puertacod_puerta = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    id_aerolinea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aerolineaid_aerolinea = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    id_pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paisid_pais = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    id_usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuarioid_usuario = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelos", x => x.cod_vuelo);
                    table.ForeignKey(
                        name: "FK_Vuelos_Aerolineas_Aerolineaid_aerolinea",
                        column: x => x.Aerolineaid_aerolinea,
                        principalTable: "Aerolineas",
                        principalColumn: "id_aerolinea");
                    table.ForeignKey(
                        name: "FK_Vuelos_Paises_Paisid_pais",
                        column: x => x.Paisid_pais,
                        principalTable: "Paises",
                        principalColumn: "id_pais");
                    table.ForeignKey(
                        name: "FK_Vuelos_Puertas_puertacod_puerta",
                        column: x => x.puertacod_puerta,
                        principalTable: "Puertas",
                        principalColumn: "cod_puerta");
                    table.ForeignKey(
                        name: "FK_Vuelos_Usuarios_Usuarioid_usuario",
                        column: x => x.Usuarioid_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    num_reservacion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    booking_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad_tkt = table.Column<int>(type: "int", nullable: false),
                    mensaje_reserva = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pago_Final = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuarioid_usuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cod_vuelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vuelocod_vuelo = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.num_reservacion);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_usuarioid_usuario",
                        column: x => x.usuarioid_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Vuelos_Vuelocod_vuelo",
                        column: x => x.Vuelocod_vuelo,
                        principalTable: "Vuelos",
                        principalColumn: "cod_vuelo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aerolineas_Agenciacod_agencia",
                table: "Aerolineas",
                column: "Agenciacod_agencia");

            migrationBuilder.CreateIndex(
                name: "IX_Aerolineas_id_pais",
                table: "Aerolineas",
                column: "id_pais");

            migrationBuilder.CreateIndex(
                name: "IX_Agencias_Paisid_pais",
                table: "Agencias",
                column: "Paisid_pais");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasEasyPay_usuarioid_usuario",
                table: "ComprasEasyPay",
                column: "usuarioid_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasTarjeta_Usuarioid_usuario",
                table: "ComprasTarjeta",
                column: "Usuarioid_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Puertas_Aerolineaid_aerolinea",
                table: "Puertas",
                column: "Aerolineaid_aerolinea");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_usuarioid_usuario",
                table: "Reservas",
                column: "usuarioid_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_Vuelocod_vuelo",
                table: "Reservas",
                column: "Vuelocod_vuelo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Rolid_rol",
                table: "Usuarios",
                column: "Rolid_rol");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_Aerolineaid_aerolinea",
                table: "Vuelos",
                column: "Aerolineaid_aerolinea");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_Paisid_pais",
                table: "Vuelos",
                column: "Paisid_pais");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_puertacod_puerta",
                table: "Vuelos",
                column: "puertacod_puerta");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_Usuarioid_usuario",
                table: "Vuelos",
                column: "Usuarioid_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bitacoras");

            migrationBuilder.DropTable(
                name: "ComprasEasyPay");

            migrationBuilder.DropTable(
                name: "ComprasTarjeta");

            migrationBuilder.DropTable(
                name: "Consecutivos");

            migrationBuilder.DropTable(
                name: "Errores");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Mantenimientos");

            migrationBuilder.DropTable(
                name: "Vuelos");

            migrationBuilder.DropTable(
                name: "Puertas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Aerolineas");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Agencias");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}

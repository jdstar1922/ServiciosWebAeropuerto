using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations.Aeropuerto
{
    public partial class aeropuerto1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    id_rol = table.Column<int>(type: "int", nullable: false),
                    nom_rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id_rol);
                });

            migrationBuilder.CreateTable(
                name: "Mantenimientos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id_error = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id_consecutivo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cod_registro = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    descripcion_mantenimiento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Bitacoras_cod_registro",
                        column: x => x.cod_registro,
                        principalTable: "Bitacoras",
                        principalColumn: "cod_registro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Consecutivos_id_consecutivo",
                        column: x => x.id_consecutivo,
                        principalTable: "Consecutivos",
                        principalColumn: "id_consecutivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Errores_id_error",
                        column: x => x.id_error,
                        principalTable: "Errores",
                        principalColumn: "id_error",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agencias",
                columns: table => new
                {
                    cod_agencia = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nom_agencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logo_agencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_pais = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencias", x => x.cod_agencia);
                    table.ForeignKey(
                        name: "FK_Agencias_Paises_cod_agencia",
                        column: x => x.cod_agencia,
                        principalTable: "Paises",
                        principalColumn: "id_pais",
                        onDelete: ReferentialAction.Cascade);
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
                    id_rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_id_rol",
                        column: x => x.id_rol,
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
                    id_usuario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasEasyPay", x => x.num_cuenta);
                    table.ForeignKey(
                        name: "FK_ComprasEasyPay_Usuarios_id_usuario",
                        column: x => x.id_usuario,
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
                    id_usuario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasTarjeta", x => x.num_tarjeta);
                    table.ForeignKey(
                        name: "FK_ComprasTarjeta_Usuarios_id_usuario",
                        column: x => x.id_usuario,
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
                    cod_puerta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id_aerolinea = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id_pais = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id_usuario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelos", x => x.cod_vuelo);
                    table.ForeignKey(
                        name: "FK_Vuelos_Aerolineas_id_aerolinea",
                        column: x => x.id_aerolinea,
                        principalTable: "Aerolineas",
                        principalColumn: "id_aerolinea",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vuelos_Paises_id_pais",
                        column: x => x.id_pais,
                        principalTable: "Paises",
                        principalColumn: "id_pais",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vuelos_Puertas_cod_puerta",
                        column: x => x.cod_puerta,
                        principalTable: "Puertas",
                        principalColumn: "cod_puerta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vuelos_Usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
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
                    id_usuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cod_vuelo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.num_reservacion);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Vuelos_cod_vuelo",
                        column: x => x.cod_vuelo,
                        principalTable: "Vuelos",
                        principalColumn: "cod_vuelo");
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
                name: "IX_ComprasEasyPay_id_usuario",
                table: "ComprasEasyPay",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasTarjeta_id_usuario",
                table: "ComprasTarjeta",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_cod_registro",
                table: "Mantenimientos",
                column: "cod_registro",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_id_consecutivo",
                table: "Mantenimientos",
                column: "id_consecutivo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_id_error",
                table: "Mantenimientos",
                column: "id_error",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Puertas_Aerolineaid_aerolinea",
                table: "Puertas",
                column: "Aerolineaid_aerolinea");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_cod_vuelo",
                table: "Reservas",
                column: "cod_vuelo",
                unique: true,
                filter: "[cod_vuelo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_id_usuario",
                table: "Reservas",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_id_rol",
                table: "Usuarios",
                column: "id_rol");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_cod_puerta",
                table: "Vuelos",
                column: "cod_puerta");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_id_aerolinea",
                table: "Vuelos",
                column: "id_aerolinea");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_id_pais",
                table: "Vuelos",
                column: "id_pais");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_id_usuario",
                table: "Vuelos",
                column: "id_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprasEasyPay");

            migrationBuilder.DropTable(
                name: "ComprasTarjeta");

            migrationBuilder.DropTable(
                name: "Mantenimientos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Bitacoras");

            migrationBuilder.DropTable(
                name: "Consecutivos");

            migrationBuilder.DropTable(
                name: "Errores");

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

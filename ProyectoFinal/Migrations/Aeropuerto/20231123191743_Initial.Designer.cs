﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinal.Models;

#nullable disable

namespace ProyectoFinal.Migrations.Aeropuerto
{
    [DbContext(typeof(AeropuertoContext))]
    [Migration("20231123191743_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProyectoFinal.Models.Aerolinea", b =>
                {
                    b.Property<string>("id_aerolinea")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Agenciacod_agencia")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("cod_agencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("id_pais")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("logo_aerolinea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nom_aerolinea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_aerolinea");

                    b.HasIndex("Agenciacod_agencia");

                    b.HasIndex("id_pais");

                    b.ToTable("Aerolineas");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Agencia", b =>
                {
                    b.Property<string>("cod_agencia")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Paisid_pais")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("id_pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("logo_agencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nom_agencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cod_agencia");

                    b.HasIndex("Paisid_pais");

                    b.ToTable("Agencias");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Bitacora", b =>
                {
                    b.Property<string>("cod_registro")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("date_registro")
                        .HasColumnType("datetime2");

                    b.Property<string>("descripcion_registro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("detalle_registro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipo_registro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cod_registro");

                    b.ToTable("Bitacoras");
                });

            modelBuilder.Entity("ProyectoFinal.Models.CompraEasyPay", b =>
                {
                    b.Property<string>("num_cuenta")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("cod_seguridad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contra_easy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("id_usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usuarioid_usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("num_cuenta");

                    b.HasIndex("usuarioid_usuario");

                    b.ToTable("ComprasEasyPay");
                });

            modelBuilder.Entity("ProyectoFinal.Models.CompraTarjeta", b =>
                {
                    b.Property<string>("num_tarjeta")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Usuarioid_usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("cvv_tarjeta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fecha_expiracion")
                        .HasColumnType("datetime2");

                    b.Property<string>("id_usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("num_tarjeta");

                    b.HasIndex("Usuarioid_usuario");

                    b.ToTable("ComprasTarjeta");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Consecutivo", b =>
                {
                    b.Property<string>("id_consecutivo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("descripcion_consecutivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prefijo_consecutivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rango_Final")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rango_Inicial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("valor_consecutivo")
                        .HasColumnType("int");

                    b.HasKey("id_consecutivo");

                    b.ToTable("Consecutivos");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Error", b =>
                {
                    b.Property<string>("id_error")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("fecha_error")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mensaje_error")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_error");

                    b.ToTable("Errores");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Mantenimiento", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("cod_registro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descripcion_mantenimiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("id_consecutivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("id_error")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mantenimientos");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Pais", b =>
                {
                    b.Property<string>("id_pais")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("bandera_pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nom_pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_pais");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Puerta", b =>
                {
                    b.Property<string>("cod_puerta")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Aerolineaid_aerolinea")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("detalle_puerta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("estado_puerta")
                        .HasColumnType("int");

                    b.Property<string>("id_aerolinea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nom_estadoP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("num_puerta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cod_puerta");

                    b.HasIndex("Aerolineaid_aerolinea");

                    b.ToTable("Puertas");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Reserva", b =>
                {
                    b.Property<string>("num_reservacion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Pago_Final")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vuelocod_vuelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("booking_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cantidad_tkt")
                        .HasColumnType("int");

                    b.Property<string>("cod_vuelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("id_usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mensaje_reserva")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usuarioid_usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("num_reservacion");

                    b.HasIndex("Vuelocod_vuelo");

                    b.HasIndex("usuarioid_usuario");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Rol", b =>
                {
                    b.Property<int>("id_rol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_rol"), 1L, 1);

                    b.Property<string>("nom_rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_rol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Usuario", b =>
                {
                    b.Property<string>("id_usuario")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Rolid_rol")
                        .HasColumnType("int");

                    b.Property<string>("contra_usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correo_usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_rol")
                        .HasColumnType("int");

                    b.Property<string>("nom_usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pregunta_seguridad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pri_apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("respuesta_seguridad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("seg_apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_usuario");

                    b.HasIndex("Rolid_rol");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Vuelo", b =>
                {
                    b.Property<string>("cod_vuelo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Aerolineaid_aerolinea")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Paisid_pais")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Usuarioid_usuario")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("cod_puerta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("estado_vuelo")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha_vuelo")
                        .HasColumnType("datetime2");

                    b.Property<string>("id_aerolinea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("id_pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("id_usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nom_estadoV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("puertacod_puerta")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("cod_vuelo");

                    b.HasIndex("Aerolineaid_aerolinea");

                    b.HasIndex("Paisid_pais");

                    b.HasIndex("Usuarioid_usuario");

                    b.HasIndex("puertacod_puerta");

                    b.ToTable("Vuelos");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Aerolinea", b =>
                {
                    b.HasOne("ProyectoFinal.Models.Agencia", "Agencia")
                        .WithMany()
                        .HasForeignKey("Agenciacod_agencia");

                    b.HasOne("ProyectoFinal.Models.Pais", "Pais")
                        .WithMany("Aerolineas")
                        .HasForeignKey("id_pais")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.Navigation("Agencia");

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Agencia", b =>
                {
                    b.HasOne("ProyectoFinal.Models.Pais", "Pais")
                        .WithMany("Agencias")
                        .HasForeignKey("Paisid_pais");

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Bitacora", b =>
                {
                    b.HasOne("ProyectoFinal.Models.Mantenimiento", "Mantenimiento")
                        .WithOne("Bitacora")
                        .HasForeignKey("ProyectoFinal.Models.Bitacora", "cod_registro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mantenimiento");
                });

            modelBuilder.Entity("ProyectoFinal.Models.CompraEasyPay", b =>
                {
                    b.HasOne("ProyectoFinal.Models.Usuario", "usuario")
                        .WithMany("CompraEasyPays")
                        .HasForeignKey("usuarioid_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("ProyectoFinal.Models.CompraTarjeta", b =>
                {
                    b.HasOne("ProyectoFinal.Models.Usuario", "Usuario")
                        .WithMany("CompraTarjetas")
                        .HasForeignKey("Usuarioid_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Consecutivo", b =>
                {
                    b.HasOne("ProyectoFinal.Models.Mantenimiento", "Mantenimiento")
                        .WithOne("Consecutivo")
                        .HasForeignKey("ProyectoFinal.Models.Consecutivo", "id_consecutivo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mantenimiento");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Error", b =>
                {
                    b.HasOne("ProyectoFinal.Models.Mantenimiento", "Mantenimiento")
                        .WithOne("Error")
                        .HasForeignKey("ProyectoFinal.Models.Error", "id_error")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mantenimiento");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Puerta", b =>
                {
                    b.HasOne("ProyectoFinal.Models.Aerolinea", "Aerolinea")
                        .WithMany("Puertas")
                        .HasForeignKey("Aerolineaid_aerolinea");

                    b.Navigation("Aerolinea");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Reserva", b =>
                {
                    b.HasOne("ProyectoFinal.Models.Vuelo", "Vuelo")
                        .WithMany()
                        .HasForeignKey("Vuelocod_vuelo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoFinal.Models.Usuario", "usuario")
                        .WithMany("Reservas")
                        .HasForeignKey("usuarioid_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vuelo");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Usuario", b =>
                {
                    b.HasOne("ProyectoFinal.Models.Rol", "Rol")
                        .WithMany("usuarios")
                        .HasForeignKey("Rolid_rol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Vuelo", b =>
                {
                    b.HasOne("ProyectoFinal.Models.Aerolinea", "Aerolinea")
                        .WithMany("Vuelos")
                        .HasForeignKey("Aerolineaid_aerolinea");

                    b.HasOne("ProyectoFinal.Models.Pais", "Pais")
                        .WithMany("Vuelos")
                        .HasForeignKey("Paisid_pais");

                    b.HasOne("ProyectoFinal.Models.Usuario", "Usuario")
                        .WithMany("Vuelos")
                        .HasForeignKey("Usuarioid_usuario");

                    b.HasOne("ProyectoFinal.Models.Puerta", "puerta")
                        .WithMany("vuelo")
                        .HasForeignKey("puertacod_puerta");

                    b.Navigation("Aerolinea");

                    b.Navigation("Pais");

                    b.Navigation("Usuario");

                    b.Navigation("puerta");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Aerolinea", b =>
                {
                    b.Navigation("Puertas");

                    b.Navigation("Vuelos");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Mantenimiento", b =>
                {
                    b.Navigation("Bitacora");

                    b.Navigation("Consecutivo")
                        .IsRequired();

                    b.Navigation("Error")
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoFinal.Models.Pais", b =>
                {
                    b.Navigation("Aerolineas");

                    b.Navigation("Agencias");

                    b.Navigation("Vuelos");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Puerta", b =>
                {
                    b.Navigation("vuelo");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Rol", b =>
                {
                    b.Navigation("usuarios");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Usuario", b =>
                {
                    b.Navigation("CompraEasyPays");

                    b.Navigation("CompraTarjetas");

                    b.Navigation("Reservas");

                    b.Navigation("Vuelos");
                });
#pragma warning restore 612, 618
        }
    }
}

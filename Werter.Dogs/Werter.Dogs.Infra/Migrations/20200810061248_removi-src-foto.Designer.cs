﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Werter.Dogs.Infra.Contexto;

namespace Werter.Dogs.Infra.Migrations
{
    [DbContext(typeof(DogsContexto))]
    [Migration("20200810061248_removi-src-foto")]
    partial class removisrcfoto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Werter.Dogs.Dominio.Entidades.Foto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeDeAcessos")
                        .HasColumnType("int");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TB_Fotos");
                });

            modelBuilder.Entity("Werter.Dogs.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("NomeDeUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(90)")
                        .HasMaxLength(90);

                    b.HasKey("Id");

                    b.ToTable("TB_Usuarios");
                });

            modelBuilder.Entity("Werter.Dogs.Dominio.Entidades.Foto", b =>
                {
                    b.HasOne("Werter.Dogs.Dominio.Entidades.Usuario", "Usuario")
                        .WithMany("Fotos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

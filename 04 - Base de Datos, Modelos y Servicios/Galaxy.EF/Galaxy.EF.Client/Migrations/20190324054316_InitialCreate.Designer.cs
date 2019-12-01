﻿// <auto-generated />
using System;
using Galaxy.EF.Client.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Galaxy.EF.Client.Migrations
{
    [DbContext(typeof(GalaxyContext))]
    [Migration("20190324054316_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Galaxy.EF.Client.Models.Comentario", b =>
                {
                    b.Property<int>("ComentarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contenido")
                        .IsUnicode(false);

                    b.Property<DateTime>("FechaActualizacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("PostId");

                    b.Property<DateTime>("SysEndTime");

                    b.Property<DateTime>("SysStartTime");

                    b.Property<int>("UsuarioIdActualizacion");

                    b.Property<int>("UsuarioIdCreacion");

                    b.Property<int>("UsuarioIdPropietario");

                    b.HasKey("ComentarioId");

                    b.HasIndex("PostId");

                    b.HasIndex("UsuarioIdActualizacion");

                    b.HasIndex("UsuarioIdCreacion");

                    b.HasIndex("UsuarioIdPropietario");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("Galaxy.EF.Client.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contenido")
                        .IsUnicode(false);

                    b.Property<DateTime>("FechaActualizacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("SysEndTime");

                    b.Property<DateTime>("SysStartTime");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<int>("UsuarioIdActualizacion");

                    b.Property<int>("UsuarioIdCreacion");

                    b.Property<int>("UsuarioIdPropietario");

                    b.HasKey("PostId");

                    b.HasIndex("UsuarioIdActualizacion");

                    b.HasIndex("UsuarioIdCreacion");

                    b.HasIndex("UsuarioIdPropietario");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Galaxy.EF.Client.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApellidoMaterno")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Galaxy.EF.Client.Models.Comentario", b =>
                {
                    b.HasOne("Galaxy.EF.Client.Models.Post", "Post")
                        .WithMany("Comentario")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_ComentarioPost");

                    b.HasOne("Galaxy.EF.Client.Models.Usuario", "UsuarioIdActualizacionNavigation")
                        .WithMany("ComentarioUsuarioIdActualizacionNavigation")
                        .HasForeignKey("UsuarioIdActualizacion")
                        .HasConstraintName("FK_ComentarioUsuarioActualizacion");

                    b.HasOne("Galaxy.EF.Client.Models.Usuario", "UsuarioIdCreacionNavigation")
                        .WithMany("ComentarioUsuarioIdCreacionNavigation")
                        .HasForeignKey("UsuarioIdCreacion")
                        .HasConstraintName("FK_ComentarioUsuarioCreacion");

                    b.HasOne("Galaxy.EF.Client.Models.Usuario", "UsuarioIdPropietarioNavigation")
                        .WithMany("ComentarioUsuarioIdPropietarioNavigation")
                        .HasForeignKey("UsuarioIdPropietario")
                        .HasConstraintName("FK_ComentarioUsuarioPropietario");
                });

            modelBuilder.Entity("Galaxy.EF.Client.Models.Post", b =>
                {
                    b.HasOne("Galaxy.EF.Client.Models.Usuario", "UsuarioIdActualizacionNavigation")
                        .WithMany("PostUsuarioIdActualizacionNavigation")
                        .HasForeignKey("UsuarioIdActualizacion")
                        .HasConstraintName("FK_PostUsuarioActualizacion");

                    b.HasOne("Galaxy.EF.Client.Models.Usuario", "UsuarioIdCreacionNavigation")
                        .WithMany("PostUsuarioIdCreacionNavigation")
                        .HasForeignKey("UsuarioIdCreacion")
                        .HasConstraintName("FK_PostUsuarioCreacion");

                    b.HasOne("Galaxy.EF.Client.Models.Usuario", "UsuarioIdPropietarioNavigation")
                        .WithMany("PostUsuarioIdPropietarioNavigation")
                        .HasForeignKey("UsuarioIdPropietario")
                        .HasConstraintName("FK_PostUsuarioPropietario");
                });
#pragma warning restore 612, 618
        }
    }
}
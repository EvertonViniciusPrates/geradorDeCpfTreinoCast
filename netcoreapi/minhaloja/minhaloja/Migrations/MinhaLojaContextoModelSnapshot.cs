﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using minhaloja.Context;

namespace minhaloja.Migrations
{
    [DbContext(typeof(MinhaLojaContexto))]
    partial class MinhaLojaContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("minhaloja.Models.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cd_categoria");

                    b.Property<string>("Descricao")
                        .HasColumnName("dc_categoria");

                    b.HasKey("Id");

                    b.ToTable("categoria","dbo");
                });

            modelBuilder.Entity("minhaloja.Models.Fabricante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cd_fabricante");

                    b.Property<string>("Cnpj")
                        .HasColumnName("cd_cnpj");

                    b.HasKey("Id");

                    b.ToTable("fabricante","dbo");
                });

            modelBuilder.Entity("minhaloja.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cd_produto");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnName("cd_categoria");

                    b.Property<DateTime>("DataDeFabricacao")
                        .HasColumnName("dt_fabricacao");

                    b.Property<string>("Descricao")
                        .HasColumnName("dc_produto");

                    b.Property<Guid>("FabricanteId")
                        .HasColumnName("cd_fabricante");

                    b.Property<string>("Nome")
                        .HasColumnName("nm_produto");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FabricanteId");

                    b.ToTable("produto","dbo");
                });

            modelBuilder.Entity("minhaloja.Models.Produto", b =>
                {
                    b.HasOne("minhaloja.Models.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("minhaloja.Models.Fabricante", "Fabricante")
                        .WithMany()
                        .HasForeignKey("FabricanteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MundiUtil.WEB.Models.DAL;

namespace MundiUtil.WEB.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220409213535_se agrega la tabla ClaseInsumo")]
    partial class seagregalatablaClaseInsumo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MundiUtil.WEB.Models.Entities.ClaseInsumo", b =>
                {
                    b.Property<int>("IdTipoInsumo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TipoInsumo")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Tipo Insumo");

                    b.HasKey("IdTipoInsumo");

                    b.ToTable("clases");
                });

            modelBuilder.Entity("MundiUtil.WEB.Models.Entities.Insumo", b =>
                {
                    b.Property<int>("IdInsumos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NombreInsumo");

                    b.Property<int>("ReferenciaInsumo")
                        .HasColumnType("int");

                    b.Property<int>("TipoInsumo")
                        .HasColumnType("int");

                    b.HasKey("IdInsumos");

                    b.ToTable("insumo");
                });
#pragma warning restore 612, 618
        }
    }
}

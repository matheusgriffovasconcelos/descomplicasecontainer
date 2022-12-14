﻿// <auto-generated />
using System;
using Auth.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DescomplicaseApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221214031021_v6semfkoracamento")]
    partial class v6semfkoracamento
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Auth.Models.CategoriaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Auth.Models.FornecedorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Caracteristicas")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cidade")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("IdCategoria")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPremium")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.Property<string>("UF")
                        .HasMaxLength(2)
                        .HasColumnType("TEXT");

                    b.Property<double>("ValorPessoa")
                        .HasColumnType("REAL");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("REAL");

                    b.Property<double>("aPartir")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("Auth.Models.OrcamentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumConvidados")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ValorDesejado")
                        .HasColumnType("REAL");

                    b.Property<double>("ValorOrcamento")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Orcamentos");
                });

            modelBuilder.Entity("Auth.Models.ProdutoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Estoque")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("IdCategoria")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<double?>("Preco")
                        .IsRequired()
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Auth.Models.UsuarioModel", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataCasamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeConjuge")
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SobreNome")
                        .HasColumnType("TEXT");

                    b.HasKey("IdUsuario");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            IdUsuario = 1,
                            DataCasamento = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@email.com",
                            IsAdmin = true,
                            Nome = "Administrador do Sistema",
                            Senha = "$2a$10$q86Z51G.wIE1YvICoEGOVOc/tyagknoTMyQFV7RJcZ3OtVnKo1ylq"
                        });
                });

            modelBuilder.Entity("Auth.Models.FornecedorModel", b =>
                {
                    b.HasOne("Auth.Models.CategoriaModel", "Categoria")
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Auth.Models.ProdutoModel", b =>
                {
                    b.HasOne("Auth.Models.CategoriaModel", "Categoria")
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });
#pragma warning restore 612, 618
        }
    }
}

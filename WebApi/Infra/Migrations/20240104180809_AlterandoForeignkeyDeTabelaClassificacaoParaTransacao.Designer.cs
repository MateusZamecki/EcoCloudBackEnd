﻿// <auto-generated />
using System;
using Infra.ConexaoComBanco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20240104180809_AlterandoForeignkeyDeTabelaClassificacaoParaTransacao")]
    partial class AlterandoForeignkeyDeTabelaClassificacaoParaTransacao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dominio.Colunas.Coluna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("QuadroId")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuadroId");

                    b.ToTable("Colunas", (string)null);
                });

            modelBuilder.Entity("Dominio.Colunas.Configuracao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ColunaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("date")
                        .HasColumnName("Data");

                    b.Property<int>("IntervaloDeDias")
                        .HasColumnType("int")
                        .HasColumnName("IntervaloDeDias");

                    b.HasKey("Id");

                    b.HasIndex("ColunaId")
                        .IsUnique()
                        .HasFilter("[ColunaId] IS NOT NULL");

                    b.ToTable("Configuracoes", (string)null);
                });

            modelBuilder.Entity("Dominio.Quadros.Quadro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Quadros", (string)null);
                });

            modelBuilder.Entity("Dominio.Servicos.LogDosServicos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataDeExcecucao")
                        .HasColumnType("datetime");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<int>("TipoDeInformacao")
                        .HasColumnType("int");

                    b.Property<int>("TipoDeServico")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LogDosServicos", (string)null);
                });

            modelBuilder.Entity("Dominio.Transacoes.Classificacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classificacoes", (string)null);
                });

            modelBuilder.Entity("Dominio.Transacoes.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int?>("ClassificacaoId")
                        .HasColumnType("int");

                    b.Property<int>("ColunaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDeCriacao")
                        .HasColumnType("datetime");

                    b.Property<bool>("EhRecorrente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("ClassificacaoId")
                        .IsUnique()
                        .HasFilter("[ClassificacaoId] IS NOT NULL");

                    b.HasIndex("ColunaId");

                    b.ToTable("Transacoes", (string)null);
                });

            modelBuilder.Entity("Dominio.Usuarios.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataDeCriacao")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Dominio.Colunas.Coluna", b =>
                {
                    b.HasOne("Dominio.Quadros.Quadro", null)
                        .WithMany("Colunas")
                        .HasForeignKey("QuadroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Dominio.ObjetosDeValor.Nome", "Nome", b1 =>
                        {
                            b1.Property<int>("ColunaId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("Nome");

                            b1.HasKey("ColunaId");

                            b1.ToTable("Colunas");

                            b1.WithOwner()
                                .HasForeignKey("ColunaId");
                        });

                    b.Navigation("Nome");
                });

            modelBuilder.Entity("Dominio.Colunas.Configuracao", b =>
                {
                    b.HasOne("Dominio.Colunas.Coluna", null)
                        .WithOne("Configuracao")
                        .HasForeignKey("Dominio.Colunas.Configuracao", "ColunaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dominio.Quadros.Quadro", b =>
                {
                    b.HasOne("Dominio.Usuarios.Usuario", null)
                        .WithMany("Quadros")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Dominio.ObjetosDeValor.Nome", "Nome", b1 =>
                        {
                            b1.Property<int>("QuadroId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("Nome");

                            b1.HasKey("QuadroId");

                            b1.ToTable("Quadros");

                            b1.WithOwner()
                                .HasForeignKey("QuadroId");
                        });

                    b.Navigation("Nome");
                });

            modelBuilder.Entity("Dominio.Transacoes.Classificacao", b =>
                {
                    b.OwnsOne("Dominio.ObjetosDeValor.Nome", "Nome", b1 =>
                        {
                            b1.Property<int>("ClassificacaoId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("Nome");

                            b1.HasKey("ClassificacaoId");

                            b1.ToTable("Classificacoes");

                            b1.WithOwner()
                                .HasForeignKey("ClassificacaoId");
                        });

                    b.Navigation("Nome");
                });

            modelBuilder.Entity("Dominio.Transacoes.Transacao", b =>
                {
                    b.HasOne("Dominio.Transacoes.Classificacao", "Classificacao")
                        .WithOne()
                        .HasForeignKey("Dominio.Transacoes.Transacao", "ClassificacaoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dominio.Colunas.Coluna", null)
                        .WithMany("Transacoes")
                        .HasForeignKey("ColunaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Dominio.ObjetosDeValor.Quantia", "Quantia", b1 =>
                        {
                            b1.Property<int>("TransacaoId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Valor")
                                .HasColumnType("numeric(28,2)")
                                .HasColumnName("Quantia");

                            b1.HasKey("TransacaoId");

                            b1.ToTable("Transacoes");

                            b1.WithOwner()
                                .HasForeignKey("TransacaoId");
                        });

                    b.OwnsOne("Dominio.ObjetosDeValor.Nome", "Nome", b1 =>
                        {
                            b1.Property<int>("TransacaoId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("Nome");

                            b1.HasKey("TransacaoId");

                            b1.ToTable("Transacoes");

                            b1.WithOwner()
                                .HasForeignKey("TransacaoId");
                        });

                    b.Navigation("Classificacao");

                    b.Navigation("Nome");

                    b.Navigation("Quantia");
                });

            modelBuilder.Entity("Dominio.Usuarios.Usuario", b =>
                {
                    b.OwnsOne("Dominio.ObjetosDeValor.Email", "Email", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("varchar(200)")
                                .HasColumnName("Email");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("Dominio.ObjetosDeValor.Nome", "Nome", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("Nome");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.Navigation("Email");

                    b.Navigation("Nome");
                });

            modelBuilder.Entity("Dominio.Colunas.Coluna", b =>
                {
                    b.Navigation("Configuracao");

                    b.Navigation("Transacoes");
                });

            modelBuilder.Entity("Dominio.Quadros.Quadro", b =>
                {
                    b.Navigation("Colunas");
                });

            modelBuilder.Entity("Dominio.Usuarios.Usuario", b =>
                {
                    b.Navigation("Quadros");
                });
#pragma warning restore 612, 618
        }
    }
}

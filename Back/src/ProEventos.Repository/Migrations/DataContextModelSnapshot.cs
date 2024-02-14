﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProEventos.Repository;

#nullable disable

namespace ProEventos.Repository.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.14");

            modelBuilder.Entity("ProEventos.Domain.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataEvento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagemURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("QtdPessoas")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tema")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Eventos", (string)null);
                });

            modelBuilder.Entity("ProEventos.Domain.Models.Lote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<int>("EventoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Preco")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.ToTable("Lotes", (string)null);
                });

            modelBuilder.Entity("ProEventos.Domain.Models.Palestrante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagemURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MiniCurriculo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Palestrantes", (string)null);
                });

            modelBuilder.Entity("ProEventos.Domain.Models.PalestranteEvento", b =>
                {
                    b.Property<int>("EventoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PalestranteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventoId", "PalestranteId");

                    b.HasIndex("PalestranteId");

                    b.ToTable("PalestrantesEventos", (string)null);
                });

            modelBuilder.Entity("ProEventos.Domain.Models.RedeSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PalestranteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("PalestranteId");

                    b.ToTable("RedesSociais", (string)null);
                });

            modelBuilder.Entity("ProEventos.Domain.Models.Lote", b =>
                {
                    b.HasOne("ProEventos.Domain.Models.Evento", "Evento")
                        .WithMany("Lotes")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("ProEventos.Domain.Models.PalestranteEvento", b =>
                {
                    b.HasOne("ProEventos.Domain.Models.Evento", "Evento")
                        .WithMany("PalestrantesEventos")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProEventos.Domain.Models.Palestrante", "Palestrante")
                        .WithMany("PalestrantesEventos")
                        .HasForeignKey("PalestranteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Palestrante");
                });

            modelBuilder.Entity("ProEventos.Domain.Models.RedeSocial", b =>
                {
                    b.HasOne("ProEventos.Domain.Models.Evento", "Evento")
                        .WithMany("RedesSociais")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProEventos.Domain.Models.Palestrante", "Palestrante")
                        .WithMany("RedesSociais")
                        .HasForeignKey("PalestranteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Evento");

                    b.Navigation("Palestrante");
                });

            modelBuilder.Entity("ProEventos.Domain.Models.Evento", b =>
                {
                    b.Navigation("Lotes");

                    b.Navigation("PalestrantesEventos");

                    b.Navigation("RedesSociais");
                });

            modelBuilder.Entity("ProEventos.Domain.Models.Palestrante", b =>
                {
                    b.Navigation("PalestrantesEventos");

                    b.Navigation("RedesSociais");
                });
#pragma warning restore 612, 618
        }
    }
}

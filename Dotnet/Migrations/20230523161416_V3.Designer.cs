﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

#nullable disable

namespace Web.Migrations
{
    [DbContext(typeof(KlinikaContext))]
    [Migration("20230523161416_V3")]
    partial class V3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Cenovnik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.HasKey("ID");

                    b.ToTable("Cenovnik");
                });

            modelBuilder.Entity("Models.Formular", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AdresaStanovanja")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("ClanKlinikeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("JMBG")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("MestoStanovanja")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("PacijentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClanKlinikeID");

                    b.HasIndex("PacijentID");

                    b.ToTable("Formulari");
                });

            modelBuilder.Entity("Models.Korisnik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BrojTelefona")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ime")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Prezime")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Korisnici");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Korisnik");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Models.Pregled", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DatumVreme")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dijagnoza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LekarID")
                        .HasColumnType("int");

                    b.Property<int?>("PacijentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LekarID");

                    b.HasIndex("PacijentID");

                    b.ToTable("Pregledi");
                });

            modelBuilder.Entity("Models.Recenzija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("ClanID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Kreator")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Ocena")
                        .HasColumnType("int");

                    b.Property<string>("Tekst")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ClanID");

                    b.ToTable("Recenzije");
                });

            modelBuilder.Entity("Models.Usluga", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CenaUsluge")
                        .HasColumnType("int");

                    b.Property<int?>("CenovnikID")
                        .HasColumnType("int");

                    b.Property<string>("OpisUsluge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VrstaUsluge")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("CenovnikID");

                    b.ToTable("Usluge");
                });

            modelBuilder.Entity("Models.ClanKlinike", b =>
                {
                    b.HasBaseType("Models.Korisnik");

                    b.Property<int>("BrojKancelarija")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Specijalizacija")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasDiscriminator().HasValue("ClanKlinike");
                });

            modelBuilder.Entity("Models.Direktor", b =>
                {
                    b.HasBaseType("Models.Korisnik");

                    b.HasDiscriminator().HasValue("Direktor");
                });

            modelBuilder.Entity("Models.Pacijent", b =>
                {
                    b.HasBaseType("Models.Korisnik");

                    b.HasDiscriminator().HasValue("Pacijent");
                });

            modelBuilder.Entity("Models.Formular", b =>
                {
                    b.HasOne("Models.ClanKlinike", "ClanKlinike")
                        .WithMany("Formulari")
                        .HasForeignKey("ClanKlinikeID");

                    b.HasOne("Models.Pacijent", "Pacijent")
                        .WithMany("Formulari")
                        .HasForeignKey("PacijentID");

                    b.Navigation("ClanKlinike");

                    b.Navigation("Pacijent");
                });

            modelBuilder.Entity("Models.Pregled", b =>
                {
                    b.HasOne("Models.ClanKlinike", "Lekar")
                        .WithMany("Pregledi")
                        .HasForeignKey("LekarID");

                    b.HasOne("Models.Pacijent", "Pacijent")
                        .WithMany("Pregledi")
                        .HasForeignKey("PacijentID");

                    b.Navigation("Lekar");

                    b.Navigation("Pacijent");
                });

            modelBuilder.Entity("Models.Recenzija", b =>
                {
                    b.HasOne("Models.ClanKlinike", "Clan")
                        .WithMany("Recenzije")
                        .HasForeignKey("ClanID");

                    b.Navigation("Clan");
                });

            modelBuilder.Entity("Models.Usluga", b =>
                {
                    b.HasOne("Models.Cenovnik", null)
                        .WithMany("Usluge")
                        .HasForeignKey("CenovnikID");
                });

            modelBuilder.Entity("Models.Cenovnik", b =>
                {
                    b.Navigation("Usluge");
                });

            modelBuilder.Entity("Models.ClanKlinike", b =>
                {
                    b.Navigation("Formulari");

                    b.Navigation("Pregledi");

                    b.Navigation("Recenzije");
                });

            modelBuilder.Entity("Models.Pacijent", b =>
                {
                    b.Navigation("Formulari");

                    b.Navigation("Pregledi");
                });
#pragma warning restore 612, 618
        }
    }
}

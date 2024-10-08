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
    [Migration("20230624145431_V22")]
    partial class V22
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Formular", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BrojTelefona")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DoktorID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Ime")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("PacijentID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("RecepcijaID")
                        .HasColumnType("int");

                    b.Property<bool>("Scheduled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("datumPregleda")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("DoktorID");

                    b.HasIndex("PacijentID");

                    b.HasIndex("RecepcijaID");

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
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

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

            modelBuilder.Entity("Models.Photo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ClanKlinikeId")
                        .HasColumnType("int");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ClanKlinikeId")
                        .IsUnique();

                    b.ToTable("Slike");
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

                    b.Property<int?>("DoktorID")
                        .HasColumnType("int");

                    b.Property<int?>("PacijentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DoktorID");

                    b.HasIndex("PacijentID");

                    b.ToTable("Pregledi");
                });

            modelBuilder.Entity("Models.Recepcija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Recepcije");
                });

            modelBuilder.Entity("Models.Usluga", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CenaUsluge")
                        .HasColumnType("int");

                    b.Property<string>("OpisUsluge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VrstaUsluge")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Usluge");
                });

            modelBuilder.Entity("Models.ClanKlinike", b =>
                {
                    b.HasBaseType("Models.Korisnik");

                    b.Property<int>("BrojKancelarije")
                        .HasColumnType("int");

                    b.Property<bool>("Direktor")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RadnoMestoID")
                        .HasColumnType("int");

                    b.Property<string>("Specijalizacija")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasIndex("RadnoMestoID");

                    b.HasDiscriminator().HasValue("ClanKlinike");
                });

            modelBuilder.Entity("Models.Pacijent", b =>
                {
                    b.HasBaseType("Models.Korisnik");

                    b.Property<string>("Alergije")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasMaxLength(13)
                        .HasColumnType("datetime2");

                    b.Property<string>("HronicneBolesti")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KucnaAdresa")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Pacijent");
                });

            modelBuilder.Entity("Models.Formular", b =>
                {
                    b.HasOne("Models.ClanKlinike", "Doktor")
                        .WithMany()
                        .HasForeignKey("DoktorID");

                    b.HasOne("Models.Pacijent", "Pacijent")
                        .WithMany()
                        .HasForeignKey("PacijentID");

                    b.HasOne("Models.Recepcija", "Recepcija")
                        .WithMany()
                        .HasForeignKey("RecepcijaID");

                    b.Navigation("Doktor");

                    b.Navigation("Pacijent");

                    b.Navigation("Recepcija");
                });

            modelBuilder.Entity("Models.Photo", b =>
                {
                    b.HasOne("Models.ClanKlinike", "ClanKlinike")
                        .WithOne("Slika")
                        .HasForeignKey("Models.Photo", "ClanKlinikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClanKlinike");
                });

            modelBuilder.Entity("Models.Pregled", b =>
                {
                    b.HasOne("Models.ClanKlinike", "Doktor")
                        .WithMany("Pregledi")
                        .HasForeignKey("DoktorID");

                    b.HasOne("Models.Pacijent", "Pacijent")
                        .WithMany()
                        .HasForeignKey("PacijentID");

                    b.Navigation("Doktor");

                    b.Navigation("Pacijent");
                });

            modelBuilder.Entity("Models.ClanKlinike", b =>
                {
                    b.HasOne("Models.Recepcija", "RadnoMesto")
                        .WithMany("Lekari")
                        .HasForeignKey("RadnoMestoID");

                    b.Navigation("RadnoMesto");
                });

            modelBuilder.Entity("Models.Recepcija", b =>
                {
                    b.Navigation("Lekari");
                });

            modelBuilder.Entity("Models.ClanKlinike", b =>
                {
                    b.Navigation("Pregledi");

                    b.Navigation("Slika");
                });
#pragma warning restore 612, 618
        }
    }
}

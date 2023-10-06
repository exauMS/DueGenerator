﻿// <auto-generated />
using DueWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DueWebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230813183039_FicheTable")]
    partial class FicheTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DueWebAPI.Models.AA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfesseurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfesseurId");

                    b.ToTable("AATable");
                });

            modelBuilder.Entity("DueWebAPI.Models.Capacite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompetenceId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompetenceId");

                    b.ToTable("CapaciteTable");
                });

            modelBuilder.Entity("DueWebAPI.Models.Competence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CompetenceTable");
                });

            modelBuilder.Entity("DueWebAPI.Models.Cursus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartementId")
                        .HasColumnType("int");

                    b.Property<string>("Implentation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartementId");

                    b.ToTable("CursusTable");
                });

            modelBuilder.Entity("DueWebAPI.Models.Departement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DepartementTable");
                });

            modelBuilder.Entity("DueWebAPI.Models.Fiche", b =>
                {
                    b.Property<int>("FicheId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FicheId"));

                    b.Property<string>("Acquis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bloc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CalculNote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Capacites")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Competences")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContenuSynthetique")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cursus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cycle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Departement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ects")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Implantation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LangueEnseignement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LangueEvaluation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MethodeApprentissage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NiveauCertification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumSecretariat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Orientation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quadrimestre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponsableUE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupportCours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitulaireAA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeEvaluation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UECorequis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UEPrerequis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VolHoraire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FicheId");

                    b.ToTable("FicheTable");
                });

            modelBuilder.Entity("DueWebAPI.Models.Professeur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProfesseurTable");
                });

            modelBuilder.Entity("DueWebAPI.Models.UE", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CursusId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CursusId");

                    b.ToTable("UETable");
                });

            modelBuilder.Entity("DueWebAPI.Models.AA", b =>
                {
                    b.HasOne("DueWebAPI.Models.Professeur", "Professeur")
                        .WithMany()
                        .HasForeignKey("ProfesseurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professeur");
                });

            modelBuilder.Entity("DueWebAPI.Models.Capacite", b =>
                {
                    b.HasOne("DueWebAPI.Models.Competence", "Competence")
                        .WithMany()
                        .HasForeignKey("CompetenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competence");
                });

            modelBuilder.Entity("DueWebAPI.Models.Cursus", b =>
                {
                    b.HasOne("DueWebAPI.Models.Departement", "Departement")
                        .WithMany()
                        .HasForeignKey("DepartementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departement");
                });

            modelBuilder.Entity("DueWebAPI.Models.UE", b =>
                {
                    b.HasOne("DueWebAPI.Models.Cursus", "Cursus")
                        .WithMany()
                        .HasForeignKey("CursusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cursus");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    [Migration("20240611165621_ChangeNames")]
    partial class ChangeNames
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entities.Favor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsArchieved")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModifiedDateUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte[]>("Stages")
                        .IsRequired()
                        .HasColumnType("smallint[]");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Favors");
                });

            modelBuilder.Entity("Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsArchieved")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModifiedDateUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<byte>("Stage")
                        .HasColumnType("smallint");

                    b.Property<string>("StageDescription")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Entities.ProjectPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FileUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsArchieved")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModifiedDateUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ServicesPhotos");
                });

            modelBuilder.Entity("Entities.ServiceTechnology", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<int>("TechnologyId")
                        .HasColumnType("integer");

                    b.HasKey("ProjectId", "TechnologyId");

                    b.HasIndex("TechnologyId");

                    b.ToTable("ServiceTechnologies");
                });

            modelBuilder.Entity("Entities.Technology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("FavorId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsArchieved")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModifiedDateUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FavorId");

                    b.ToTable("Technologies");
                });

            modelBuilder.Entity("Entities.ProjectPhoto", b =>
                {
                    b.HasOne("Entities.Project", "Project")
                        .WithMany("ProjectPhotos")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Entities.ServiceTechnology", b =>
                {
                    b.HasOne("Entities.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Technology", null)
                        .WithMany()
                        .HasForeignKey("TechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Technology", b =>
                {
                    b.HasOne("Entities.Favor", null)
                        .WithMany("Technologies")
                        .HasForeignKey("FavorId");
                });

            modelBuilder.Entity("Entities.Favor", b =>
                {
                    b.Navigation("Technologies");
                });

            modelBuilder.Entity("Entities.Project", b =>
                {
                    b.Navigation("ProjectPhotos");
                });
#pragma warning restore 612, 618
        }
    }
}
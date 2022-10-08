﻿// <auto-generated />
using System;
using Infrastructura.Cantext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructura.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221007235707_Location")]
    partial class Location
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc.1.22426.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entites.Chalange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("Chalanges");
                });

            modelBuilder.Entity("Domain.Entites.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChallangeId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("GroupsNick")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("NeededMember")
                        .HasColumnType("boolean");

                    b.Property<string>("TeamSlogan")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.HasKey("Id");

                    b.HasIndex("ChallangeId");

                    b.ToTable("Groupes");
                });

            modelBuilder.Entity("Domain.Entites.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Domain.Entites.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("LocationId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("Domain.Entites.Group", b =>
                {
                    b.HasOne("Domain.Entites.Chalange", "Challange")
                        .WithMany("Groups")
                        .HasForeignKey("ChallangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Challange");
                });

            modelBuilder.Entity("Domain.Entites.Participant", b =>
                {
                    b.HasOne("Domain.Entites.Group", "Group")
                        .WithMany("Participants")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entites.Location", "Location")
                        .WithMany("Participants")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Domain.Entites.Chalange", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("Domain.Entites.Group", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("Domain.Entites.Location", b =>
                {
                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
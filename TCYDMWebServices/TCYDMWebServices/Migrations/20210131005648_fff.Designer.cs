﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TCYDMWebServices.Data;

namespace TCYDMWebServices.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210131005648_fff")]
    partial class fff
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("TCYDMWebServices.Models.ContactUs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactUss");
                });

            modelBuilder.Entity("TCYDMWebServices.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("TCYDMWebServices.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("TCYDMWebServices.Models.Langluage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("LangluageName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ValueKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("TCYDMWebServices.Models.OnlineQuery", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ServiceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.HasIndex("UserId");

                    b.ToTable("OnlineQueries");
                });

            modelBuilder.Entity("TCYDMWebServices.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("TCYDMWebServices.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("TCYDMWebServices.Models.ServiceInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ServiceInfos");
                });

            modelBuilder.Entity("TCYDMWebServices.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BornYear")
                        .HasColumnType("datetime2");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int>("SexId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("TCNo")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Token")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("RegionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TCYDMWebServices.Models.WhatWeDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WhatWeDos");
                });

            modelBuilder.Entity("TCYDMWebServices.Models.WhoWeAre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WhoWeAres");
                });

            modelBuilder.Entity("TCYDMWebServices.Models.OnlineQuery", b =>
                {
                    b.HasOne("TCYDMWebServices.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TCYDMWebServices.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TCYDMWebServices.Models.User", b =>
                {
                    b.HasOne("TCYDMWebServices.Models.Country", "Countries")
                        .WithMany("Users")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TCYDMWebServices.Models.Region", "Regions")
                        .WithMany("Users")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Countries");

                    b.Navigation("Regions");
                });

            modelBuilder.Entity("TCYDMWebServices.Models.Country", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TCYDMWebServices.Models.Region", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmukToolsApp.Data;

namespace SmukToolsApp.Migrations.Tool
{
    [DbContext(typeof(ToolContext))]
    [Migration("20190904203202_ToolType")]
    partial class ToolType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmukToolsApp.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Title");

                    b.Property<int>("ToolId");

                    b.HasKey("Id");

                    b.HasIndex("ToolId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("SmukToolsApp.Models.Tool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.Property<bool>("isComplete");

                    b.HasKey("Id");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("SmukToolsApp.Models.ToolType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<int>("Price");

                    b.Property<int>("PriceDuration");

                    b.Property<bool>("RequiresApproval");

                    b.Property<string>("Titel");

                    b.HasKey("Id");

                    b.ToTable("ToolTypes");
                });

            modelBuilder.Entity("SmukToolsApp.Models.Booking", b =>
                {
                    b.HasOne("SmukToolsApp.Models.Tool", "Tool")
                        .WithMany()
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
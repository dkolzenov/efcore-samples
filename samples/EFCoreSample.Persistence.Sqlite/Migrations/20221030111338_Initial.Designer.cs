﻿// <auto-generated />
using EFCoreSample.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreSample.Persistence.Sqlite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221030111338_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("EFCoreSample.Domain.Entities.Sample", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Samples");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "SampleDescription_1",
                            Title = "SampleTitle_1"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "SampleDescription_2",
                            Title = "SampleTitle_2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

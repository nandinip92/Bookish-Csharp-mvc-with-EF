﻿// <auto-generated />
using System;
using Bookish;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bookish.Migrations
{
    [DbContext(typeof(Library))]
    [Migration("20240301132131_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bookish.Models.Data.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Emily",
                            Title = "My special book"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Paola",
                            Title = "I am a legend"
                        });
                });

            modelBuilder.Entity("Bookish.Models.Data.Copy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<int>("Condition")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Copies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            Condition = 0
                        },
                        new
                        {
                            Id = 2,
                            BookId = 1,
                            Condition = 1
                        },
                        new
                        {
                            Id = 3,
                            BookId = 2,
                            Condition = 2
                        });
                });

            modelBuilder.Entity("Bookish.Models.Data.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CopyId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("DateBorrowed")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateDueBack")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DateReturned")
                        .HasColumnType("date");

                    b.Property<int>("MemberId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CopyId");

                    b.HasIndex("MemberId");

                    b.ToTable("Loans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CopyId = 1,
                            DateBorrowed = new DateOnly(2024, 2, 10),
                            DateDueBack = new DateOnly(2024, 2, 24),
                            DateReturned = new DateOnly(2024, 2, 22),
                            MemberId = 1
                        },
                        new
                        {
                            Id = 2,
                            CopyId = 3,
                            DateBorrowed = new DateOnly(2024, 2, 25),
                            DateDueBack = new DateOnly(2024, 3, 10),
                            MemberId = 1
                        },
                        new
                        {
                            Id = 3,
                            CopyId = 1,
                            DateBorrowed = new DateOnly(2024, 2, 26),
                            DateDueBack = new DateOnly(2024, 3, 11),
                            MemberId = 2
                        });
                });

            modelBuilder.Entity("Bookish.Models.Data.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Anastasia"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dani"
                        });
                });

            modelBuilder.Entity("Bookish.Models.Data.Copy", b =>
                {
                    b.HasOne("Bookish.Models.Data.Book", "Book")
                        .WithMany("Copies")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Bookish.Models.Data.Loan", b =>
                {
                    b.HasOne("Bookish.Models.Data.Copy", "Copy")
                        .WithMany("LoanHistory")
                        .HasForeignKey("CopyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookish.Models.Data.Member", "Member")
                        .WithMany("LoanHistory")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Copy");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Bookish.Models.Data.Book", b =>
                {
                    b.Navigation("Copies");
                });

            modelBuilder.Entity("Bookish.Models.Data.Copy", b =>
                {
                    b.Navigation("LoanHistory");
                });

            modelBuilder.Entity("Bookish.Models.Data.Member", b =>
                {
                    b.Navigation("LoanHistory");
                });
#pragma warning restore 612, 618
        }
    }
}

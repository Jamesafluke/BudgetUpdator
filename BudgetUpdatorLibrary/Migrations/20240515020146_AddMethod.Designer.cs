﻿// <auto-generated />
using System;
using BudgetUpdatorLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BudgetUpdatorLibrary.Migrations
{
    [DbContext(typeof(BudgetDbContext))]
    [Migration("20240515020146_AddMethod")]
    partial class AddMethod
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("BudgetUpdatorAppLibrary.BudgetItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int?>("BudgetItemId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ExportedToBudget")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Item")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ManuallyAdded")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Method")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BudgetItemId");

                    b.ToTable("BudgetItems");
                });

            modelBuilder.Entity("BudgetUpdatorAppLibrary.BudgetItem", b =>
                {
                    b.HasOne("BudgetUpdatorAppLibrary.BudgetItem", null)
                        .WithMany("SplitBudgetItems")
                        .HasForeignKey("BudgetItemId");
                });

            modelBuilder.Entity("BudgetUpdatorAppLibrary.BudgetItem", b =>
                {
                    b.Navigation("SplitBudgetItems");
                });
#pragma warning restore 612, 618
        }
    }
}

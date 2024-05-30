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
    [Migration("20240528025825_removeUnusedFieldsFromBudgetItems")]
    partial class removeUnusedFieldsFromBudgetItems
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("BudgetUpdatorAppLibrary.BudgetItem", b =>
                {
                    b.Property<int?>("Id")
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

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Item")
                        .HasColumnType("TEXT");

                    b.Property<string>("Method")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BudgetItemId");

                    b.ToTable("BudgetItems");
                });

            modelBuilder.Entity("BudgetUpdatorLibrary.SettingsConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DeleteCsvsAfterUpdating")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SelectPreviousMonth")
                        .HasColumnType("INTEGER");

                    b.Property<double>("TaxAmount")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Settings");
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

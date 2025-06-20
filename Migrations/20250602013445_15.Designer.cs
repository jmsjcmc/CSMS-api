﻿// <auto-generated />
using System;
using Csms_api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Csms_api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250602013445_15")]
    partial class _15
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Csms_api.Models.BusinessUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BusinessUnit_location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Business_unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("BusinessUnits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BusinessUnit_location = "Sitio Sto.Nino, Brgy.Binugao, Toril, Davao City",
                            Business_unit = "ABFI Central Office",
                            Removed = false
                        },
                        new
                        {
                            Id = 2,
                            BusinessUnit_location = "Binugao, Toril, Davao City",
                            Business_unit = "SubZero Ice and Cold Storage",
                            Removed = false
                        });
                });

            modelBuilder.Entity("Csms_api.Models.ColdStorage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Cs_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ColdStorages");
                });

            modelBuilder.Entity("Csms_api.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Company_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_on")
                        .HasColumnType("datetime2");

                    b.Property<int>("Creator_id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Removed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Updated_on")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Updater_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Csms_api.Models.Dispatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Approved_on")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created_on")
                        .HasColumnType("datetime2");

                    b.Property<int>("Creator_id")
                        .HasColumnType("int");

                    b.Property<bool>("Declined")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Declined_on")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dispatch_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Dispatched")
                        .HasColumnType("bit");

                    b.Property<int>("Document_id")
                        .HasColumnType("int");

                    b.Property<string>("Nmis_certificate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Overall_weight")
                        .HasColumnType("float");

                    b.Property<bool>("Pending")
                        .HasColumnType("bit");

                    b.Property<string>("Plate_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Product_id")
                        .HasColumnType("int");

                    b.Property<string>("Production_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit");

                    b.Property<int?>("Reviewer_id")
                        .HasColumnType("int");

                    b.Property<string>("Seal_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Temperature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time_end")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time_start")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Updated_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_on")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Document_id")
                        .IsUnique();

                    b.HasIndex("Product_id")
                        .IsUnique();

                    b.ToTable("Dispatches");
                });

            modelBuilder.Entity("Csms_api.Models.DispatchDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Dispatched")
                        .HasColumnType("bit");

                    b.Property<int>("Dispatching_id")
                        .HasColumnType("int");

                    b.Property<int>("Pallet_id")
                        .HasColumnType("int");

                    b.Property<int>("Position_id")
                        .HasColumnType("int");

                    b.Property<int>("Quantity_in_pallet")
                        .HasColumnType("int");

                    b.Property<int>("ReceivingDetail_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Dispatching_id");

                    b.HasIndex("Pallet_id");

                    b.HasIndex("Position_id");

                    b.HasIndex("ReceivingDetail_id")
                        .IsUnique();

                    b.ToTable("DispatchDetails");
                });

            modelBuilder.Entity("Csms_api.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Document_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Csms_api.Models.Pallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created_on")
                        .HasColumnType("datetime2");

                    b.Property<int>("Creator_id")
                        .HasColumnType("int");

                    b.Property<bool>("Occupied")
                        .HasColumnType("bit");

                    b.Property<int>("Pallet_no")
                        .HasColumnType("int");

                    b.Property<string>("Pallet_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position_id")
                        .HasColumnType("int");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit");

                    b.Property<int?>("Updated_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_on")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Position_id")
                        .IsUnique();

                    b.ToTable("Pallets");
                });

            modelBuilder.Entity("Csms_api.Models.PalletPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cs_id")
                        .HasColumnType("int");

                    b.Property<bool>("Hidden")
                        .HasColumnType("bit");

                    b.Property<string>("Pallet_column")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pallet_row")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Cs_id");

                    b.ToTable("PalletPositions");
                });

            modelBuilder.Entity("Csms_api.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("Company_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_on")
                        .HasColumnType("datetime2");

                    b.Property<int>("Creator_id")
                        .HasColumnType("int");

                    b.Property<string>("Delivery_unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product_packaging")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_on")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Updater_id")
                        .HasColumnType("int");

                    b.Property<string>("Variant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Company_id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Csms_api.Models.Receiving", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Arrival_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_on")
                        .HasColumnType("datetime2");

                    b.Property<int>("Creator_id")
                        .HasColumnType("int");

                    b.Property<string>("Cv_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date_declined")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date_received")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Declined")
                        .HasColumnType("bit");

                    b.Property<bool>("Dispatched")
                        .HasColumnType("bit");

                    b.Property<int>("Document_id")
                        .HasColumnType("int");

                    b.Property<string>("Expiration_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Overall_weight")
                        .HasColumnType("float");

                    b.Property<bool>("Pending")
                        .HasColumnType("bit");

                    b.Property<string>("Plate_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Product_id")
                        .HasColumnType("int");

                    b.Property<string>("Production_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Received")
                        .HasColumnType("bit");

                    b.Property<string>("Receiving_form")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit");

                    b.Property<int>("Reviewer_id")
                        .HasColumnType("int");

                    b.Property<string>("Temperature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unloading_end")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unloading_start")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_on")
                        .HasColumnType("datetime2");

                    b.Property<int>("Updater_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Document_id")
                        .IsUnique();

                    b.HasIndex("Product_id")
                        .IsUnique();

                    b.ToTable("Receivings");
                });

            modelBuilder.Entity("Csms_api.Models.ReceivingDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Dispatched")
                        .HasColumnType("bit");

                    b.Property<int>("Pallet_id")
                        .HasColumnType("int");

                    b.Property<int>("Position_id")
                        .HasColumnType("int");

                    b.Property<int>("Quantity_in_pallet")
                        .HasColumnType("int");

                    b.Property<bool>("Received")
                        .HasColumnType("bit");

                    b.Property<int>("Receiving_id")
                        .HasColumnType("int");

                    b.Property<double>("Total_weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Pallet_id");

                    b.HasIndex("Position_id");

                    b.HasIndex("Receiving_id");

                    b.ToTable("ReceivingDetails");
                });

            modelBuilder.Entity("Csms_api.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Removed")
                        .HasColumnType("bit");

                    b.Property<string>("Role_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Removed = false,
                            Role_name = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Removed = false,
                            Role_name = "User"
                        },
                        new
                        {
                            Id = 3,
                            Removed = false,
                            Role_name = "Approver"
                        });
                });

            modelBuilder.Entity("Csms_api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BusinessUnit_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_on")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("E_signature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_on")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BusinessUnit_id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BusinessUnit_id = 1,
                            Created_on = new DateTime(2025, 6, 2, 9, 34, 44, 391, DateTimeKind.Unspecified).AddTicks(3552),
                            Department = "Cisdevo",
                            First_name = "James Jecemeco",
                            Last_name = "Tabilog",
                            Password = "$2a$11$RALbultYp07dj6703XGnXeCSjGUzO2zkKHe.P/J53L0Khl31onGs2",
                            Position = "Software Developer",
                            Removed = false,
                            Role = "Administrator, User, Approver",
                            Username = "211072"
                        },
                        new
                        {
                            Id = 2,
                            BusinessUnit_id = 2,
                            Created_on = new DateTime(2025, 6, 2, 9, 34, 44, 549, DateTimeKind.Unspecified).AddTicks(7281),
                            Department = "Executive",
                            First_name = "Shiela",
                            Last_name = "Hernando",
                            Password = "$2a$11$./iGWzASCTVsCwzv/WjLbOldQYezl06FOfQG.zb2m2qUub9xdYhDK",
                            Position = "Senior Operations Manager",
                            Removed = false,
                            Role = "Approver",
                            Username = "211073"
                        });
                });

            modelBuilder.Entity("Csms_api.Models.Dispatch", b =>
                {
                    b.HasOne("Csms_api.Models.Document", "Document")
                        .WithOne("Dispatch")
                        .HasForeignKey("Csms_api.Models.Dispatch", "Document_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Csms_api.Models.Product", "Product")
                        .WithOne("Dispatch")
                        .HasForeignKey("Csms_api.Models.Dispatch", "Product_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Csms_api.Models.DispatchDetail", b =>
                {
                    b.HasOne("Csms_api.Models.Dispatch", "Dispatch")
                        .WithMany("Details")
                        .HasForeignKey("Dispatching_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Csms_api.Models.Pallet", "Pallet")
                        .WithMany("DispatchDetail")
                        .HasForeignKey("Pallet_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Csms_api.Models.PalletPosition", "Position")
                        .WithMany("DispatchDetail")
                        .HasForeignKey("Position_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Csms_api.Models.ReceivingDetail", "Receiving_detail")
                        .WithOne("Dispatch_detail")
                        .HasForeignKey("Csms_api.Models.DispatchDetail", "ReceivingDetail_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Dispatch");

                    b.Navigation("Pallet");

                    b.Navigation("Position");

                    b.Navigation("Receiving_detail");
                });

            modelBuilder.Entity("Csms_api.Models.Pallet", b =>
                {
                    b.HasOne("Csms_api.Models.PalletPosition", "Position")
                        .WithOne("Pallet")
                        .HasForeignKey("Csms_api.Models.Pallet", "Position_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("Csms_api.Models.PalletPosition", b =>
                {
                    b.HasOne("Csms_api.Models.ColdStorage", "ColdStorage")
                        .WithMany("PalletPosition")
                        .HasForeignKey("Cs_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ColdStorage");
                });

            modelBuilder.Entity("Csms_api.Models.Product", b =>
                {
                    b.HasOne("Csms_api.Models.Company", "Company")
                        .WithMany("Product")
                        .HasForeignKey("Company_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Csms_api.Models.Receiving", b =>
                {
                    b.HasOne("Csms_api.Models.Document", "Document")
                        .WithOne("Receiving")
                        .HasForeignKey("Csms_api.Models.Receiving", "Document_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Csms_api.Models.Product", "Product")
                        .WithOne("Receiving")
                        .HasForeignKey("Csms_api.Models.Receiving", "Product_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Csms_api.Models.ReceivingDetail", b =>
                {
                    b.HasOne("Csms_api.Models.Pallet", "Pallet")
                        .WithMany("ReceivingDetail")
                        .HasForeignKey("Pallet_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Csms_api.Models.PalletPosition", "Pallet_position")
                        .WithMany("ReceivingDetails")
                        .HasForeignKey("Position_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Csms_api.Models.Receiving", "Receiving")
                        .WithMany("Receiving_detail")
                        .HasForeignKey("Receiving_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pallet");

                    b.Navigation("Pallet_position");

                    b.Navigation("Receiving");
                });

            modelBuilder.Entity("Csms_api.Models.User", b =>
                {
                    b.HasOne("Csms_api.Models.BusinessUnit", "BusinessUnit")
                        .WithMany("User")
                        .HasForeignKey("BusinessUnit_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BusinessUnit");
                });

            modelBuilder.Entity("Csms_api.Models.BusinessUnit", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("Csms_api.Models.ColdStorage", b =>
                {
                    b.Navigation("PalletPosition");
                });

            modelBuilder.Entity("Csms_api.Models.Company", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("Csms_api.Models.Dispatch", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("Csms_api.Models.Document", b =>
                {
                    b.Navigation("Dispatch")
                        .IsRequired();

                    b.Navigation("Receiving")
                        .IsRequired();
                });

            modelBuilder.Entity("Csms_api.Models.Pallet", b =>
                {
                    b.Navigation("DispatchDetail");

                    b.Navigation("ReceivingDetail");
                });

            modelBuilder.Entity("Csms_api.Models.PalletPosition", b =>
                {
                    b.Navigation("DispatchDetail");

                    b.Navigation("Pallet")
                        .IsRequired();

                    b.Navigation("ReceivingDetails");
                });

            modelBuilder.Entity("Csms_api.Models.Product", b =>
                {
                    b.Navigation("Dispatch")
                        .IsRequired();

                    b.Navigation("Receiving")
                        .IsRequired();
                });

            modelBuilder.Entity("Csms_api.Models.Receiving", b =>
                {
                    b.Navigation("Receiving_detail");
                });

            modelBuilder.Entity("Csms_api.Models.ReceivingDetail", b =>
                {
                    b.Navigation("Dispatch_detail")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

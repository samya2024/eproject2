﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eproject2.Data;

#nullable disable

namespace eproject2.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20250218203527_rep")]
    partial class rep
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eproject2.Models.CategoryModel", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("eproject2.Models.Configuration", b =>
                {
                    b.Property<int>("ConfigID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConfigID"));

                    b.Property<string>("ConfigName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ConfigValue")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ConfigID");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("eproject2.Models.ContactSubmission", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("SubmittedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ContactID");

                    b.ToTable("ContactSubmissions");
                });

            modelBuilder.Entity("eproject2.Models.Listing", b =>
                {
                    b.Property<int>("ListingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ListingID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ListingID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("LocationID");

                    b.HasIndex("UserID");

                    b.ToTable("Listings");
                });

            modelBuilder.Entity("eproject2.Models.ListingImage", b =>
                {
                    b.Property<int>("ImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageID"));

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ListingID")
                        .HasColumnType("int");

                    b.HasKey("ImageID");

                    b.HasIndex("ListingID");

                    b.ToTable("ListingImages");
                });

            modelBuilder.Entity("eproject2.Models.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationID"));

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("LocationID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("eproject2.Models.Payment", b =>
                {
                    b.Property<int>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentID"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("PaymentID");

                    b.HasIndex("UserID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("eproject2.Models.Report", b =>
                {
                    b.Property<int>("ReportID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportID"));

                    b.Property<int>("ActiveSubscriptions")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReportDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalListings")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPayments")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TotalUsers")
                        .HasColumnType("int");

                    b.HasKey("ReportID");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("eproject2.Models.SubscriptionPackage", b =>
                {
                    b.Property<int>("PackageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PackageID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DurationDays")
                        .HasColumnType("int");

                    b.Property<int>("MaxListings")
                        .HasColumnType("int");

                    b.Property<string>("PackageName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PackageID");

                    b.ToTable("SubscriptionPackages");
                });

            modelBuilder.Entity("eproject2.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("eproject2.Models.UserSubscriptionModel", b =>
                {
                    b.Property<int>("SubscriptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionID"));

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PackageID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("SubscriptionID");

                    b.HasIndex("PackageID");

                    b.HasIndex("UserID");

                    b.ToTable("UserSubscriptions");
                });

            modelBuilder.Entity("eproject2.Models.Users", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubscriptionID")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("eproject2.Models.Listing", b =>
                {
                    b.HasOne("eproject2.Models.CategoryModel", "Category")
                        .WithMany("Listings")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eproject2.Models.Location", "Location")
                        .WithMany("Listings")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eproject2.Models.Users", "User")
                        .WithMany("Listings")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Location");

                    b.Navigation("User");
                });

            modelBuilder.Entity("eproject2.Models.ListingImage", b =>
                {
                    b.HasOne("eproject2.Models.Listing", "Listing")
                        .WithMany("ListingImagesPath")
                        .HasForeignKey("ListingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Listing");
                });

            modelBuilder.Entity("eproject2.Models.Payment", b =>
                {
                    b.HasOne("eproject2.Models.Users", "User")
                        .WithMany("Payments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("eproject2.Models.UserSubscriptionModel", b =>
                {
                    b.HasOne("eproject2.Models.SubscriptionPackage", "Package")
                        .WithMany("UserSubscriptions")
                        .HasForeignKey("PackageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eproject2.Models.Users", "User")
                        .WithMany("UserSubscriptions")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");

                    b.Navigation("User");
                });

            modelBuilder.Entity("eproject2.Models.CategoryModel", b =>
                {
                    b.Navigation("Listings");
                });

            modelBuilder.Entity("eproject2.Models.Listing", b =>
                {
                    b.Navigation("ListingImagesPath");
                });

            modelBuilder.Entity("eproject2.Models.Location", b =>
                {
                    b.Navigation("Listings");
                });

            modelBuilder.Entity("eproject2.Models.SubscriptionPackage", b =>
                {
                    b.Navigation("UserSubscriptions");
                });

            modelBuilder.Entity("eproject2.Models.Users", b =>
                {
                    b.Navigation("Listings");

                    b.Navigation("Payments");

                    b.Navigation("UserSubscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}

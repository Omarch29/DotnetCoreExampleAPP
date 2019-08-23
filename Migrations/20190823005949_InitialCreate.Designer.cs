﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Solstice.API.DATA;

namespace Solstice.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190823005949_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Solstice.API.models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("Company");

                    b.Property<string>("Email");

                    b.Property<string>("ProfileImage");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Solstice.API.models.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContactId");

                    b.Property<bool>("IsPersonal");

                    b.Property<string>("Number");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("Solstice.API.models.Contact", b =>
                {
                    b.OwnsOne("Solstice.API.models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("ContactId");

                            b1.Property<string>("City")
                                .HasColumnName("City");

                            b1.Property<int>("Number")
                                .HasColumnName("AddressNumber");

                            b1.Property<string>("State")
                                .HasColumnName("State");

                            b1.Property<string>("Street")
                                .HasColumnName("Address");

                            b1.Property<int>("ZipCode")
                                .HasColumnName("Zip");

                            b1.HasKey("ContactId");

                            b1.ToTable("Contacts");

                            b1.HasOne("Solstice.API.models.Contact")
                                .WithOne("Address")
                                .HasForeignKey("Solstice.API.models.Address", "ContactId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Solstice.API.models.Name", "Name", b1 =>
                        {
                            b1.Property<int>("ContactId");

                            b1.Property<string>("FirstName")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .HasColumnName("LastName");

                            b1.HasKey("ContactId");

                            b1.ToTable("Contacts");

                            b1.HasOne("Solstice.API.models.Contact")
                                .WithOne("Name")
                                .HasForeignKey("Solstice.API.models.Name", "ContactId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Solstice.API.models.PhoneNumber", b =>
                {
                    b.HasOne("Solstice.API.models.Contact", "Contact")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}

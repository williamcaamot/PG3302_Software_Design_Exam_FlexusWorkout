﻿// <auto-generated />
using System;
using FlexusWorkout.Services.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlexusWorkout.Migrations
{
    [DbContext(typeof(FlexusWorkoutDbContext))]
    partial class FlexusWorkoutDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FlexusWorkout.Model.Base.Exercise", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("DurationInMinutes")
                        .HasColumnType("int");

                    b.Property<string>("EquipmentRequired")
                        .HasColumnType("longtext");

                    b.Property<int?>("IntensityLevel")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("Repetitions")
                        .HasColumnType("int");

                    b.Property<int?>("Sets")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Exercise");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Exercise");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FlexusWorkout.Model.Concrete.User", b =>
                {
                    b.Property<int?>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FlexusWorkout.Model.Concrete.BalanceExercise", b =>
                {
                    b.HasBaseType("FlexusWorkout.Model.Base.Exercise");

                    b.HasDiscriminator().HasValue("Balance");
                });

            modelBuilder.Entity("FlexusWorkout.Model.Concrete.CardioExercise", b =>
                {
                    b.HasBaseType("FlexusWorkout.Model.Base.Exercise");

                    b.HasDiscriminator().HasValue("Cardio");
                });

            modelBuilder.Entity("FlexusWorkout.Model.Concrete.StrengthExercise", b =>
                {
                    b.HasBaseType("FlexusWorkout.Model.Base.Exercise");

                    b.HasDiscriminator().HasValue("Strength");
                });
#pragma warning restore 612, 618
        }
    }
}

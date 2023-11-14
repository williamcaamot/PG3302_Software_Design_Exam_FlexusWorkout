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

            modelBuilder.Entity("ExerciseWorkout", b =>
                {
                    b.Property<int>("ExercisesExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("ExercisesExerciseId", "WorkoutId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("ExerciseWorkout");
                });

            modelBuilder.Entity("FlexusWorkout.Models.Base.Exercise", b =>
                {
                    b.Property<int?>("ExerciseId")
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

                    b.HasKey("ExerciseId");

                    b.ToTable("Exercise");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Exercise");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FlexusWorkout.Models.Concrete.User", b =>
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

            modelBuilder.Entity("FlexusWorkout.Models.Concrete.Workout", b =>
                {
                    b.Property<int?>("WorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("WorkoutId");

                    b.HasIndex("UserId");

                    b.ToTable("Workout");
                });

            modelBuilder.Entity("FlexusWorkout.Models.Concrete.WorkoutDay", b =>
                {
                    b.Property<int?>("WorkoutDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("date")
                        .HasColumnType("date");

                    b.HasKey("WorkoutDayId");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("WorkoutDay");
                });

            modelBuilder.Entity("FlexusWorkout.Models.Concrete.BalanceExercise", b =>
                {
                    b.HasBaseType("FlexusWorkout.Models.Base.Exercise");

                    b.HasDiscriminator().HasValue("Balance");
                });

            modelBuilder.Entity("FlexusWorkout.Models.Concrete.CardioExercise", b =>
                {
                    b.HasBaseType("FlexusWorkout.Models.Base.Exercise");

                    b.HasDiscriminator().HasValue("Cardio");
                });

            modelBuilder.Entity("FlexusWorkout.Models.Concrete.StrengthExercise", b =>
                {
                    b.HasBaseType("FlexusWorkout.Models.Base.Exercise");

                    b.HasDiscriminator().HasValue("Strength");
                });

            modelBuilder.Entity("ExerciseWorkout", b =>
                {
                    b.HasOne("FlexusWorkout.Models.Base.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExercisesExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlexusWorkout.Models.Concrete.Workout", null)
                        .WithMany()
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlexusWorkout.Models.Concrete.Workout", b =>
                {
                    b.HasOne("FlexusWorkout.Models.Concrete.User", "User")
                        .WithMany("Workouts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlexusWorkout.Models.Concrete.WorkoutDay", b =>
                {
                    b.HasOne("FlexusWorkout.Models.Concrete.User", null)
                        .WithMany("WorkoutDays")
                        .HasForeignKey("UserId");

                    b.HasOne("FlexusWorkout.Models.Concrete.Workout", "Workout")
                        .WithMany()
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("FlexusWorkout.Models.Concrete.User", b =>
                {
                    b.Navigation("WorkoutDays");

                    b.Navigation("Workouts");
                });
#pragma warning restore 612, 618
        }
    }
}

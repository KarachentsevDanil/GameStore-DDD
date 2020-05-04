﻿// <auto-generated />
using System;
using GSP.Recommendation.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GSP.Recommendation.Data.Migrations.Migrations
{
    [DbContext(typeof(RecommendationDbContext))]
    [Migration("20200429084710_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GSP.Recommendation.Domain.Entities.CompletedOrder", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CompletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GSP.Recommendation.Domain.Entities.Game", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<float>("AverageRating")
                        .HasColumnType("real");

                    b.Property<long>("CountOfOrders")
                        .HasColumnType("bigint");

                    b.Property<long>("CountOfReviews")
                        .HasColumnType("bigint");

                    b.Property<long>("GenreId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AverageRating");

                    b.HasIndex("CountOfOrders");

                    b.HasIndex("CountOfReviews");

                    b.HasIndex("GenreId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GSP.Recommendation.Domain.Entities.CompletedOrder", b =>
                {
                    b.OwnsMany("GSP.Recommendation.Domain.Entities.OrderGame", "Games", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<long>("GameId")
                                .HasColumnType("bigint");

                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint");

                            b1.HasKey("Id");

                            b1.HasIndex("GameId");

                            b1.HasIndex("OrderId");

                            b1.ToTable("OrderGames");

                            b1.HasOne("GSP.Recommendation.Domain.Entities.Game", null)
                                .WithMany()
                                .HasForeignKey("GameId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using CryptoStashStats.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CryptoStashStats.Migrations
{
    [DbContext(typeof(MinerContext))]
    [Migration("20210708025536_AddPayoutTbl")]
    partial class AddPayoutTbl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CryptoStashStats.Models.Coin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Ticker")
                        .IsUnique();

                    b.ToTable("Coin");
                });

            modelBuilder.Entity("CryptoStashStats.Models.Hashrate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Average")
                        .HasColumnType("integer");

                    b.Property<int>("Current")
                        .HasColumnType("integer");

                    b.Property<int>("Reported")
                        .HasColumnType("integer");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("Hashrate");
                });

            modelBuilder.Entity("CryptoStashStats.Models.MiningPool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("MiningPool");
                });

            modelBuilder.Entity("CryptoStashStats.Models.Payout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<int>("ConfirmAttempts")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Confirmed")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int>("MiningPoolId")
                        .HasColumnType("integer");

                    b.Property<string>("TXHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WalletId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TXHash")
                        .IsUnique();

                    b.HasIndex("WalletId");

                    b.HasIndex("MiningPoolId", "WalletId")
                        .IsUnique();

                    b.ToTable("Payout");
                });

            modelBuilder.Entity("CryptoStashStats.Models.PoolBalance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Current")
                        .HasColumnType("double precision");

                    b.Property<int>("MiningPoolId")
                        .HasColumnType("integer");

                    b.Property<int>("WalletId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WalletId");

                    b.HasIndex("MiningPoolId", "WalletId")
                        .IsUnique();

                    b.ToTable("PoolBalance");
                });

            modelBuilder.Entity("CryptoStashStats.Models.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("CoinId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("Address")
                        .IsUnique();

                    b.HasIndex("CoinId")
                        .IsUnique();

                    b.ToTable("Wallet");
                });

            modelBuilder.Entity("CryptoStashStats.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("MiningPoolId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WalletId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MiningPoolId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("WalletId")
                        .IsUnique();

                    b.ToTable("Worker");
                });

            modelBuilder.Entity("CryptoStashStats.Models.Hashrate", b =>
                {
                    b.HasOne("CryptoStashStats.Models.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("CryptoStashStats.Models.Payout", b =>
                {
                    b.HasOne("CryptoStashStats.Models.MiningPool", "MiningPool")
                        .WithMany()
                        .HasForeignKey("MiningPoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoStashStats.Models.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MiningPool");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("CryptoStashStats.Models.PoolBalance", b =>
                {
                    b.HasOne("CryptoStashStats.Models.MiningPool", "MiningPool")
                        .WithMany("PoolBalances")
                        .HasForeignKey("MiningPoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoStashStats.Models.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MiningPool");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("CryptoStashStats.Models.Wallet", b =>
                {
                    b.HasOne("CryptoStashStats.Models.Coin", "Coin")
                        .WithMany()
                        .HasForeignKey("CoinId");

                    b.Navigation("Coin");
                });

            modelBuilder.Entity("CryptoStashStats.Models.Worker", b =>
                {
                    b.HasOne("CryptoStashStats.Models.MiningPool", "MiningPool")
                        .WithMany()
                        .HasForeignKey("MiningPoolId");

                    b.HasOne("CryptoStashStats.Models.Wallet", "Wallet")
                        .WithMany("Workers")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MiningPool");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("CryptoStashStats.Models.MiningPool", b =>
                {
                    b.Navigation("PoolBalances");
                });

            modelBuilder.Entity("CryptoStashStats.Models.Wallet", b =>
                {
                    b.Navigation("Workers");
                });
#pragma warning restore 612, 618
        }
    }
}

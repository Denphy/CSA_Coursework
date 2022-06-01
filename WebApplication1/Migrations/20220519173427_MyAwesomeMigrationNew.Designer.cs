﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(CSCoursContext))]
    [Migration("20220519173427_MyAwesomeMigrationNew")]
    partial class MyAwesomeMigrationNew
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Data.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("client_id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ClientId"));

                    b.Property<string>("ClientFullname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("client_fullname");

                    b.Property<string>("ClientPhone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("client_phone");

                    b.HasKey("ClientId")
                        .HasName("pk_clients");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Parcel", b =>
                {
                    b.Property<int>("ParcelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("parcel_id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ParcelId"));

                    b.Property<string>("ParcelAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("parcel_address");

                    b.Property<string>("ParcelRate")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("parcel_rate");

                    b.Property<string>("ParcelSize")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("parcel_size");

                    b.Property<int>("ParcelStatus")
                        .HasColumnType("integer")
                        .HasColumnName("parcel_status");

                    b.Property<int>("ParcelWeight")
                        .HasColumnType("integer")
                        .HasColumnName("parcel_weight");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("integer")
                        .HasColumnName("receiver_id");

                    b.Property<int>("ReceptionId")
                        .HasColumnType("integer")
                        .HasColumnName("reception_id");

                    b.Property<int>("SenderId")
                        .HasColumnType("integer")
                        .HasColumnName("sender_id");

                    b.HasKey("ParcelId")
                        .HasName("pk_parcels");

                    b.HasIndex("ReceiverId")
                        .HasDatabaseName("ix_parcels_receiver_id");

                    b.HasIndex("ReceptionId")
                        .HasDatabaseName("ix_parcels_reception_id");

                    b.HasIndex("SenderId")
                        .HasDatabaseName("ix_parcels_sender_id");

                    b.ToTable("parcels", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Receiver", b =>
                {
                    b.Property<int>("ReceiverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("receiver_id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReceiverId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer")
                        .HasColumnName("client_id");

                    b.HasKey("ReceiverId")
                        .HasName("pk_receivers");

                    b.HasIndex("ClientId")
                        .IsUnique()
                        .HasDatabaseName("ix_receivers_client_id");

                    b.ToTable("receivers", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Reception", b =>
                {
                    b.Property<int>("ReceptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("reception_id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReceptionId"));

                    b.Property<string>("ReceptionAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("reception_address");

                    b.Property<string>("ReceptionName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("reception_name");

                    b.Property<string>("ReceptionWeekdayEndTime")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("reception_weekday_end_time");

                    b.Property<string>("ReceptionWeekdayStartTime")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("reception_weekday_start_time");

                    b.Property<string>("ReceptionWeekendEndTime")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("reception_weekend_end_time");

                    b.Property<string>("ReceptionWeekendStartTime")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("reception_weekend_start_time");

                    b.HasKey("ReceptionId")
                        .HasName("pk_receptions");

                    b.ToTable("receptions", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Sender", b =>
                {
                    b.Property<int>("SenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("sender_id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SenderId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer")
                        .HasColumnName("client_id");

                    b.HasKey("SenderId")
                        .HasName("pk_senders");

                    b.HasIndex("ClientId")
                        .IsUnique()
                        .HasDatabaseName("ix_senders_client_id");

                    b.ToTable("senders", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Parcel", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Receiver", "Receivers")
                        .WithMany("Parcels")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_parcels_receivers_receiver_id");

                    b.HasOne("WebApplication1.Data.Models.Reception", "Receptions")
                        .WithMany("Parcels")
                        .HasForeignKey("ReceptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_parcels_receptions_reception_id");

                    b.HasOne("WebApplication1.Data.Models.Sender", "Senders")
                        .WithMany("Parcels")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_parcels_senders_sender_id");

                    b.Navigation("Receivers");

                    b.Navigation("Receptions");

                    b.Navigation("Senders");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Receiver", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Client", "Clients")
                        .WithOne("Receivers")
                        .HasForeignKey("WebApplication1.Data.Models.Receiver", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_receivers_clients_client_id");

                    b.Navigation("Clients");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Sender", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Client", "Clients")
                        .WithOne("Senders")
                        .HasForeignKey("WebApplication1.Data.Models.Sender", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_senders_clients_client_id");

                    b.Navigation("Clients");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Client", b =>
                {
                    b.Navigation("Receivers")
                        .IsRequired();

                    b.Navigation("Senders")
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Receiver", b =>
                {
                    b.Navigation("Parcels");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Reception", b =>
                {
                    b.Navigation("Parcels");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Sender", b =>
                {
                    b.Navigation("Parcels");
                });
#pragma warning restore 612, 618
        }
    }
}
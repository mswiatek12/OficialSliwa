﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OficialSliwa.dbContext.ApplicationDbContext;

#nullable disable

namespace OficialSliwa.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ObecnoscSesji", b =>
                {
                    b.Property<int>("SesjaObecnoscId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("obecnosc_sesji_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SesjaObecnoscId"));

                    b.Property<int>("SesjaId")
                        .HasColumnType("integer")
                        .HasColumnName("sesja_id");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("SesjaObecnoscId");

                    b.HasIndex("SesjaId");

                    b.HasIndex("UserId");

                    b.ToTable("obecnosc_sesji", (string)null);
                });

            modelBuilder.Entity("OficialSliwa.dbContext.AktywneCzlonkostwaViewModel", b =>
                {
                    b.Property<int>("CzlonkostwoId")
                        .HasColumnType("integer")
                        .HasColumnName("czlonkostwo_id");

                    b.Property<string>("Imie")
                        .HasColumnType("text")
                        .HasColumnName("imie");

                    b.Property<DateTime>("KoniecData")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("koniec_data");

                    b.Property<DateTime>("StartData")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_data");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.ToTable((string)null);

                    b.ToView("aktywne_czlonkostwa", (string)null);
                });

            modelBuilder.Entity("OficialSliwa.dbContext.AktywneUrazyViewModel", b =>
                {
                    b.Property<string>("Imie")
                        .HasColumnType("text")
                        .HasColumnName("imie");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("text")
                        .HasColumnName("nazwisko");

                    b.Property<string>("Opis")
                        .HasColumnType("text")
                        .HasColumnName("opis");

                    b.Property<DateTime>("UrazData")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("uraz_data");

                    b.Property<int>("UrazId")
                        .HasColumnType("integer")
                        .HasColumnName("uraz_id");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.ToTable((string)null);

                    b.ToView("aktywne_urazy", (string)null);
                });

            modelBuilder.Entity("OficialSliwa.dbContext.AppUser.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<DateTime>("DataRejestracji")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_rejestracji");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Imie")
                        .HasColumnType("text")
                        .HasColumnName("imie");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("text")
                        .HasColumnName("nazwisko");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("OpuszczoneZajecia")
                        .HasColumnType("integer")
                        .HasColumnName("opuszczone_zajęcia");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int>("Rola")
                        .HasColumnType("integer")
                        .HasColumnName("rola");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("OficialSliwa.dbContext.Czlonkostwo", b =>
                {
                    b.Property<int>("CzlonkostwoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("czlonkostwo_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CzlonkostwoId"));

                    b.Property<DateTime>("KoniecData")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("koniec_data");

                    b.Property<DateTime>("StartData")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_data");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("CzlonkostwoId");

                    b.HasIndex("UserId");

                    b.ToTable("czlonkostwo", (string)null);
                });

            modelBuilder.Entity("OficialSliwa.dbContext.NajaktywniejsiZawodnicy", b =>
                {
                    b.Property<string>("Imie")
                        .HasColumnType("text")
                        .HasColumnName("imie");

                    b.Property<int?>("LiczbaObecnosci")
                        .HasColumnType("integer")
                        .HasColumnName("obecnosc_ilosc");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.ToTable((string)null);

                    b.ToView("najaktywniejsi_zawodnicy", (string)null);
                });

            modelBuilder.Entity("OficialSliwa.dbContext.NajlepsiZawodnicy", b =>
                {
                    b.Property<string>("Imie")
                        .HasColumnType("text")
                        .HasColumnName("imie");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("text")
                        .HasColumnName("nazwisko");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<int>("Walki")
                        .HasColumnType("integer")
                        .HasColumnName("walki");

                    b.Property<int>("Wygrane")
                        .HasColumnType("integer")
                        .HasColumnName("wygrane");

                    b.Property<float>("WygraneProcent")
                        .HasColumnType("real")
                        .HasColumnName("wygrane_procent");

                    b.ToTable((string)null);

                    b.ToView("user_wygrane_procent", (string)null);
                });

            modelBuilder.Entity("OficialSliwa.dbContext.Uraz", b =>
                {
                    b.Property<int>("UrazId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("uraz_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UrazId"));

                    b.Property<string>("Opis")
                        .HasColumnType("text")
                        .HasColumnName("opis");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("status");

                    b.Property<DateTime>("UrazData")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("uraz_data");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("UrazId");

                    b.HasIndex("UserId");

                    b.ToTable("urazy", (string)null);
                });

            modelBuilder.Entity("OficialSliwa.dbContext.WieleUrazow", b =>
                {
                    b.Property<string>("Imie")
                        .HasColumnType("text")
                        .HasColumnName("imie");

                    b.Property<int>("LiczbaUrazow")
                        .HasColumnType("integer")
                        .HasColumnName("liczba_urazow");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("text")
                        .HasColumnName("nazwisko");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.ToTable((string)null);

                    b.ToView("wiele_urazow", (string)null);
                });

            modelBuilder.Entity("OficialSliwa.dbContext.Zawodnicy", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Imie")
                        .HasColumnType("text")
                        .HasColumnName("imie");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("text")
                        .HasColumnName("nazwisko");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.ToTable((string)null);

                    b.ToView("zawodnicy", (string)null);
                });

            modelBuilder.Entity("Sesja", b =>
                {
                    b.Property<int>("SesjaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("sesja_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SesjaId"));

                    b.Property<DateTime>("SesjaData")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("sesja_data");

                    b.Property<string>("SesjaNazwa")
                        .HasColumnType("text")
                        .HasColumnName("sesja_nazwa");

                    b.Property<int>("StartGodzina")
                        .HasColumnType("integer")
                        .HasColumnName("start_godzina");

                    b.HasKey("SesjaId");

                    b.ToTable("sesje", (string)null);
                });

            modelBuilder.Entity("Statystyki", b =>
                {
                    b.Property<int>("StatystykiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("statystyki_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StatystykiId"));

                    b.Property<string>("Osiagniecia")
                        .HasColumnType("text");

                    b.Property<int>("Przegrane")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("osiągnięcia");

                    b.Property<int>("Walki")
                        .HasColumnType("integer")
                        .HasColumnName("walki");

                    b.Property<int>("Wygrane")
                        .HasColumnType("integer");

                    b.HasKey("StatystykiId");

                    b.HasIndex("UserId");

                    b.ToTable("statystyki", (string)null);
                });

            modelBuilder.Entity("StatystykiUzytkownika", b =>
                {
                    b.Property<string>("Imie")
                        .HasColumnType("text")
                        .HasColumnName("imie");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("text")
                        .HasColumnName("nazwisko");

                    b.Property<string>("Osiągnięcia")
                        .HasColumnType("text")
                        .HasColumnName("osiągnięcia");

                    b.Property<int>("Przegrane")
                        .HasColumnType("integer")
                        .HasColumnName("przegrane");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<int>("Walki")
                        .HasColumnType("integer")
                        .HasColumnName("walki");

                    b.Property<int>("Wygrane")
                        .HasColumnType("integer")
                        .HasColumnName("wygrane");

                    b.ToTable((string)null);

                    b.ToView("statystyki_uzytkownika", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("OficialSliwa.dbContext.AppUser.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("OficialSliwa.dbContext.AppUser.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OficialSliwa.dbContext.AppUser.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("OficialSliwa.dbContext.AppUser.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ObecnoscSesji", b =>
                {
                    b.HasOne("Sesja", null)
                        .WithMany()
                        .HasForeignKey("SesjaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OficialSliwa.dbContext.AppUser.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OficialSliwa.dbContext.Czlonkostwo", b =>
                {
                    b.HasOne("OficialSliwa.dbContext.AppUser.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OficialSliwa.dbContext.Uraz", b =>
                {
                    b.HasOne("OficialSliwa.dbContext.AppUser.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Statystyki", b =>
                {
                    b.HasOne("OficialSliwa.dbContext.AppUser.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

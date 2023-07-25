﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(TwizDbContext))]
    partial class TwizDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<Guid?>("RegisterPaymentGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Token")
                        .HasColumnType("int")
                        .HasColumnName("token");

                    b.Property<DateTime?>("TokenExpiration")
                        .HasColumnType("datetime2")
                        .HasColumnName("token_expiration");

                    b.Property<bool?>("TokenIsUsed")
                        .HasColumnType("bit")
                        .HasColumnName("token_is_used");

                    b.HasKey("Guid");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RegisterPaymentGuid");

                    b.HasIndex("Token")
                        .IsUnique()
                        .HasFilter("[token] IS NOT NULL");

                    b.ToTable("pmdt_accounts");
                });

            modelBuilder.Entity("API.Models.AccountRole", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<Guid>("AccountGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("account_guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<Guid>("RoleGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("role_guid");

                    b.HasKey("Guid");

                    b.HasIndex("RoleGuid");

                    b.HasIndex("AccountGuid", "RoleGuid")
                        .IsUnique();

                    b.ToTable("pmtr_account_roles");
                });

            modelBuilder.Entity("API.Models.Bank", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Guid");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("pmdt_banks");
                });

            modelBuilder.Entity("API.Models.Company", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<Guid>("AccountGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("account_guid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("address");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("phone_number");

                    b.HasKey("Guid");

                    b.HasIndex("AccountGuid")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("pmdt_companies");
                });

            modelBuilder.Entity("API.Models.CompanyParticipant", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<Guid>("CompanyGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("company_guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<Guid>("EventGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("event_guid");

                    b.Property<bool>("IsJoin")
                        .HasColumnType("bit")
                        .HasColumnName("is_join");

                    b.Property<bool>("IsPresent")
                        .HasColumnType("bit")
                        .HasColumnName("is_present");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.HasKey("Guid");

                    b.HasIndex("CompanyGuid");

                    b.HasIndex("EventGuid");

                    b.ToTable("pmtr_company_participants");
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<Guid>("AccountGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("account_guid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birthdate");

                    b.Property<Guid>("CompanyGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("company_guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("full_name");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("gender");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("hiring_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Nik")
                        .IsRequired()
                        .HasColumnType("nchar(12)")
                        .HasColumnName("nik");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("phone_number");

                    b.HasKey("Guid");

                    b.HasIndex("AccountGuid")
                        .IsUnique();

                    b.HasIndex("CompanyGuid");

                    b.HasIndex("Nik")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("pmdt_employees");
                });

            modelBuilder.Entity("API.Models.EmployeeParticipant", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<Guid>("EmployeeGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("employee_guid");

                    b.Property<Guid>("EventGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("event_guid");

                    b.Property<bool>("IsJoin")
                        .HasColumnType("bit")
                        .HasColumnName("is_join");

                    b.Property<bool>("IsPresent")
                        .HasColumnType("bit")
                        .HasColumnName("is_present");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.HasKey("Guid");

                    b.HasIndex("EmployeeGuid");

                    b.HasIndex("EventGuid");

                    b.ToTable("pmtr_employee_participants");
                });

            modelBuilder.Entity("API.Models.Event", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("category");

                    b.Property<Guid?>("CompanyGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("end_date");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit")
                        .HasColumnName("is_paid");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit")
                        .HasColumnName("is_published");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("place");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.Property<int>("Quota")
                        .HasColumnType("int")
                        .HasColumnName("quota");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("start_date");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<string>("Thumbnail")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("thumbnail");

                    b.HasKey("Guid");

                    b.HasIndex("CompanyGuid");

                    b.ToTable("pmdt_events");
                });

            modelBuilder.Entity("API.Models.EventDoc", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("Documentation")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("documentation");

                    b.Property<Guid>("EventGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("event_guid");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.HasKey("Guid");

                    b.HasIndex("EventGuid")
                        .IsUnique();

                    b.ToTable("pmtr_event_docs");
                });

            modelBuilder.Entity("API.Models.EventPayment", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<Guid>("AccountGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("account_guid");

                    b.Property<Guid>("BankGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("bank_guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<Guid>("EventGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("event_guid");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit")
                        .HasColumnName("is_valid");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("PaymentImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("payment_image");

                    b.Property<int>("StatusPayment")
                        .HasColumnType("int")
                        .HasColumnName("status_payment");

                    b.Property<int>("VaNumber")
                        .HasColumnType("int")
                        .HasColumnName("va_number");

                    b.HasKey("Guid");

                    b.HasIndex("AccountGuid");

                    b.HasIndex("BankGuid");

                    b.HasIndex("EventGuid");

                    b.HasIndex("VaNumber")
                        .IsUnique();

                    b.ToTable("pmdt_event_payments");
                });

            modelBuilder.Entity("API.Models.RegisterPayment", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<Guid>("BankGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("bank_guid");

                    b.Property<Guid>("CompanyGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("company_guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit")
                        .HasColumnName("is_valid");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("PaymentImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("payment_image");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.Property<int>("StatusPayment")
                        .HasColumnType("int")
                        .HasColumnName("status_payment");

                    b.Property<int>("VaNumber")
                        .HasColumnType("int")
                        .HasColumnName("va_number");

                    b.HasKey("Guid");

                    b.HasIndex("BankGuid");

                    b.HasIndex("CompanyGuid")
                        .IsUnique();

                    b.HasIndex("VaNumber")
                        .IsUnique();

                    b.ToTable("pmdt_register_payments");
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Guid");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("pmdt_roles");
                });

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.HasOne("API.Models.RegisterPayment", "RegisterPayment")
                        .WithMany()
                        .HasForeignKey("RegisterPaymentGuid");

                    b.Navigation("RegisterPayment");
                });

            modelBuilder.Entity("API.Models.AccountRole", b =>
                {
                    b.HasOne("API.Models.Account", "Account")
                        .WithMany("AccountRoles")
                        .HasForeignKey("AccountGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Role", "Role")
                        .WithMany("AccountRoles")
                        .HasForeignKey("RoleGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("API.Models.Company", b =>
                {
                    b.HasOne("API.Models.Account", "Account")
                        .WithOne("Company")
                        .HasForeignKey("API.Models.Company", "AccountGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("API.Models.CompanyParticipant", b =>
                {
                    b.HasOne("API.Models.Company", "Company")
                        .WithMany("CompanyParticipants")
                        .HasForeignKey("CompanyGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Event", "Event")
                        .WithMany("CompanyParticipants")
                        .HasForeignKey("EventGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.HasOne("API.Models.Account", "Account")
                        .WithOne("Employee")
                        .HasForeignKey("API.Models.Employee", "AccountGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyGuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("API.Models.EmployeeParticipant", b =>
                {
                    b.HasOne("API.Models.Employee", "Employee")
                        .WithMany("EmployeeParticipants")
                        .HasForeignKey("EmployeeGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Event", "Event")
                        .WithMany("EmployeeParticipants")
                        .HasForeignKey("EventGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("API.Models.Event", b =>
                {
                    b.HasOne("API.Models.Company", "Company")
                        .WithMany("Events")
                        .HasForeignKey("CompanyGuid");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("API.Models.EventDoc", b =>
                {
                    b.HasOne("API.Models.Event", "Event")
                        .WithOne("EventDoc")
                        .HasForeignKey("API.Models.EventDoc", "EventGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("API.Models.EventPayment", b =>
                {
                    b.HasOne("API.Models.Account", "Account")
                        .WithMany("EventPayments")
                        .HasForeignKey("AccountGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Bank", "Bank")
                        .WithMany("EventPayments")
                        .HasForeignKey("BankGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Event", "Event")
                        .WithMany("EventPayment")
                        .HasForeignKey("EventGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Bank");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("API.Models.RegisterPayment", b =>
                {
                    b.HasOne("API.Models.Bank", "Bank")
                        .WithMany("RegisterPayments")
                        .HasForeignKey("BankGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Company", "Company")
                        .WithOne("RegisterPayment")
                        .HasForeignKey("API.Models.RegisterPayment", "CompanyGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.Navigation("AccountRoles");

                    b.Navigation("Company");

                    b.Navigation("Employee");

                    b.Navigation("EventPayments");
                });

            modelBuilder.Entity("API.Models.Bank", b =>
                {
                    b.Navigation("EventPayments");

                    b.Navigation("RegisterPayments");
                });

            modelBuilder.Entity("API.Models.Company", b =>
                {
                    b.Navigation("CompanyParticipants");

                    b.Navigation("Employees");

                    b.Navigation("Events");

                    b.Navigation("RegisterPayment");
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.Navigation("EmployeeParticipants");
                });

            modelBuilder.Entity("API.Models.Event", b =>
                {
                    b.Navigation("CompanyParticipants");

                    b.Navigation("EmployeeParticipants");

                    b.Navigation("EventDoc");

                    b.Navigation("EventPayment");
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Navigation("AccountRoles");
                });
#pragma warning restore 612, 618
        }
    }
}

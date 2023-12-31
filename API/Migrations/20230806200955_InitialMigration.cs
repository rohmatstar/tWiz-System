﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pmdt_accounts",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    token = table.Column<int>(type: "int", nullable: true),
                    token_is_used = table.Column<bool>(type: "bit", nullable: true),
                    token_expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pmdt_accounts", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "pmdt_banks",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pmdt_banks", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "pmdt_roles",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pmdt_roles", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "pmdt_companies",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    bank_account_number = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    account_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pmdt_companies", x => x.guid);
                    table.ForeignKey(
                        name: "FK_pmdt_companies_pmdt_accounts_account_guid",
                        column: x => x.account_guid,
                        principalTable: "pmdt_accounts",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pmdt_sys_admins",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    bank_account_number = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    account_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pmdt_sys_admins", x => x.guid);
                    table.ForeignKey(
                        name: "FK_pmdt_sys_admins_pmdt_accounts_account_guid",
                        column: x => x.account_guid,
                        principalTable: "pmdt_accounts",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pmtr_account_roles",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    account_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    role_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pmtr_account_roles", x => x.guid);
                    table.ForeignKey(
                        name: "FK_pmtr_account_roles_pmdt_accounts_account_guid",
                        column: x => x.account_guid,
                        principalTable: "pmdt_accounts",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pmtr_account_roles_pmdt_roles_role_guid",
                        column: x => x.role_guid,
                        principalTable: "pmdt_roles",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pmdt_employees",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nik = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    hiring_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    company_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    account_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pmdt_employees", x => x.guid);
                    table.ForeignKey(
                        name: "FK_pmdt_employees_pmdt_accounts_account_guid",
                        column: x => x.account_guid,
                        principalTable: "pmdt_accounts",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pmdt_employees_pmdt_companies_company_guid",
                        column: x => x.company_guid,
                        principalTable: "pmdt_companies",
                        principalColumn: "guid");
                });

            migrationBuilder.CreateTable(
                name: "pmdt_events",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    is_published = table.Column<bool>(type: "bit", nullable: false),
                    is_paid = table.Column<bool>(type: "bit", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    category = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quota = table.Column<int>(type: "int", nullable: false),
                    used_quota = table.Column<int>(type: "int", nullable: false),
                    place = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pmdt_events", x => x.guid);
                    table.ForeignKey(
                        name: "FK_pmdt_events_pmdt_companies_created_by",
                        column: x => x.created_by,
                        principalTable: "pmdt_companies",
                        principalColumn: "guid");
                });

            migrationBuilder.CreateTable(
                name: "pmdt_register_payments",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    company_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    va_number = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    payment_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_valid = table.Column<bool>(type: "bit", nullable: false),
                    bank_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status_payment = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pmdt_register_payments", x => x.guid);
                    table.ForeignKey(
                        name: "FK_pmdt_register_payments_pmdt_banks_bank_guid",
                        column: x => x.bank_guid,
                        principalTable: "pmdt_banks",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pmdt_register_payments_pmdt_companies_company_guid",
                        column: x => x.company_guid,
                        principalTable: "pmdt_companies",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pmdt_event_payments",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    account_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    event_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    va_number = table.Column<int>(type: "int", nullable: false),
                    payment_image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_valid = table.Column<bool>(type: "bit", nullable: false),
                    bank_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status_payment = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pmdt_event_payments", x => x.guid);
                    table.ForeignKey(
                        name: "FK_pmdt_event_payments_pmdt_accounts_account_guid",
                        column: x => x.account_guid,
                        principalTable: "pmdt_accounts",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pmdt_event_payments_pmdt_banks_bank_guid",
                        column: x => x.bank_guid,
                        principalTable: "pmdt_banks",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pmdt_event_payments_pmdt_events_event_guid",
                        column: x => x.event_guid,
                        principalTable: "pmdt_events",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pmtr_company_participants",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    event_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    company_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    is_present = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pmtr_company_participants", x => x.guid);
                    table.ForeignKey(
                        name: "FK_pmtr_company_participants_pmdt_companies_company_guid",
                        column: x => x.company_guid,
                        principalTable: "pmdt_companies",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pmtr_company_participants_pmdt_events_event_guid",
                        column: x => x.event_guid,
                        principalTable: "pmdt_events",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pmtr_employee_participants",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    event_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employee_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    is_present = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pmtr_employee_participants", x => x.guid);
                    table.ForeignKey(
                        name: "FK_pmtr_employee_participants_pmdt_employees_employee_guid",
                        column: x => x.employee_guid,
                        principalTable: "pmdt_employees",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pmtr_employee_participants_pmdt_events_event_guid",
                        column: x => x.event_guid,
                        principalTable: "pmdt_events",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pmtr_event_docs",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    event_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    documentation = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pmtr_event_docs", x => x.guid);
                    table.ForeignKey(
                        name: "FK_pmtr_event_docs_pmdt_events_event_guid",
                        column: x => x.event_guid,
                        principalTable: "pmdt_events",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_accounts_email",
                table: "pmdt_accounts",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_accounts_token",
                table: "pmdt_accounts",
                column: "token",
                unique: true,
                filter: "[token] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_banks_code",
                table: "pmdt_banks",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_banks_name",
                table: "pmdt_banks",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_companies_account_guid",
                table: "pmdt_companies",
                column: "account_guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_companies_phone_number",
                table: "pmdt_companies",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_employees_account_guid",
                table: "pmdt_employees",
                column: "account_guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_employees_company_guid",
                table: "pmdt_employees",
                column: "company_guid");

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_employees_nik",
                table: "pmdt_employees",
                column: "nik",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_employees_phone_number",
                table: "pmdt_employees",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_event_payments_account_guid",
                table: "pmdt_event_payments",
                column: "account_guid");

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_event_payments_bank_guid",
                table: "pmdt_event_payments",
                column: "bank_guid");

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_event_payments_event_guid",
                table: "pmdt_event_payments",
                column: "event_guid");

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_event_payments_va_number",
                table: "pmdt_event_payments",
                column: "va_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_events_created_by",
                table: "pmdt_events",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_register_payments_bank_guid",
                table: "pmdt_register_payments",
                column: "bank_guid");

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_register_payments_company_guid",
                table: "pmdt_register_payments",
                column: "company_guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_register_payments_va_number",
                table: "pmdt_register_payments",
                column: "va_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_roles_name",
                table: "pmdt_roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_sys_admins_account_guid",
                table: "pmdt_sys_admins",
                column: "account_guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pmdt_sys_admins_bank_account_number",
                table: "pmdt_sys_admins",
                column: "bank_account_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pmtr_account_roles_account_guid_role_guid",
                table: "pmtr_account_roles",
                columns: new[] { "account_guid", "role_guid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pmtr_account_roles_role_guid",
                table: "pmtr_account_roles",
                column: "role_guid");

            migrationBuilder.CreateIndex(
                name: "IX_pmtr_company_participants_company_guid",
                table: "pmtr_company_participants",
                column: "company_guid");

            migrationBuilder.CreateIndex(
                name: "IX_pmtr_company_participants_event_guid",
                table: "pmtr_company_participants",
                column: "event_guid");

            migrationBuilder.CreateIndex(
                name: "IX_pmtr_employee_participants_employee_guid",
                table: "pmtr_employee_participants",
                column: "employee_guid");

            migrationBuilder.CreateIndex(
                name: "IX_pmtr_employee_participants_event_guid",
                table: "pmtr_employee_participants",
                column: "event_guid");

            migrationBuilder.CreateIndex(
                name: "IX_pmtr_event_docs_event_guid",
                table: "pmtr_event_docs",
                column: "event_guid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pmdt_event_payments");

            migrationBuilder.DropTable(
                name: "pmdt_register_payments");

            migrationBuilder.DropTable(
                name: "pmdt_sys_admins");

            migrationBuilder.DropTable(
                name: "pmtr_account_roles");

            migrationBuilder.DropTable(
                name: "pmtr_company_participants");

            migrationBuilder.DropTable(
                name: "pmtr_employee_participants");

            migrationBuilder.DropTable(
                name: "pmtr_event_docs");

            migrationBuilder.DropTable(
                name: "pmdt_banks");

            migrationBuilder.DropTable(
                name: "pmdt_roles");

            migrationBuilder.DropTable(
                name: "pmdt_employees");

            migrationBuilder.DropTable(
                name: "pmdt_events");

            migrationBuilder.DropTable(
                name: "pmdt_companies");

            migrationBuilder.DropTable(
                name: "pmdt_accounts");
        }
    }
}

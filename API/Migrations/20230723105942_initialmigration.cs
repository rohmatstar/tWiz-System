using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PMDT_BANKS",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(20", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMDT_BANKS", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "PMDT_ROLES",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMDT_ROLES", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "PMDT_ACCOUNTS",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    token = table.Column<int>(type: "int", nullable: false),
                    token_is_used = table.Column<bool>(type: "bit", nullable: false),
                    token_expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    expired_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegisterPaymentGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMDT_ACCOUNTS", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "PMDT_COMPANIES",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    account_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMDT_COMPANIES", x => x.guid);
                    table.ForeignKey(
                        name: "FK_PMDT_COMPANIES_PMDT_ACCOUNTS_account_guid",
                        column: x => x.account_guid,
                        principalTable: "PMDT_ACCOUNTS",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PMTR_ACCOUNT_ROLES",
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
                    table.PrimaryKey("PK_PMTR_ACCOUNT_ROLES", x => x.guid);
                    table.ForeignKey(
                        name: "FK_PMTR_ACCOUNT_ROLES_PMDT_ACCOUNTS_account_guid",
                        column: x => x.account_guid,
                        principalTable: "PMDT_ACCOUNTS",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PMTR_ACCOUNT_ROLES_PMDT_ROLES_role_guid",
                        column: x => x.role_guid,
                        principalTable: "PMDT_ROLES",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PMDT_EMPLOYEES",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nik = table.Column<string>(type: "nchar(12)", nullable: false),
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
                    table.PrimaryKey("PK_PMDT_EMPLOYEES", x => x.guid);
                    table.ForeignKey(
                        name: "FK_PMDT_EMPLOYEES_PMDT_ACCOUNTS_account_guid",
                        column: x => x.account_guid,
                        principalTable: "PMDT_ACCOUNTS",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PMDT_EMPLOYEES_PMDT_COMPANIES_company_guid",
                        column: x => x.company_guid,
                        principalTable: "PMDT_COMPANIES",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PMDT_EVENTS",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    is_published = table.Column<bool>(type: "bit", nullable: false),
                    is_paid = table.Column<bool>(type: "bit", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    category = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quota = table.Column<int>(type: "int", nullable: false),
                    place = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMDT_EVENTS", x => x.guid);
                    table.ForeignKey(
                        name: "FK_PMDT_EVENTS_PMDT_COMPANIES_CompanyGuid",
                        column: x => x.CompanyGuid,
                        principalTable: "PMDT_COMPANIES",
                        principalColumn: "guid");
                });

            migrationBuilder.CreateTable(
                name: "PMDT_REGISTER_PAYMENTS",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    company_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    va_number = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    payment_image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_valid = table.Column<bool>(type: "bit", nullable: false),
                    bank_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMDT_REGISTER_PAYMENTS", x => x.guid);
                    table.ForeignKey(
                        name: "FK_PMDT_REGISTER_PAYMENTS_PMDT_BANKS_bank_guid",
                        column: x => x.bank_guid,
                        principalTable: "PMDT_BANKS",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PMDT_REGISTER_PAYMENTS_PMDT_COMPANIES_company_guid",
                        column: x => x.company_guid,
                        principalTable: "PMDT_COMPANIES",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PMDT_EVENT_PAYMENTS",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    account_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    event_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    va_number = table.Column<int>(type: "int", nullable: false),
                    payment_image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_valid = table.Column<bool>(type: "bit", nullable: false),
                    bank_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMDT_EVENT_PAYMENTS", x => x.guid);
                    table.ForeignKey(
                        name: "FK_PMDT_EVENT_PAYMENTS_PMDT_ACCOUNTS_account_guid",
                        column: x => x.account_guid,
                        principalTable: "PMDT_ACCOUNTS",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PMDT_EVENT_PAYMENTS_PMDT_BANKS_bank_guid",
                        column: x => x.bank_guid,
                        principalTable: "PMDT_BANKS",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PMDT_EVENT_PAYMENTS_PMDT_EVENTS_event_guid",
                        column: x => x.event_guid,
                        principalTable: "PMDT_EVENTS",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PMTR_COMPANY_PARTICIPANTS",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    event_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    company_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    is_join = table.Column<bool>(type: "bit", nullable: false),
                    is_present = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMTR_COMPANY_PARTICIPANTS", x => x.guid);
                    table.ForeignKey(
                        name: "FK_PMTR_COMPANY_PARTICIPANTS_PMDT_COMPANIES_company_guid",
                        column: x => x.company_guid,
                        principalTable: "PMDT_COMPANIES",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PMTR_COMPANY_PARTICIPANTS_PMDT_EVENTS_event_guid",
                        column: x => x.event_guid,
                        principalTable: "PMDT_EVENTS",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PMTR_EMPLOYEE_PARTICIPANTS",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    event_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employee_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    is_join = table.Column<bool>(type: "bit", nullable: false),
                    is_present = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMTR_EMPLOYEE_PARTICIPANTS", x => x.guid);
                    table.ForeignKey(
                        name: "FK_PMTR_EMPLOYEE_PARTICIPANTS_PMDT_EMPLOYEES_employee_guid",
                        column: x => x.employee_guid,
                        principalTable: "PMDT_EMPLOYEES",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PMTR_EMPLOYEE_PARTICIPANTS_PMDT_EVENTS_event_guid",
                        column: x => x.event_guid,
                        principalTable: "PMDT_EVENTS",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PMTR_EVENT_DOCS",
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
                    table.PrimaryKey("PK_PMTR_EVENT_DOCS", x => x.guid);
                    table.ForeignKey(
                        name: "FK_PMTR_EVENT_DOCS_PMDT_EVENTS_event_guid",
                        column: x => x.event_guid,
                        principalTable: "PMDT_EVENTS",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PMDT_ACCOUNTS_email_token",
                table: "PMDT_ACCOUNTS",
                columns: new[] { "email", "token" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PMDT_ACCOUNTS_RegisterPaymentGuid",
                table: "PMDT_ACCOUNTS",
                column: "RegisterPaymentGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PMDT_BANKS_code_name",
                table: "PMDT_BANKS",
                columns: new[] { "code", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PMDT_COMPANIES_account_guid",
                table: "PMDT_COMPANIES",
                column: "account_guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PMDT_EMPLOYEES_account_guid",
                table: "PMDT_EMPLOYEES",
                column: "account_guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PMDT_EMPLOYEES_company_guid",
                table: "PMDT_EMPLOYEES",
                column: "company_guid");

            migrationBuilder.CreateIndex(
                name: "IX_PMDT_EMPLOYEES_nik_account_guid_phone_number",
                table: "PMDT_EMPLOYEES",
                columns: new[] { "nik", "account_guid", "phone_number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PMDT_EVENT_PAYMENTS_account_guid",
                table: "PMDT_EVENT_PAYMENTS",
                column: "account_guid");

            migrationBuilder.CreateIndex(
                name: "IX_PMDT_EVENT_PAYMENTS_bank_guid",
                table: "PMDT_EVENT_PAYMENTS",
                column: "bank_guid");

            migrationBuilder.CreateIndex(
                name: "IX_PMDT_EVENT_PAYMENTS_event_guid",
                table: "PMDT_EVENT_PAYMENTS",
                column: "event_guid");

            migrationBuilder.CreateIndex(
                name: "IX_PMDT_EVENT_PAYMENTS_va_number",
                table: "PMDT_EVENT_PAYMENTS",
                column: "va_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PMDT_EVENTS_CompanyGuid",
                table: "PMDT_EVENTS",
                column: "CompanyGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PMDT_REGISTER_PAYMENTS_bank_guid",
                table: "PMDT_REGISTER_PAYMENTS",
                column: "bank_guid");

            migrationBuilder.CreateIndex(
                name: "IX_PMDT_REGISTER_PAYMENTS_company_guid",
                table: "PMDT_REGISTER_PAYMENTS",
                column: "company_guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PMDT_REGISTER_PAYMENTS_va_number_company_guid",
                table: "PMDT_REGISTER_PAYMENTS",
                columns: new[] { "va_number", "company_guid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PMDT_ROLES_name",
                table: "PMDT_ROLES",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PMTR_ACCOUNT_ROLES_account_guid_role_guid",
                table: "PMTR_ACCOUNT_ROLES",
                columns: new[] { "account_guid", "role_guid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PMTR_ACCOUNT_ROLES_role_guid",
                table: "PMTR_ACCOUNT_ROLES",
                column: "role_guid");

            migrationBuilder.CreateIndex(
                name: "IX_PMTR_COMPANY_PARTICIPANTS_company_guid",
                table: "PMTR_COMPANY_PARTICIPANTS",
                column: "company_guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PMTR_COMPANY_PARTICIPANTS_event_guid",
                table: "PMTR_COMPANY_PARTICIPANTS",
                column: "event_guid");

            migrationBuilder.CreateIndex(
                name: "IX_PMTR_EMPLOYEE_PARTICIPANTS_employee_guid",
                table: "PMTR_EMPLOYEE_PARTICIPANTS",
                column: "employee_guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PMTR_EMPLOYEE_PARTICIPANTS_event_guid",
                table: "PMTR_EMPLOYEE_PARTICIPANTS",
                column: "event_guid");

            migrationBuilder.CreateIndex(
                name: "IX_PMTR_EVENT_DOCS_event_guid",
                table: "PMTR_EVENT_DOCS",
                column: "event_guid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PMDT_ACCOUNTS_PMDT_REGISTER_PAYMENTS_RegisterPaymentGuid",
                table: "PMDT_ACCOUNTS",
                column: "RegisterPaymentGuid",
                principalTable: "PMDT_REGISTER_PAYMENTS",
                principalColumn: "guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PMDT_ACCOUNTS_PMDT_REGISTER_PAYMENTS_RegisterPaymentGuid",
                table: "PMDT_ACCOUNTS");

            migrationBuilder.DropTable(
                name: "PMDT_EVENT_PAYMENTS");

            migrationBuilder.DropTable(
                name: "PMTR_ACCOUNT_ROLES");

            migrationBuilder.DropTable(
                name: "PMTR_COMPANY_PARTICIPANTS");

            migrationBuilder.DropTable(
                name: "PMTR_EMPLOYEE_PARTICIPANTS");

            migrationBuilder.DropTable(
                name: "PMTR_EVENT_DOCS");

            migrationBuilder.DropTable(
                name: "PMDT_ROLES");

            migrationBuilder.DropTable(
                name: "PMDT_EMPLOYEES");

            migrationBuilder.DropTable(
                name: "PMDT_EVENTS");

            migrationBuilder.DropTable(
                name: "PMDT_REGISTER_PAYMENTS");

            migrationBuilder.DropTable(
                name: "PMDT_BANKS");

            migrationBuilder.DropTable(
                name: "PMDT_COMPANIES");

            migrationBuilder.DropTable(
                name: "PMDT_ACCOUNTS");
        }
    }
}

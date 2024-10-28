using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTextMaxLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e8433f7-e9fd-453a-b0c3-58ed654fb408");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Articles",
                type: "character varying(5000)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Articles",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationUserId",
                value: "6d05fd3e-153f-4366-94cc-d092ae16863f");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApplicationUserId",
                value: "6d05fd3e-153f-4366-94cc-d092ae16863f");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApplicationUserId",
                value: "6d05fd3e-153f-4366-94cc-d092ae16863f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d05fd3e-153f-4366-94cc-d092ae16863f", 0, "a07c4ab3-49c7-4471-abda-371f53c4550c", "ApplicationUser", "sample@user.com", false, false, null, "Sample User", "SAMPLE@USER.COM", "SAMPLE@USER.COM", "hashedpassword", "123456", false, "23dc8cd6-91e7-4ed5-a9a3-44ca2f011ed4", false, "sampleuser" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d05fd3e-153f-4366-94cc-d092ae16863f");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Articles",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(5000)",
                oldMaxLength: 5000);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Articles",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationUserId",
                value: "4e8433f7-e9fd-453a-b0c3-58ed654fb408");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApplicationUserId",
                value: "4e8433f7-e9fd-453a-b0c3-58ed654fb408");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApplicationUserId",
                value: "4e8433f7-e9fd-453a-b0c3-58ed654fb408");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4e8433f7-e9fd-453a-b0c3-58ed654fb408", 0, "6070fb04-aafa-45e9-9d10-8fb594e8958c", "ApplicationUser", "sample@user.com", false, false, null, "Sample User", "SAMPLE@USER.COM", "SAMPLE@USER.COM", "hashedpassword", "123456", false, "69c7bf3c-1784-4706-b550-e2f7fdb6c66e", false, "sampleuser" });
        }
    }
}

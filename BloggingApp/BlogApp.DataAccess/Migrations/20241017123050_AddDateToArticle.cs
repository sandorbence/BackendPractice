using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDateToArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a8bc4a9-5f31-48ed-8b57-88741df3cfd5");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Articles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "Date" },
                values: new object[] { "4e8433f7-e9fd-453a-b0c3-58ed654fb408", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApplicationUserId", "Date" },
                values: new object[] { "4e8433f7-e9fd-453a-b0c3-58ed654fb408", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApplicationUserId", "Date" },
                values: new object[] { "4e8433f7-e9fd-453a-b0c3-58ed654fb408", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4e8433f7-e9fd-453a-b0c3-58ed654fb408", 0, "6070fb04-aafa-45e9-9d10-8fb594e8958c", "ApplicationUser", "sample@user.com", false, false, null, "Sample User", "SAMPLE@USER.COM", "SAMPLE@USER.COM", "hashedpassword", "123456", false, "69c7bf3c-1784-4706-b550-e2f7fdb6c66e", false, "sampleuser" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e8433f7-e9fd-453a-b0c3-58ed654fb408");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationUserId",
                value: "0a8bc4a9-5f31-48ed-8b57-88741df3cfd5");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApplicationUserId",
                value: "0a8bc4a9-5f31-48ed-8b57-88741df3cfd5");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApplicationUserId",
                value: "0a8bc4a9-5f31-48ed-8b57-88741df3cfd5");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0a8bc4a9-5f31-48ed-8b57-88741df3cfd5", 0, "764d1ab7-07d1-4b84-b327-a72a2d7c042f", "ApplicationUser", "sample@user.com", false, false, null, "Sample User", "SAMPLE@USER.COM", "SAMPLE@USER.COM", "hashedpassword", "123456", false, "02cea0cc-3398-4619-8409-b37aba4dd235", false, "sampleuser" });
        }
    }
}

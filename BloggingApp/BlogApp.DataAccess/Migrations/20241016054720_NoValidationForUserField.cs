using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NoValidationForUserField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "169bbddf-2a4e-4977-a744-efd20ce1acf0");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a8bc4a9-5f31-48ed-8b57-88741df3cfd5");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationUserId",
                value: "169bbddf-2a4e-4977-a744-efd20ce1acf0");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApplicationUserId",
                value: "169bbddf-2a4e-4977-a744-efd20ce1acf0");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApplicationUserId",
                value: "169bbddf-2a4e-4977-a744-efd20ce1acf0");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "169bbddf-2a4e-4977-a744-efd20ce1acf0", 0, "874ac93d-e66e-4c0d-b180-f69cfad2895a", "ApplicationUser", "sample@user.com", false, false, null, "Sample User", "SAMPLE@USER.COM", "SAMPLE@USER.COM", "hashedpassword", "123456", false, "1a90667c-4912-4de3-b29c-44c711c65652", false, "sampleuser" });
        }
    }
}

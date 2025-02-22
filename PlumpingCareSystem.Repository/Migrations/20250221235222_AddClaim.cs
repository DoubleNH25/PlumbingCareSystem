using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlumpingCareSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddClaim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cd80fb7-0afc-4c63-b15e-4f67c8eafaf2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a790a698-8058-4fb6-bbbb-63123d01b4d4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "A790A698-8058-4FB6-BBBB-63123D01B4D4", "2A9459B8-FADB-4EE7-9424-F34A6AEB5BCD" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3CD80FB7-0AFC-4C63-B15E-4F67C8EAFAF2", "5D596359-CCD9-40DB-9442-74BEB060584A" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a9459b8-fadb-4ee7-9424-f34a6aeb5bcd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d596359-ccd9-40db-9442-74beb060584a");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserClaims",
                type: "nvarchar(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9b67832b-7091-48e8-aa0a-f1b3baeca418", "8d91b840-9475-4405-aa1d-142fc61c8a2d", "SuperAdmin", "SUPERADMIN" },
                    { "affedc34-9713-423a-880e-4a61ceefb7b1", "1c0af757-189f-4d1f-8e7c-ad262a06f377", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FileName", "FileType", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "070a9212-d4a9-44da-8479-4ec813b63621", 0, "5c0b4ef9-0884-45f4-b115-16282514bea4", "test.video.lesson@gmail.com", false, null, null, false, null, "TEST.VIDEO.LESSON@GMAIL.COM", "TESTADMIN", "AQAAAAIAAYagAAAAEJXcHP6El2NWAa26waYBbMi8lF5J6khlPP4MDr4scNMSI4yzAM50g2BeZAbsBEsbMQ==", null, false, "d18917e3-54c2-400f-9915-28c2933f1e92", false, "TestAdmin" },
                    { "6b0e483c-ebae-4ed3-827e-8ed27f7d9131", 0, "efe662b6-b323-4d8b-be07-b28f49525279", "test.video.lesson2@gmail.com", false, null, null, false, null, "TEST.VIDEO.LESSON2@GMAIL.COM", "TESTMEMBER", "AQAAAAIAAYagAAAAEOkF58Idf60o8hHxTsCfblPJ/Qztk3q2Rx6oVALUDaHhAUeCDJeEJYeclRMOtK172w==", null, false, "77eab9b0-9dfe-4bca-9c85-2500c5773395", false, "TestMember" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "Discriminator", "UserId" },
                values: new object[] { 1, "AdminObserverExpireDate", "02/03/2025", "AppUserClaim", "6b0e483c-ebae-4ed3-827e-8ed27f7d9131" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { "9b67832b-7091-48e8-aa0a-f1b3baeca418", "070a9212-d4a9-44da-8479-4ec813b63621", "AppUserRole" },
                    { "affedc34-9713-423a-880e-4a61ceefb7b1", "6b0e483c-ebae-4ed3-827e-8ed27f7d9131", "AppUserRole" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9b67832b-7091-48e8-aa0a-f1b3baeca418", "070a9212-d4a9-44da-8479-4ec813b63621" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "affedc34-9713-423a-880e-4a61ceefb7b1", "6b0e483c-ebae-4ed3-827e-8ed27f7d9131" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b67832b-7091-48e8-aa0a-f1b3baeca418");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "affedc34-9713-423a-880e-4a61ceefb7b1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "070a9212-d4a9-44da-8479-4ec813b63621");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b0e483c-ebae-4ed3-827e-8ed27f7d9131");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserClaims");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3cd80fb7-0afc-4c63-b15e-4f67c8eafaf2", "b87ed8b9-c97b-4ba0-b13f-499544e136ba", "Member", "MEMBER" },
                    { "a790a698-8058-4fb6-bbbb-63123d01b4d4", "c1638081-8687-43a7-a1df-9d654dbdab40", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { "A790A698-8058-4FB6-BBBB-63123D01B4D4", "2A9459B8-FADB-4EE7-9424-F34A6AEB5BCD", "AppUserRole" },
                    { "3CD80FB7-0AFC-4C63-B15E-4F67C8EAFAF2", "5D596359-CCD9-40DB-9442-74BEB060584A", "AppUserRole" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FileName", "FileType", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2a9459b8-fadb-4ee7-9424-f34a6aeb5bcd", 0, "620e7305-8455-4f06-93fa-86e35ef091aa", "test.video.lesson@gmail.com", false, null, null, false, null, "TEST.VIDEO.LESSON@GMAIL.COM", "TESTADMIN", "AQAAAAIAAYagAAAAECHbutkEICmpqAwJZr5hOSMW1pqbQ4aKNLHkh3bHCXQg7GWk/Qz7RQclmoNY27F6TA==", null, false, "e955d0b9-1b11-4620-819a-b7b3d3d191a0", false, "TestAdmin" },
                    { "5d596359-ccd9-40db-9442-74beb060584a", 0, "ca923d38-ba87-4029-81cb-88b4f8128de6", "test.video.lesson2@gmail.com", false, null, null, false, null, "TEST.VIDEO.LESSON2@GMAIL.COM", "TESTMEMBER", "AQAAAAIAAYagAAAAEMqu3+1BdLiqh3wUeHpMj/R5TVvByTEWSD0nn8qZJlqVqUIxZcfLh37abVxGY+kG2w==", null, false, "8d73be40-1947-4ba1-9936-252dd9cad69b", false, "TestMember" }
                });
        }
    }
}

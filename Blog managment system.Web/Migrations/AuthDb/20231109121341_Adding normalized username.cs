using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_managment_system.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class Addingnormalizedusername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0fc10fe8-0b04-43c6-90d4-a6611ecf5264",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14dce488-fec7-4120-ae15-014430138f13", "SUPERADMIN@BLOGMANSYS.COM", "SUPERADMIN@BLOGMANSYS.COM", "AQAAAAEAACcQAAAAEGHDY8VjMRURO9YN5AP93Cl3ASngqKgmCuSZpg7LdTfrzVG+EryBsI78js68HziXfA==", "d0e793e6-819f-4333-af58-b2ed68579000" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0fc10fe8-0b04-43c6-90d4-a6611ecf5264",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43eabc1a-5660-4a1b-9e76-099f4d08897a", null, null, "AQAAAAEAACcQAAAAEImCw8pn7U36qhbOE9/3hf36aXOv7L51FcbUkHVj0mPfZ6JdgaSvsx5XSDYdac+u2g==", "fc1f6c7c-bc1f-4d2a-876b-2bb9a8cdeaf4" });
        }
    }
}

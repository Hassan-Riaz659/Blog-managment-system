using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_managment_system.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingTagsNavigationPropertyUpdating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_BlogPosts_BlogPostId1",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_BlogPostId1",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "BlogPostId1",
                table: "Tags");

            migrationBuilder.AlterColumn<Guid>(
                name: "BlogPostId",
                table: "Tags",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_BlogPostId",
                table: "Tags",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_BlogPosts_BlogPostId",
                table: "Tags",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_BlogPosts_BlogPostId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_BlogPostId",
                table: "Tags");

            migrationBuilder.AlterColumn<string>(
                name: "BlogPostId",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "BlogPostId1",
                table: "Tags",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_BlogPostId1",
                table: "Tags",
                column: "BlogPostId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_BlogPosts_BlogPostId1",
                table: "Tags",
                column: "BlogPostId1",
                principalTable: "BlogPosts",
                principalColumn: "Id");
        }
    }
}

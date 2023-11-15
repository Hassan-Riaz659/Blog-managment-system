using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_managment_system.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddingTagsnavigationproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class VideoOnPlayList_tabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoOnPlayList_PlayLists_PlayListId",
                table: "VideoOnPlayList");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoOnPlayList_Videos_VideoId",
                table: "VideoOnPlayList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoOnPlayList",
                table: "VideoOnPlayList");

            migrationBuilder.RenameTable(
                name: "VideoOnPlayList",
                newName: "VideoOnPlayLists");

            migrationBuilder.RenameIndex(
                name: "IX_VideoOnPlayList_PlayListId",
                table: "VideoOnPlayLists",
                newName: "IX_VideoOnPlayLists_PlayListId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfCreate",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 31, 10, 27, 34, 991, DateTimeKind.Local).AddTicks(9718),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 30, 19, 34, 59, 461, DateTimeKind.Local).AddTicks(1048));

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoOnPlayLists",
                table: "VideoOnPlayLists",
                columns: new[] { "VideoId", "PlayListId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VideoOnPlayLists_PlayLists_PlayListId",
                table: "VideoOnPlayLists",
                column: "PlayListId",
                principalTable: "PlayLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoOnPlayLists_Videos_VideoId",
                table: "VideoOnPlayLists",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoOnPlayLists_PlayLists_PlayListId",
                table: "VideoOnPlayLists");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoOnPlayLists_Videos_VideoId",
                table: "VideoOnPlayLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoOnPlayLists",
                table: "VideoOnPlayLists");

            migrationBuilder.RenameTable(
                name: "VideoOnPlayLists",
                newName: "VideoOnPlayList");

            migrationBuilder.RenameIndex(
                name: "IX_VideoOnPlayLists_PlayListId",
                table: "VideoOnPlayList",
                newName: "IX_VideoOnPlayList_PlayListId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfCreate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 30, 19, 34, 59, 461, DateTimeKind.Local).AddTicks(1048),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 31, 10, 27, 34, 991, DateTimeKind.Local).AddTicks(9718));

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoOnPlayList",
                table: "VideoOnPlayList",
                columns: new[] { "VideoId", "PlayListId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VideoOnPlayList_PlayLists_PlayListId",
                table: "VideoOnPlayList",
                column: "PlayListId",
                principalTable: "PlayLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoOnPlayList_Videos_VideoId",
                table: "VideoOnPlayList",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

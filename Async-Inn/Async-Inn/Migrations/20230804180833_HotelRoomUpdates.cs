using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Async_Inn.Migrations
{
    /// <inheritdoc />
    public partial class HotelRoomUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_Rooms_RoomId",
                table: "HotelRooms");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "HotelRooms",
                newName: "RoomID");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "HotelRooms",
                newName: "HotelID");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRooms_RoomId",
                table: "HotelRooms",
                newName: "IX_HotelRooms_RoomID");

            migrationBuilder.AddColumn<bool>(
                name: "PetFriendly",
                table: "HotelRooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "HotelRooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "HotelID", "RoomNumber", "PetFriendly", "Rate", "RoomID" },
                values: new object[,]
                {
                    { 1, 101, false, 0m, 1 },
                    { 1, 102, false, 0m, 2 },
                    { 2, 201, false, 0m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_HotelID",
                table: "HotelRooms",
                column: "HotelID");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_Hotels_HotelID",
                table: "HotelRooms",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_Rooms_RoomID",
                table: "HotelRooms",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_Hotels_HotelID",
                table: "HotelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_Rooms_RoomID",
                table: "HotelRooms");

            migrationBuilder.DropIndex(
                name: "IX_HotelRooms_HotelID",
                table: "HotelRooms");

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelID", "RoomNumber" },
                keyValues: new object[] { 1, 101 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelID", "RoomNumber" },
                keyValues: new object[] { 1, 102 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelID", "RoomNumber" },
                keyValues: new object[] { 2, 201 });

            migrationBuilder.DropColumn(
                name: "PetFriendly",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "HotelRooms");

            migrationBuilder.RenameColumn(
                name: "RoomID",
                table: "HotelRooms",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "HotelID",
                table: "HotelRooms",
                newName: "HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRooms_RoomID",
                table: "HotelRooms",
                newName: "IX_HotelRooms_RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_Rooms_RoomId",
                table: "HotelRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoomReservation_HotelRooms_BookedRoomsID",
                table: "HotelRoomReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoomReservation_Reservations_ReservationsID",
                table: "HotelRoomReservation");

            migrationBuilder.DropColumn(
                name: "Meal",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Travelers",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "HotelRooms");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Reviews",
                newName: "IDReview");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Reservations",
                newName: "IDReservation");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Oferts",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Oferts",
                newName: "IDOfert");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Hotels",
                newName: "IDHotel");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "HotelRooms",
                newName: "IDHotelRoom");

            migrationBuilder.RenameColumn(
                name: "ReservationsID",
                table: "HotelRoomReservation",
                newName: "ReservationsIDReservation");

            migrationBuilder.RenameColumn(
                name: "BookedRoomsID",
                table: "HotelRoomReservation",
                newName: "BookedRoomsIDHotelRoom");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRoomReservation_ReservationsID",
                table: "HotelRoomReservation",
                newName: "IX_HotelRoomReservation_ReservationsIDReservation");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Customers",
                newName: "IDCustomer");

            migrationBuilder.AddColumn<int>(
                name: "Meal",
                table: "Oferts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TripType",
                table: "Oferts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    IDTag = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.IDTag);
                });

            migrationBuilder.CreateTable(
                name: "OfertTag",
                columns: table => new
                {
                    HotelsIDOfert = table.Column<long>(type: "bigint", nullable: false),
                    TagsIDTag = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertTag", x => new { x.HotelsIDOfert, x.TagsIDTag });
                    table.ForeignKey(
                        name: "FK_OfertTag_Oferts_HotelsIDOfert",
                        column: x => x.HotelsIDOfert,
                        principalTable: "Oferts",
                        principalColumn: "IDOfert",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfertTag_Tag_TagsIDTag",
                        column: x => x.TagsIDTag,
                        principalTable: "Tag",
                        principalColumn: "IDTag",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfertTag_TagsIDTag",
                table: "OfertTag",
                column: "TagsIDTag");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoomReservation_HotelRooms_BookedRoomsIDHotelRoom",
                table: "HotelRoomReservation",
                column: "BookedRoomsIDHotelRoom",
                principalTable: "HotelRooms",
                principalColumn: "IDHotelRoom",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoomReservation_Reservations_ReservationsIDReservation",
                table: "HotelRoomReservation",
                column: "ReservationsIDReservation",
                principalTable: "Reservations",
                principalColumn: "IDReservation",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoomReservation_HotelRooms_BookedRoomsIDHotelRoom",
                table: "HotelRoomReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoomReservation_Reservations_ReservationsIDReservation",
                table: "HotelRoomReservation");

            migrationBuilder.DropTable(
                name: "OfertTag");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropColumn(
                name: "Meal",
                table: "Oferts");

            migrationBuilder.DropColumn(
                name: "TripType",
                table: "Oferts");

            migrationBuilder.RenameColumn(
                name: "IDReview",
                table: "Reviews",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "IDReservation",
                table: "Reservations",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Oferts",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "IDOfert",
                table: "Oferts",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "IDHotel",
                table: "Hotels",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "IDHotelRoom",
                table: "HotelRooms",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ReservationsIDReservation",
                table: "HotelRoomReservation",
                newName: "ReservationsID");

            migrationBuilder.RenameColumn(
                name: "BookedRoomsIDHotelRoom",
                table: "HotelRoomReservation",
                newName: "BookedRoomsID");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRoomReservation_ReservationsIDReservation",
                table: "HotelRoomReservation",
                newName: "IX_HotelRoomReservation_ReservationsID");

            migrationBuilder.RenameColumn(
                name: "IDCustomer",
                table: "Customers",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "Meal",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Reservations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Travelers",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "HotelRooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoomReservation_HotelRooms_BookedRoomsID",
                table: "HotelRoomReservation",
                column: "BookedRoomsID",
                principalTable: "HotelRooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoomReservation_Reservations_ReservationsID",
                table: "HotelRoomReservation",
                column: "ReservationsID",
                principalTable: "Reservations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

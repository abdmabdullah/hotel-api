using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hotel_api.Migrations
{
    public partial class AddedRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Bookings",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "FacilityHotel",
                columns: table => new
                {
                    FacilitiesId = table.Column<int>(type: "integer", nullable: false),
                    HotelsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityHotel", x => new { x.FacilitiesId, x.HotelsId });
                    table.ForeignKey(
                        name: "FK_FacilityHotel_Facilities_FacilitiesId",
                        column: x => x.FacilitiesId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilityHotel_Hotels_HotelsId",
                        column: x => x.HotelsId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelReview",
                columns: table => new
                {
                    HotelsId = table.Column<int>(type: "integer", nullable: false),
                    ReviewsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelReview", x => new { x.HotelsId, x.ReviewsId });
                    table.ForeignKey(
                        name: "FK_HotelReview_Hotels_HotelsId",
                        column: x => x.HotelsId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelReview_Reviews_ReviewsId",
                        column: x => x.ReviewsId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityHotel_HotelsId",
                table: "FacilityHotel",
                column: "HotelsId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelReview_ReviewsId",
                table: "HotelReview",
                column: "ReviewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_users_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_users_UserId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "FacilityHotel");

            migrationBuilder.DropTable(
                name: "HotelReview");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Bookings",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}

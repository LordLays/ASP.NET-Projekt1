using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TripGuides",
                columns: table => new
                {
                    GuideId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    GuideName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuidePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuideEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripGuide", x => x.GuideId);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    GuideId = table.Column<int>(type: "int", nullable: false),
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.TripId);
                });

            migrationBuilder.CreateTable(
                name: "TripParticipants",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(type: "int", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    ParticipantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipantEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipantPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripParticipant", x => x.ParticipantId);
                    table.ForeignKey(
                        name: "FK_TripParticipants_Trips_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripReviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false),
                    TripParticipantId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripReview", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_TripReviews_Trips_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripTripGuide",
                columns: table => new
                {
                    GuideId = table.Column<int>(type: "int", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripTripGuide", x => new { x.GuideId, x.TripId });
                    table.ForeignKey(
                        name: "FK_TripTripGuide_TripGuides_TripId",
                        column: x => x.TripId,
                        principalTable: "TripGuides",
                        principalColumn: "GuideId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripTripGuide_Trips_GuideId",
                        column: x => x.GuideId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripParticipantTripReview",
                columns: table => new
                {
                    TripParticipantsParticipantId = table.Column<int>(type: "int", nullable: false),
                    TripReviewsReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripParticipantTripReview", x => new { x.TripParticipantsParticipantId, x.TripReviewsReviewId });
                    table.ForeignKey(
                        name: "FK_TripParticipantTripReview_TripParticipants_TripParticipantsParticipantId",
                        column: x => x.TripParticipantsParticipantId,
                        principalTable: "TripParticipants",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TripParticipantTripReview_TripReviews_TripReviewsReviewId",
                        column: x => x.TripReviewsReviewId,
                        principalTable: "TripReviews",
                        principalColumn: "ReviewId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TripParticipantTripReview_TripReviewsReviewId",
                table: "TripParticipantTripReview",
                column: "TripReviewsReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_TripTripGuide_TripId",
                table: "TripTripGuide",
                column: "TripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripParticipantTripReview");

            migrationBuilder.DropTable(
                name: "TripTripGuide");

            migrationBuilder.DropTable(
                name: "TripParticipants");

            migrationBuilder.DropTable(
                name: "TripReviews");

            migrationBuilder.DropTable(
                name: "TripGuides");

            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}

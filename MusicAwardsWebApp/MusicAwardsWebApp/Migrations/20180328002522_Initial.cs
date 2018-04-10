using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicAwardsWebApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AwardCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nominees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Gender = table.Column<string>(maxLength: 1, nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    ImageMime = table.Column<string>(nullable: true),
                    School = table.Column<string>(maxLength: 100, nullable: false),
                    StageName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nominees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryNominees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    NomineeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryNominees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryNominees_AwardCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AwardCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryNominees_Nominees_NomineeId",
                        column: x => x.NomineeId,
                        principalTable: "Nominees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    NomineeId = table.Column<int>(nullable: false),
                    PhoneIPAdress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votes_AwardCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AwardCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votes_Nominees_NomineeId",
                        column: x => x.NomineeId,
                        principalTable: "Nominees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryNominees_CategoryId",
                table: "CategoryNominees",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryNominees_NomineeId",
                table: "CategoryNominees",
                column: "NomineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_CategoryId",
                table: "Votes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_NomineeId",
                table: "Votes",
                column: "NomineeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryNominees");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "AwardCategories");

            migrationBuilder.DropTable(
                name: "Nominees");
        }
    }
}

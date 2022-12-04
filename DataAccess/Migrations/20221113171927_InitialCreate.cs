using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsHome = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareBranch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareBranch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareLangues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareLangues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategory", x => new { x.CategoryId, x.ArticleId });
                    table.ForeignKey(
                        name: "FK_ArticleCategory_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareBranchLangue",
                columns: table => new
                {
                    SoftwareBranchId = table.Column<int>(nullable: false),
                    SoftwareLangueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareBranchLangue", x => new { x.SoftwareBranchId, x.SoftwareLangueId });
                    table.ForeignKey(
                        name: "FK_SoftwareBranchLangue_SoftwareBranch_SoftwareBranchId",
                        column: x => x.SoftwareBranchId,
                        principalTable: "SoftwareBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoftwareBranchLangue_SoftwareLangues_SoftwareLangueId",
                        column: x => x.SoftwareLangueId,
                        principalTable: "SoftwareLangues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategory_ArticleId",
                table: "ArticleCategory",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareBranchLangue_SoftwareLangueId",
                table: "SoftwareBranchLangue",
                column: "SoftwareLangueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategory");

            migrationBuilder.DropTable(
                name: "SoftwareBranchLangue");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "SoftwareBranch");

            migrationBuilder.DropTable(
                name: "SoftwareLangues");
        }
    }
}

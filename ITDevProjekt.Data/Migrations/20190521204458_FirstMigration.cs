using Microsoft.EntityFrameworkCore.Migrations;

namespace ITDevProjekt.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Langs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    LangAttr = table.Column<string>(nullable: true),
                    LangName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Langs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    LangSource = table.Column<string>(nullable: true),
                    LangTranslate = table.Column<string>(nullable: true),
                    TextBefore = table.Column<string>(nullable: true),
                    TextAfter = table.Column<string>(nullable: true),
                    TextToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Langs");

            migrationBuilder.DropTable(
                name: "Translations");
        }
    }
}

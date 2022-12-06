using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassDesigningEg.Migrations
{
    public partial class OneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Did",
                table: "Employer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Did = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Did);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employer_Did",
                table: "Employer",
                column: "Did");

            migrationBuilder.AddForeignKey(
                name: "FK_Employer_Department_Did",
                table: "Employer",
                column: "Did",
                principalTable: "Department",
                principalColumn: "Did",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employer_Department_Did",
                table: "Employer");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Employer_Did",
                table: "Employer");

            migrationBuilder.DropColumn(
                name: "Did",
                table: "Employer");
        }
    }
}

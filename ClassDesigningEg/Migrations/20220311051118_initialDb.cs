using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassDesigningEg.Migrations
{
    public partial class initialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Aid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Aid);
                });

            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    Eid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Aid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.Eid);
                    table.ForeignKey(
                        name: "FK_Employer_Address_Aid",
                        column: x => x.Aid,
                        principalTable: "Address",
                        principalColumn: "Aid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employer_Aid",
                table: "Employer",
                column: "Aid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employer");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}

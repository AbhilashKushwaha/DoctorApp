using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Healthapp.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    middleName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    emailId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    isActive = table.Column<sbyte>(type: "tinyint", nullable: false),
                    isDoctor = table.Column<sbyte>(type: "tinyint", nullable: false),
                    profilePicture = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    creationDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    lastUpdateDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

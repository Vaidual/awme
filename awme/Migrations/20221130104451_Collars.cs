using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace awme.Migrations
{
    /// <inheritdoc />
    public partial class Collars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CollarId",
                table: "Animals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Collars",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InUse = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    CollarId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Collars_CollarId",
                        column: x => x.CollarId,
                        principalTable: "Collars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 6, 20, 144, 203, 219, 154, 234, 137, 90, 67, 171, 36, 222, 158, 118, 92, 48, 136, 80, 23, 86, 234, 190, 2, 215, 145, 100, 136, 54, 29, 251, 190, 160, 0, 25, 233, 155, 71, 167, 164, 51, 205, 129, 70, 175, 189, 48, 29, 139, 19, 64, 109, 168, 128, 66, 76, 192, 171, 9, 217, 63, 222, 180, 209 }, new byte[] { 94, 181, 128, 56, 136, 135, 23, 236, 50, 141, 69, 66, 218, 165, 233, 102, 202, 202, 37, 235, 45, 104, 184, 163, 217, 99, 144, 157, 80, 188, 174, 255, 236, 39, 219, 249, 41, 112, 219, 137, 168, 239, 136, 253, 226, 116, 170, 203, 32, 65, 76, 4, 38, 212, 170, 12, 197, 231, 244, 193, 153, 233, 203, 245, 54, 156, 240, 155, 174, 149, 85, 59, 135, 40, 217, 213, 15, 181, 123, 160, 133, 43, 191, 101, 143, 42, 18, 214, 250, 46, 2, 200, 162, 102, 166, 108, 80, 23, 63, 111, 221, 35, 187, 172, 54, 191, 84, 236, 46, 235, 17, 212, 57, 96, 158, 201, 178, 155, 88, 184, 44, 109, 162, 47, 87, 109, 133, 125 } });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CollarId",
                table: "Animals",
                column: "CollarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CollarId",
                table: "Activities",
                column: "CollarId");

            migrationBuilder.CreateIndex(
                name: "IX_Collars_UserId",
                table: "Collars",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Collars_CollarId",
                table: "Animals",
                column: "CollarId",
                principalTable: "Collars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Collars_CollarId",
                table: "Animals");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Collars");

            migrationBuilder.DropIndex(
                name: "IX_Animals_CollarId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "CollarId",
                table: "Animals");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 151, 230, 34, 88, 139, 8, 113, 82, 148, 229, 9, 5, 90, 161, 251, 192, 187, 167, 27, 126, 56, 139, 137, 229, 1, 152, 18, 20, 64, 11, 133, 45, 251, 135, 222, 42, 230, 6, 41, 30, 243, 88, 90, 142, 13, 60, 176, 119, 174, 146, 11, 90, 247, 27, 196, 155, 210, 135, 154, 145, 61, 57, 214, 0 }, new byte[] { 220, 153, 211, 5, 16, 5, 46, 124, 100, 62, 129, 222, 80, 20, 160, 59, 32, 169, 74, 54, 234, 133, 132, 194, 6, 5, 172, 31, 162, 143, 250, 199, 106, 118, 42, 228, 245, 95, 27, 253, 230, 167, 195, 195, 195, 248, 39, 111, 2, 96, 174, 234, 65, 91, 126, 197, 64, 121, 249, 227, 26, 41, 50, 96, 75, 201, 158, 123, 199, 169, 109, 235, 88, 147, 146, 141, 228, 46, 137, 91, 28, 65, 3, 92, 246, 145, 3, 16, 91, 251, 54, 107, 57, 184, 179, 22, 226, 23, 90, 151, 221, 222, 95, 188, 46, 183, 138, 7, 239, 214, 61, 77, 22, 165, 150, 133, 193, 125, 117, 101, 195, 65, 207, 173, 79, 102, 63, 36 } });
        }
    }
}

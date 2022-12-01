using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace awme.Migrations
{
    /// <inheritdoc />
    public partial class NullableAnimalCollar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Collars_CollarId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_CollarId",
                table: "Animals");

            migrationBuilder.AlterColumn<string>(
                name: "CollarId",
                table: "Animals",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 61, 229, 166, 172, 151, 182, 154, 31, 203, 111, 121, 104, 158, 122, 157, 233, 248, 126, 150, 80, 169, 193, 17, 167, 57, 99, 22, 158, 59, 196, 216, 42, 25, 54, 63, 66, 70, 60, 172, 108, 167, 47, 244, 177, 157, 177, 203, 68, 222, 66, 84, 126, 154, 69, 150, 141, 159, 184, 37, 127, 60, 219, 160, 237 }, new byte[] { 231, 220, 15, 116, 27, 59, 43, 134, 10, 33, 21, 143, 26, 21, 24, 36, 51, 180, 210, 65, 211, 200, 146, 160, 50, 132, 36, 136, 35, 64, 127, 77, 12, 53, 186, 13, 170, 142, 107, 3, 4, 208, 136, 68, 27, 77, 156, 75, 103, 228, 34, 188, 170, 19, 145, 76, 113, 74, 108, 184, 70, 74, 142, 156, 1, 201, 40, 12, 90, 235, 170, 160, 144, 28, 133, 126, 37, 164, 120, 101, 92, 85, 243, 158, 177, 68, 134, 189, 163, 184, 134, 71, 9, 235, 125, 240, 100, 236, 18, 158, 65, 238, 163, 230, 22, 199, 31, 67, 109, 100, 216, 221, 117, 200, 184, 148, 67, 103, 155, 180, 123, 123, 234, 13, 91, 222, 201, 93 } });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CollarId",
                table: "Animals",
                column: "CollarId",
                unique: true,
                filter: "[CollarId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Collars_CollarId",
                table: "Animals",
                column: "CollarId",
                principalTable: "Collars",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Collars_CollarId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_CollarId",
                table: "Animals");

            migrationBuilder.AlterColumn<string>(
                name: "CollarId",
                table: "Animals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Collars_CollarId",
                table: "Animals",
                column: "CollarId",
                principalTable: "Collars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

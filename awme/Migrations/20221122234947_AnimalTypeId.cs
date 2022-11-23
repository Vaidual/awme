using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace awme.Migrations
{
    /// <inheritdoc />
    public partial class AnimalTypeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_AnimalTypes_AnimalTypeId",
                table: "Animals");

            migrationBuilder.RenameColumn(
                name: "AnimalTypeId",
                table: "Animals",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Animals_AnimalTypeId",
                table: "Animals",
                newName: "IX_Animals_TypeId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 52, 183, 244, 240, 13, 179, 163, 136, 25, 179, 201, 118, 129, 99, 135, 94, 121, 95, 208, 142, 239, 85, 53, 227, 9, 253, 205, 87, 146, 168, 28, 92, 205, 141, 41, 134, 189, 251, 80, 79, 192, 26, 139, 196, 249, 158, 25, 43, 47, 116, 240, 38, 71, 24, 5, 217, 123, 40, 210, 10, 121, 57, 117, 103 }, new byte[] { 133, 232, 153, 17, 13, 114, 86, 183, 235, 85, 249, 138, 46, 210, 235, 161, 157, 72, 17, 235, 166, 49, 253, 82, 28, 32, 103, 123, 10, 17, 113, 20, 206, 235, 246, 46, 212, 67, 112, 123, 97, 22, 39, 145, 174, 181, 43, 52, 66, 247, 206, 91, 145, 186, 109, 78, 207, 15, 214, 117, 96, 88, 23, 9, 113, 187, 119, 44, 163, 179, 123, 103, 57, 234, 76, 246, 129, 80, 43, 92, 53, 66, 180, 204, 179, 213, 76, 238, 32, 132, 145, 178, 76, 144, 254, 196, 92, 157, 228, 143, 184, 106, 242, 74, 205, 29, 56, 140, 72, 129, 71, 232, 82, 171, 48, 238, 109, 1, 153, 123, 126, 154, 179, 78, 158, 171, 230, 185 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_AnimalTypes_TypeId",
                table: "Animals",
                column: "TypeId",
                principalTable: "AnimalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_AnimalTypes_TypeId",
                table: "Animals");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Animals",
                newName: "AnimalTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Animals_TypeId",
                table: "Animals",
                newName: "IX_Animals_AnimalTypeId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 164, 38, 234, 210, 198, 157, 210, 159, 106, 42, 211, 116, 202, 52, 173, 166, 235, 11, 175, 197, 224, 222, 186, 112, 160, 46, 204, 27, 129, 111, 38, 231, 237, 191, 139, 240, 38, 206, 147, 220, 139, 230, 35, 93, 219, 48, 251, 74, 216, 31, 37, 23, 197, 90, 218, 191, 78, 66, 78, 43, 253, 56, 201, 206 }, new byte[] { 103, 173, 134, 112, 42, 69, 131, 189, 198, 37, 58, 150, 50, 183, 155, 144, 166, 248, 22, 212, 13, 25, 93, 167, 148, 67, 77, 255, 13, 253, 229, 111, 62, 181, 236, 203, 242, 223, 61, 204, 15, 133, 10, 5, 119, 101, 168, 145, 158, 90, 38, 131, 244, 85, 184, 192, 236, 2, 253, 0, 18, 224, 173, 108, 44, 127, 107, 94, 240, 11, 143, 26, 209, 153, 31, 6, 224, 62, 82, 99, 239, 72, 133, 19, 126, 231, 254, 132, 36, 0, 98, 175, 187, 133, 110, 219, 154, 244, 166, 207, 118, 246, 179, 113, 161, 80, 20, 17, 117, 247, 118, 202, 37, 214, 146, 117, 20, 247, 209, 44, 39, 104, 35, 155, 12, 31, 7, 91 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_AnimalTypes_AnimalTypeId",
                table: "Animals",
                column: "AnimalTypeId",
                principalTable: "AnimalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

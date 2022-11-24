using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace awme.Migrations
{
    /// <inheritdoc />
    public partial class EnumUpdatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { new byte[] { 151, 230, 34, 88, 139, 8, 113, 82, 148, 229, 9, 5, 90, 161, 251, 192, 187, 167, 27, 126, 56, 139, 137, 229, 1, 152, 18, 20, 64, 11, 133, 45, 251, 135, 222, 42, 230, 6, 41, 30, 243, 88, 90, 142, 13, 60, 176, 119, 174, 146, 11, 90, 247, 27, 196, 155, 210, 135, 154, 145, 61, 57, 214, 0 }, new byte[] { 220, 153, 211, 5, 16, 5, 46, 124, 100, 62, 129, 222, 80, 20, 160, 59, 32, 169, 74, 54, 234, 133, 132, 194, 6, 5, 172, 31, 162, 143, 250, 199, 106, 118, 42, 228, 245, 95, 27, 253, 230, 167, 195, 195, 195, 248, 39, 111, 2, 96, 174, 234, 65, 91, 126, 197, 64, 121, 249, 227, 26, 41, 50, 96, 75, 201, 158, 123, 199, 169, 109, 235, 88, 147, 146, 141, 228, 46, 137, 91, 28, 65, 3, 92, 246, 145, 3, 16, 91, 251, 54, 107, 57, 184, 179, 22, 226, 23, 90, 151, 221, 222, 95, 188, 46, 183, 138, 7, 239, 214, 61, 77, 22, 165, 150, 133, 193, 125, 117, 101, 195, 65, 207, 173, 79, 102, 63, 36 }, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { new byte[] { 52, 183, 244, 240, 13, 179, 163, 136, 25, 179, 201, 118, 129, 99, 135, 94, 121, 95, 208, 142, 239, 85, 53, 227, 9, 253, 205, 87, 146, 168, 28, 92, 205, 141, 41, 134, 189, 251, 80, 79, 192, 26, 139, 196, 249, 158, 25, 43, 47, 116, 240, 38, 71, 24, 5, 217, 123, 40, 210, 10, 121, 57, 117, 103 }, new byte[] { 133, 232, 153, 17, 13, 114, 86, 183, 235, 85, 249, 138, 46, 210, 235, 161, 157, 72, 17, 235, 166, 49, 253, 82, 28, 32, 103, 123, 10, 17, 113, 20, 206, 235, 246, 46, 212, 67, 112, 123, 97, 22, 39, 145, 174, 181, 43, 52, 66, 247, 206, 91, 145, 186, 109, 78, 207, 15, 214, 117, 96, 88, 23, 9, 113, 187, 119, 44, 163, 179, 123, 103, 57, 234, 76, 246, 129, 80, 43, 92, 53, 66, 180, 204, 179, 213, 76, 238, 32, 132, 145, 178, 76, 144, 254, 196, 92, 157, 228, 143, 184, 106, 242, 74, 205, 29, 56, 140, 72, 129, 71, 232, 82, 171, 48, 238, 109, 1, 153, 123, 126, 154, 179, 78, 158, 171, 230, 185 }, "Admin" });
        }
    }
}

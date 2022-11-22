using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace awme.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Profiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Animals",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 187, 173, 92, 65, 181, 112, 247, 207, 224, 196, 77, 59, 151, 217, 144, 248, 174, 100, 8, 84, 1, 21, 194, 108, 240, 51, 136, 77, 1, 104, 91, 11, 165, 43, 235, 101, 59, 233, 200, 50, 167, 58, 126, 18, 200, 179, 100, 194, 17, 203, 240, 137, 240, 190, 30, 191, 146, 110, 106, 5, 197, 103, 250, 14 }, new byte[] { 198, 4, 34, 206, 36, 54, 6, 155, 247, 90, 95, 254, 1, 161, 197, 86, 51, 26, 37, 228, 58, 158, 200, 90, 136, 240, 232, 42, 105, 9, 160, 48, 35, 163, 214, 132, 134, 214, 97, 223, 47, 237, 232, 223, 46, 211, 19, 225, 39, 200, 104, 83, 57, 239, 12, 206, 108, 140, 253, 74, 175, 20, 75, 177, 228, 68, 220, 17, 161, 215, 220, 185, 143, 219, 7, 90, 72, 151, 192, 234, 19, 98, 164, 12, 48, 201, 39, 195, 84, 155, 233, 234, 254, 87, 154, 182, 186, 199, 179, 200, 25, 214, 194, 172, 206, 127, 198, 158, 217, 59, 185, 186, 246, 24, 224, 231, 205, 60, 253, 125, 118, 99, 8, 14, 95, 82, 67, 138 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Animals");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 208, 34, 163, 227, 219, 55, 206, 110, 65, 182, 90, 187, 95, 43, 81, 145, 60, 240, 84, 126, 233, 195, 200, 190, 17, 178, 213, 192, 19, 17, 185, 139, 225, 46, 69, 53, 123, 231, 131, 223, 5, 8, 86, 232, 84, 117, 46, 112, 131, 199, 251, 170, 10, 150, 14, 114, 154, 161, 127, 33, 25, 107, 9, 95 }, new byte[] { 240, 237, 102, 188, 43, 100, 1, 0, 191, 97, 106, 173, 157, 46, 129, 43, 66, 99, 49, 5, 68, 99, 122, 106, 14, 141, 122, 202, 108, 245, 106, 100, 123, 92, 8, 198, 82, 158, 93, 223, 143, 254, 6, 8, 206, 11, 103, 229, 240, 110, 136, 178, 8, 153, 124, 160, 190, 245, 108, 43, 103, 83, 173, 149, 253, 98, 152, 68, 109, 239, 61, 134, 209, 138, 7, 14, 153, 160, 176, 149, 20, 253, 253, 148, 102, 73, 148, 249, 233, 227, 116, 191, 229, 172, 208, 189, 190, 151, 48, 3, 63, 244, 242, 229, 95, 133, 158, 36, 39, 4, 238, 106, 228, 62, 37, 84, 36, 81, 136, 223, 204, 20, 232, 188, 174, 195, 32, 144 } });
        }
    }
}

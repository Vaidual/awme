using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace awme.Migrations
{
    /// <inheritdoc />
    public partial class ProfileBan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BanEnd",
                table: "Profiles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBanned",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 179, 55, 192, 89, 157, 74, 106, 248, 232, 157, 196, 81, 87, 162, 110, 11, 131, 111, 199, 140, 49, 209, 195, 3, 47, 195, 176, 80, 23, 126, 157, 236, 138, 232, 21, 28, 29, 173, 240, 247, 75, 238, 37, 249, 230, 230, 82, 7, 140, 140, 38, 252, 87, 240, 185, 105, 179, 102, 234, 54, 127, 200, 156, 187 }, new byte[] { 163, 215, 157, 4, 95, 1, 155, 88, 11, 227, 174, 202, 8, 167, 125, 187, 1, 0, 31, 205, 156, 111, 219, 157, 173, 145, 54, 185, 164, 58, 95, 182, 200, 26, 75, 60, 157, 145, 41, 39, 136, 77, 49, 97, 129, 43, 218, 48, 10, 200, 224, 169, 24, 178, 204, 208, 58, 244, 109, 29, 112, 122, 20, 193, 48, 60, 205, 246, 68, 165, 33, 119, 180, 139, 61, 213, 203, 55, 117, 108, 170, 158, 67, 163, 238, 164, 82, 102, 30, 146, 165, 240, 97, 190, 5, 119, 184, 238, 29, 229, 151, 231, 253, 113, 203, 165, 189, 207, 16, 124, 118, 130, 72, 21, 152, 19, 129, 14, 122, 254, 86, 112, 156, 77, 6, 104, 189, 149 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BanEnd",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "IsBanned",
                table: "Profiles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 63, 131, 43, 24, 119, 59, 21, 60, 137, 236, 199, 60, 101, 87, 92, 91, 9, 136, 26, 233, 193, 177, 10, 132, 232, 244, 54, 198, 28, 139, 137, 236, 158, 162, 85, 77, 102, 24, 42, 55, 10, 124, 187, 137, 76, 99, 0, 180, 107, 156, 73, 141, 132, 71, 105, 56, 67, 56, 115, 50, 107, 11, 235, 120 }, new byte[] { 194, 237, 61, 140, 35, 97, 165, 0, 110, 93, 216, 81, 153, 195, 234, 45, 32, 148, 202, 9, 218, 107, 36, 8, 158, 56, 155, 39, 184, 115, 74, 99, 148, 49, 102, 33, 191, 195, 95, 64, 54, 8, 189, 7, 178, 110, 52, 76, 51, 228, 240, 235, 122, 182, 217, 248, 208, 128, 16, 67, 104, 181, 75, 121, 77, 88, 13, 4, 153, 111, 156, 119, 241, 225, 86, 240, 15, 99, 66, 148, 248, 181, 241, 221, 72, 255, 139, 81, 95, 25, 246, 107, 40, 9, 141, 108, 239, 141, 74, 6, 33, 164, 125, 153, 9, 180, 160, 32, 151, 44, 95, 161, 88, 233, 86, 121, 43, 73, 176, 4, 121, 87, 248, 255, 3, 226, 51, 207 } });
        }
    }
}

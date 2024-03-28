using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlappyAPI.Migrations
{
    public partial class removeUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Score_AspNetUsers_UserId",
                table: "Score");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Score",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fa0a957-3da7-46b6-a6c0-3d0b8937ba5a", "AQAAAAEAACcQAAAAEIYXxjuv17wKHn7KCDqEiRpEvIrsbR40nxZqVCHP2bSyfowoA0E9pUnaV4j21gqSPQ==", "0868a6a5-1060-408c-80a1-5ef4ae788693" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af9c4d7a-86dd-4d1c-966e-a089248698fa", "AQAAAAEAACcQAAAAEF502TUui+CUkRysXw0vxH8yhKyvkG3zenX6qJmDHxM8XNd7dI8oricHqPUusv5QHg==", "73cee4f8-59a3-49ab-93bd-27f6df365deb" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: "2024-03-28 22:51:22");

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: "2024-03-28 23:51:22");

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: "2024-03-28 22:51:22");

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: "2024-03-28 23:51:22");

            migrationBuilder.AddForeignKey(
                name: "FK_Score_AspNetUsers_UserId",
                table: "Score",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Score_AspNetUsers_UserId",
                table: "Score");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Score",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c49c48a6-67a1-4a60-9e1c-161a8fd525d1", "AQAAAAEAACcQAAAAEHbwMH1Fo65Uc1po8USB73du4IY27/vge0ImR1N5urBCW5pm7QIldr+ug28rlu2z5Q==", "5128806d-b7ae-484f-a423-f229d309f295" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01cc13cd-997a-43cf-bb9f-608e761e44b3", null, "8eb15639-6b22-48c4-bff4-01a3b9f61e41" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: "2024-03-28 22:06:47");

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: "2024-03-28 23:06:47");

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: "2024-03-28 22:06:47");

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: "2024-03-28 23:06:47");

            migrationBuilder.AddForeignKey(
                name: "FK_Score_AspNetUsers_UserId",
                table: "Score",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

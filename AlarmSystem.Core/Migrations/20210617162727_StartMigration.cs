using Microsoft.EntityFrameworkCore.Migrations;

namespace AlarmSystem.Core.Migrations
{
    public partial class StartMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlarmActions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionName = table.Column<string>(nullable: true),
                    ActionTask = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmActions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AlarmObjects",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectName = table.Column<string>(nullable: true),
                    ObjectOwnerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmObjects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AlarmObjects_Users_ObjectOwnerID",
                        column: x => x.ObjectOwnerID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlarmSystems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemName = table.Column<string>(nullable: true),
                    AlarmObjectID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmSystems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AlarmSystems_AlarmObjects_AlarmObjectID",
                        column: x => x.AlarmObjectID,
                        principalTable: "AlarmObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlarmScenerios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScenerioName = table.Column<string>(nullable: true),
                    AlarmSystemID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmScenerios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AlarmScenerios_AlarmSystems_AlarmSystemID",
                        column: x => x.AlarmSystemID,
                        principalTable: "AlarmSystems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlarmZones",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneName = table.Column<string>(nullable: true),
                    AlarmSystemID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmZones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AlarmZones_AlarmSystems_AlarmSystemID",
                        column: x => x.AlarmSystemID,
                        principalTable: "AlarmSystems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InputOutputs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IOName = table.Column<string>(nullable: true),
                    IOPlace = table.Column<string>(nullable: true),
                    AlarmSystemID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputOutputs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InputOutputs_AlarmSystems_AlarmSystemID",
                        column: x => x.AlarmSystemID,
                        principalTable: "AlarmSystems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IOInAlarmZones",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InputOutputID = table.Column<int>(nullable: true),
                    AlarmZoneID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IOInAlarmZones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IOInAlarmZones_AlarmZones_AlarmZoneID",
                        column: x => x.AlarmZoneID,
                        principalTable: "AlarmZones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IOInAlarmZones_InputOutputs_InputOutputID",
                        column: x => x.InputOutputID,
                        principalTable: "InputOutputs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlarmObjects_ObjectOwnerID",
                table: "AlarmObjects",
                column: "ObjectOwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_AlarmScenerios_AlarmSystemID",
                table: "AlarmScenerios",
                column: "AlarmSystemID");

            migrationBuilder.CreateIndex(
                name: "IX_AlarmSystems_AlarmObjectID",
                table: "AlarmSystems",
                column: "AlarmObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_AlarmZones_AlarmSystemID",
                table: "AlarmZones",
                column: "AlarmSystemID");

            migrationBuilder.CreateIndex(
                name: "IX_InputOutputs_AlarmSystemID",
                table: "InputOutputs",
                column: "AlarmSystemID");

            migrationBuilder.CreateIndex(
                name: "IX_IOInAlarmZones_AlarmZoneID",
                table: "IOInAlarmZones",
                column: "AlarmZoneID");

            migrationBuilder.CreateIndex(
                name: "IX_IOInAlarmZones_InputOutputID",
                table: "IOInAlarmZones",
                column: "InputOutputID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlarmActions");

            migrationBuilder.DropTable(
                name: "AlarmScenerios");

            migrationBuilder.DropTable(
                name: "IOInAlarmZones");

            migrationBuilder.DropTable(
                name: "AlarmZones");

            migrationBuilder.DropTable(
                name: "InputOutputs");

            migrationBuilder.DropTable(
                name: "AlarmSystems");

            migrationBuilder.DropTable(
                name: "AlarmObjects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

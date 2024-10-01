using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicLessonSchedule.Migrations
{
    /// <inheritdoc />
    public partial class StudentTeacherInstruments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentInstrument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    InstrumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInstrument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentInstrument_Instrument_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instrument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentInstrument_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherInstrument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    InstrumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherInstrument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherInstrument_Instrument_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instrument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherInstrument_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentInstrument_InstrumentId",
                table: "StudentInstrument",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInstrument_StudentId",
                table: "StudentInstrument",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherInstrument_InstrumentId",
                table: "TeacherInstrument",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherInstrument_TeacherId",
                table: "TeacherInstrument",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentInstrument");

            migrationBuilder.DropTable(
                name: "TeacherInstrument");
        }
    }
}

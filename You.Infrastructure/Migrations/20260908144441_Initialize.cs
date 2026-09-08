using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace You.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ImageKey = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "GripTypes",
                columns: table => new
                {
                    GripTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ImageKey = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GripTypes", x => x.GripTypeId);
                });

            migrationBuilder.CreateTable(
                name: "WeightTypes",
                columns: table => new
                {
                    WeightTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ImageKey = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightTypes", x => x.WeightTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseVariants",
                columns: table => new
                {
                    ExerciseVariantId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uuid", nullable: false),
                    GripTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                    WeightTypeId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseVariants", x => x.ExerciseVariantId);
                    table.ForeignKey(
                        name: "FK_ExerciseVariants_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseVariants_GripTypes_GripTypeId",
                        column: x => x.GripTypeId,
                        principalTable: "GripTypes",
                        principalColumn: "GripTypeId");
                    table.ForeignKey(
                        name: "FK_ExerciseVariants_WeightTypes_WeightTypeId",
                        column: x => x.WeightTypeId,
                        principalTable: "WeightTypes",
                        principalColumn: "WeightTypeId");
                });

            migrationBuilder.CreateTable(
                name: "DayExercises",
                columns: table => new
                {
                    DayExerciseId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExerciseVariantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    ExerciseOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayExercises", x => x.DayExerciseId);
                    table.ForeignKey(
                        name: "FK_DayExercises_ExerciseVariants_ExerciseVariantId",
                        column: x => x.ExerciseVariantId,
                        principalTable: "ExerciseVariants",
                        principalColumn: "ExerciseVariantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseSets",
                columns: table => new
                {
                    ExerciseSetId = table.Column<Guid>(type: "uuid", nullable: false),
                    DayExerciseId = table.Column<Guid>(type: "uuid", nullable: false),
                    SetNumber = table.Column<int>(type: "integer", nullable: false),
                    RepCount = table.Column<int>(type: "integer", nullable: true),
                    Weight = table.Column<decimal>(type: "numeric", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSets", x => x.ExerciseSetId);
                    table.ForeignKey(
                        name: "FK_ExerciseSets_DayExercises_DayExerciseId",
                        column: x => x.DayExerciseId,
                        principalTable: "DayExercises",
                        principalColumn: "DayExerciseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayExercises_ExerciseVariantId",
                table: "DayExercises",
                column: "ExerciseVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSets_DayExerciseId",
                table: "ExerciseSets",
                column: "DayExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseVariants_ExerciseId",
                table: "ExerciseVariants",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseVariants_GripTypeId",
                table: "ExerciseVariants",
                column: "GripTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseVariants_WeightTypeId",
                table: "ExerciseVariants",
                column: "WeightTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseSets");

            migrationBuilder.DropTable(
                name: "DayExercises");

            migrationBuilder.DropTable(
                name: "ExerciseVariants");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "GripTypes");

            migrationBuilder.DropTable(
                name: "WeightTypes");
        }
    }
}

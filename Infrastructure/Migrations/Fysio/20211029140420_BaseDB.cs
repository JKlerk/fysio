using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.Fysio
{
    public partial class BaseDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BigNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Therapists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BigNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientsFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiagnoseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterviewerId = table.Column<int>(type: "int", nullable: true),
                    SupervisorId = table.Column<int>(type: "int", nullable: true),
                    PractitionerId = table.Column<int>(type: "int", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DischargeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TherapistType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientsFile_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientsFile_Therapists_InterviewerId",
                        column: x => x.InterviewerId,
                        principalTable: "Therapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientsFile_Therapists_PractitionerId",
                        column: x => x.PractitionerId,
                        principalTable: "Therapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientsFile_Therapists_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Therapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientFileId = table.Column<int>(type: "int", nullable: false),
                    MaxTreatments = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentPlans_PatientsFile_PatientFileId",
                        column: x => x.PatientFileId,
                        principalTable: "PatientsFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreatmentPlanId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TherapistId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatments_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treatments_TreatmentPlans_TreatmentPlanId",
                        column: x => x.TreatmentPlanId,
                        principalTable: "TreatmentPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    TherapistId = table.Column<int>(type: "int", nullable: false),
                    TreatmentId = table.Column<int>(type: "int", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "BigNumber", "Birthdate", "Email", "Gender", "Name", "PatientNumber", "PhoneNumber", "StaffNumber" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2002, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kate@test.com", "Female", "Kate Velasquez", "24f2f1f7-2e67-43c6-ad96-117b4d6ea413", "0612121212", "2168734" },
                    { 2, null, new DateTime(2002, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily@test.com", "Female", "Emily Fariello", "c92c9203-fbed-416d-82f6-bdbab04d3da9", "0612121212", "2168734" }
                });

            migrationBuilder.InsertData(
                table: "Therapists",
                columns: new[] { "Id", "AvailableDate", "BigNumber", "Email", "Name", "PhoneNumber", "RoleId", "StudentNumber" },
                values: new object[,]
                {
                    { 1, "01/09/2002 00:00:00", "12345678901", "p.stoop@avans.nl", "Pascal Stoop", "0612121212", 0, "null" },
                    { 2, "01/09/2002 00:00:00", "12345678901", "a.biyikli@avans.nl", "Ali Biyikli", "0612121212", 0, "null" }
                });

            migrationBuilder.InsertData(
                table: "PatientsFile",
                columns: new[] { "Id", "Age", "Description", "DiagnoseCode", "DischargeDate", "InterviewerId", "Notes", "PatientId", "PractitionerId", "RegisterDate", "SupervisorId", "TherapistType" },
                values: new object[] { 1, 18, "Big description", "BCH-1000", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Qui molestiae unde voluptates aperiam quas quaerat minus perferendis tenetur fuga provident, nemo abexplicabo vitae at numquam quo. Dolorum, enim saepe.", 1, 1, new DateTime(2002, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Student" });

            migrationBuilder.InsertData(
                table: "PatientsFile",
                columns: new[] { "Id", "Age", "Description", "DiagnoseCode", "DischargeDate", "InterviewerId", "Notes", "PatientId", "PractitionerId", "RegisterDate", "SupervisorId", "TherapistType" },
                values: new object[] { 2, 18, "Big description", "BCH-1000", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Qui molestiae unde voluptates aperiam quas quaerat minus perferendis tenetur fuga provident, nemo abexplicabo vitae at numquam quo. Dolorum, enim saepe.", 2, 1, new DateTime(2002, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Student" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TherapistId",
                table: "Appointments",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TreatmentId",
                table: "Appointments",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PatientId",
                table: "Images",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientsFile_InterviewerId",
                table: "PatientsFile",
                column: "InterviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientsFile_PatientId",
                table: "PatientsFile",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientsFile_PractitionerId",
                table: "PatientsFile",
                column: "PractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientsFile_SupervisorId",
                table: "PatientsFile",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlans_PatientFileId",
                table: "TreatmentPlans",
                column: "PatientFileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_TherapistId",
                table: "Treatments",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_TreatmentPlanId",
                table: "Treatments",
                column: "TreatmentPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "TreatmentPlans");

            migrationBuilder.DropTable(
                name: "PatientsFile");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Therapists");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HOSPITAL_MANAGEMENT_SYSTEM.Migrations
{
    /// <inheritdoc />
    public partial class initmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartementName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartementLocation = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartementId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientFullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PatientGender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PatientDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    patientAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorFullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DoctorSpecialization = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DoctorEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DoctorSalary = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departments",
                        principalColumn: "DepartementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "Scheduled"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    MedicalRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagnosis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.MedicalRecordId);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartementId", "DepartementLocation", "DepartementName" },
                values: new object[,]
                {
                    { 1, "Cairo", "Cardiology" },
                    { 2, "Giza", "Pediatrics" },
                    { 3, "Cairo", "Orthopedics" },
                    { 4, "Giza", "Dermatology" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "PatientDateOfBirth", "PatientFullName", "PatientGender", "PatientPhone", "patientAddress" },
                values: new object[,]
                {
                    { 1, new DateTime(1995, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Omer Ali", "Male", "01120000001", "Nasr City, Cairo" },
                    { 2, new DateTime(1998, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sara Ahmed", "Female", "01120000002", "Dokki, Giza" },
                    { 3, new DateTime(1987, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mahmoud Samir", "Male", "01120000003", "Heliopolis, Cairo" },
                    { 4, new DateTime(2002, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mariam Adel", "Female", "01120000004", "Giza" },
                    { 5, new DateTime(1979, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yassin Mohamed", "Male", "01120000005", "Maadi, Cairo" },
                    { 6, new DateTime(1991, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hana Khaled", "Female", "01120000006", "October, Giza" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "DepartementId", "DoctorEmail", "DoctorFullName", "DoctorPhone", "DoctorSalary", "DoctorSpecialization" },
                values: new object[,]
                {
                    { 1, 1, "ahmed.hassan@hms.com", "Ahmed Hassan", "01010000001", 45000m, "Cardiologist" },
                    { 2, 1, "mona.adel@hms.com", "Mona Adel", "01010000002", 42000m, "Cardiologist" },
                    { 3, 2, "omar.khaled@hms.com", "Omar Khaled", "01010000003", 38000m, "Pediatrician" },
                    { 4, 2, "nour.samir@hms.com", "Nour Samir", "01010000004", 36000m, "Pediatrician" },
                    { 5, 3, "karim.tarek@hms.com", "Karim Tarek", "01010000005", 50000m, "Orthopedic Surgeon" },
                    { 6, 3, "salma.youssef@hms.com", "Salma Youssef", "01010000006", 41000m, "Orthopedic Specialist" },
                    { 7, 4, "youssef.emad@hms.com", "Youssef Emad", "01010000007", 39000m, "Dermatologist" },
                    { 8, 4, "laila.mostafa@hms.com", "Laila Mostafa", "01010000008", 37000m, "Dermatologist" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "AppointmentDate", "DoctorId", "PatientId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Scheduled" },
                    { 2, new DateTime(2026, 9, 29, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, 6, "Scheduled" },
                    { 3, new DateTime(2026, 9, 29, 11, 3, 0, 0, DateTimeKind.Unspecified), 5, 3, "Completed" },
                    { 4, new DateTime(2026, 9, 29, 13, 0, 0, 0, DateTimeKind.Unspecified), 7, 4, "Cancelled" },
                    { 5, new DateTime(2026, 9, 28, 11, 3, 0, 0, DateTimeKind.Unspecified), 2, 5, "Completed" },
                    { 6, new DateTime(2026, 9, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 6, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "MedicalRecordId", "AppointmentId", "Description", "Diagnosis", "Notes" },
                values: new object[,]
                {
                    { 1, 3, "5mg once daily Follow", "Hypertension Amlodipine", "up after two weeks." },
                    { 2, 5, "Rest and fluids", "Acute respiratory infection", "Patient advised to return if symptoms worsen." },
                    { 3, 6, "Physiotherapy and rest", "Knee ligament injury", "MRI recommended." },
                    { 4, 2, "Topical moisturizer twice daily", "Mild eczema", "Avoid known skin irritants." },
                    { 5, 4, "Paracetamol as needed", "Migraine", "Maintain regular sleep schedule." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartementId",
                table: "Doctors",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorEmail",
                table: "Doctors",
                column: "DoctorEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_AppointmentId",
                table: "MedicalRecords",
                column: "AppointmentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}

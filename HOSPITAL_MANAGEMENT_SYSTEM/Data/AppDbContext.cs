using System.Diagnostics.Metrics;
using HOSPITAL_MANAGEMENT_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HOSPITAL_MANAGEMENT_SYSTEM.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Department> Departments{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Doctor>()
                .HasIndex(Doctor => Doctor.DoctorEmail)
                .IsUnique();

            modelBuilder.Entity<Doctor>()
                .Property(Doctor => Doctor.DoctorSalary)
                .HasPrecision(10, 2);


            modelBuilder.Entity<Department>()
                .HasMany(d => d.Doctors)
                .WithOne(D => D.Department)
                .HasForeignKey(i => i.DepartementId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Appointments)
                .WithOne(D => D.Doctor)
                .HasForeignKey(i => i.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Patient>()
                .HasMany(d => d.Appointments)
                .WithOne(D => D.Patient)
                .HasForeignKey(i => i.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(s => s.Appointment)
                .WithOne(m => m.MedicalRecord) 
                .HasForeignKey<MedicalRecord>(m => m.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Appointment>()
                .Property(a => a.AppointmentDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Appointment>()
                .Property(s => s.Status)
                .HasDefaultValue("Scheduled");




            modelBuilder.Entity<Department>()
                .HasData(
                    new Department {DepartementId = 1,DepartementName = "Cardiology" , DepartementLocation = "Cairo" },
                    new Department {DepartementId = 2,DepartementName = "Pediatrics", DepartementLocation = "Giza" },
                    new Department {DepartementId = 3,DepartementName = "Orthopedics", DepartementLocation = "Cairo" },
                    new Department {DepartementId = 4,DepartementName = "Dermatology", DepartementLocation = "Giza" }
                );



            modelBuilder.Entity<Doctor>()
                .HasData(
                    new Doctor { DoctorId = 1 , DoctorFullName = "Ahmed Hassan" , DoctorSpecialization = "Cardiologist" ,DoctorEmail = "ahmed.hassan@hms.com", DoctorPhone="01010000001" , DoctorSalary = 45000 , DepartementId = 1},
                    new Doctor { DoctorId = 2 , DoctorFullName = "Mona Adel" , DoctorSpecialization = "Cardiologist" ,DoctorEmail = "mona.adel@hms.com", DoctorPhone= "01010000002", DoctorSalary = 42000, DepartementId = 1},
                    new Doctor { DoctorId = 3 , DoctorFullName = "Omar Khaled", DoctorSpecialization = "Pediatrician", DoctorEmail = "omar.khaled@hms.com", DoctorPhone= "01010000003", DoctorSalary = 38000, DepartementId = 2},
                    new Doctor { DoctorId = 4 , DoctorFullName = "Nour Samir", DoctorSpecialization = "Pediatrician", DoctorEmail = "nour.samir@hms.com", DoctorPhone= "01010000004", DoctorSalary = 36000 , DepartementId = 2},
                    new Doctor { DoctorId = 5 , DoctorFullName = "Karim Tarek", DoctorSpecialization = "Orthopedic Surgeon", DoctorEmail = "karim.tarek@hms.com", DoctorPhone= "01010000005", DoctorSalary = 50000, DepartementId = 3},
                    new Doctor { DoctorId = 6 , DoctorFullName = "Salma Youssef", DoctorSpecialization = "Orthopedic Specialist", DoctorEmail = "salma.youssef@hms.com", DoctorPhone= "01010000006", DoctorSalary = 41000, DepartementId = 3},
                    new Doctor { DoctorId = 7 , DoctorFullName = "Youssef Emad", DoctorSpecialization = "Dermatologist", DoctorEmail = "youssef.emad@hms.com", DoctorPhone= "01010000007", DoctorSalary = 39000, DepartementId = 4},
                    new Doctor { DoctorId = 8 , DoctorFullName = "Laila Mostafa", DoctorSpecialization = "Dermatologist", DoctorEmail = "laila.mostafa@hms.com", DoctorPhone= "01010000008", DoctorSalary = 37000, DepartementId = 4 }
                );


            modelBuilder.Entity<Patient>()
                .HasData(
                    
                    new Patient { PatientId = 1 , PatientFullName = "Omer Ali" , PatientGender ="Male" , PatientDateOfBirth = new DateTime(1995,03,12), PatientPhone = "01120000001"  ,patientAddress = "Nasr City, Cairo" },
                    new Patient { PatientId = 2 , PatientFullName = "Sara Ahmed", PatientGender = "Female", PatientDateOfBirth = new DateTime(1998 , 07 , 24), PatientPhone = "01120000002", patientAddress = "Dokki, Giza" },
                    new Patient { PatientId = 3 , PatientFullName = "Mahmoud Samir", PatientGender ="Male" , PatientDateOfBirth = new DateTime(1987 ,11 ,05), PatientPhone = "01120000003", patientAddress = "Heliopolis, Cairo" },
                    new Patient { PatientId = 4 , PatientFullName = "Mariam Adel", PatientGender ="Female" , PatientDateOfBirth = new DateTime(2002 ,01 ,19), PatientPhone = "01120000004", patientAddress = "Giza" },
                    new Patient { PatientId = 5 , PatientFullName = "Yassin Mohamed", PatientGender ="Male" , PatientDateOfBirth = new DateTime(1979 ,09 ,30), PatientPhone = "01120000005"  ,patientAddress = "Maadi, Cairo" },
                    new Patient { PatientId = 6 , PatientFullName = "Hana Khaled", PatientGender ="Female" , PatientDateOfBirth = new DateTime(1991 , 05 ,14), PatientPhone = "01120000006"  ,patientAddress = "October, Giza" }
                );


            modelBuilder.Entity<Appointment>()
                .HasData(
                
                    new Appointment { AppointmentId = 1, AppointmentDate = new DateTime( 2026 , 09 , 29,9 ,0 ,0 ) , Status = "Scheduled" , DoctorId = 1, PatientId = 1 },
                    new Appointment { AppointmentId = 2, AppointmentDate = new DateTime(2026 , 09 , 29, 10,0,0) , Status = "Scheduled" , DoctorId = 3, PatientId = 6 },
                    new Appointment { AppointmentId = 3, AppointmentDate = new DateTime(2026 , 09 , 29 ,11,3,0) , Status = "Completed", DoctorId = 5, PatientId = 3 },
                    new Appointment { AppointmentId = 4, AppointmentDate = new DateTime(2026 , 09 , 29, 13,0,0) , Status = "Cancelled" , DoctorId = 7, PatientId = 4 },
                    new Appointment { AppointmentId = 5, AppointmentDate = new DateTime(2026 , 09, 28, 11, 3 , 0) , Status = "Completed" , DoctorId = 2, PatientId = 5 },
                    new Appointment { AppointmentId = 6, AppointmentDate = new DateTime(2026 , 09 , 28, 12,0,0) , Status = "Completed" , DoctorId = 4, PatientId = 6 }

                );


            modelBuilder.Entity<MedicalRecord>()
            .HasData(
                
                    new MedicalRecord { MedicalRecordId = 1, Diagnosis = "Hypertension Amlodipine", Description = "5mg once daily Follow", Notes = "up after two weeks.", AppointmentId = 3 },
                    new MedicalRecord { MedicalRecordId = 2, Diagnosis = "Acute respiratory infection", Description = "Rest and fluids", Notes = "Patient advised to return if symptoms worsen.", AppointmentId = 5 },
                    new MedicalRecord { MedicalRecordId = 3, Diagnosis = "Knee ligament injury", Description = "Physiotherapy and rest", Notes = "MRI recommended.", AppointmentId = 6 },
                    new MedicalRecord { MedicalRecordId = 4, Diagnosis = "Mild eczema", Description = "Topical moisturizer twice daily", Notes = "Avoid known skin irritants.", AppointmentId = 2 },
                    new MedicalRecord { MedicalRecordId = 5 , Diagnosis = "Migraine", Description = "Paracetamol as needed", Notes = "Maintain regular sleep schedule.", AppointmentId = 4 }
            );




            base.OnModelCreating(modelBuilder);
        }
    }
}

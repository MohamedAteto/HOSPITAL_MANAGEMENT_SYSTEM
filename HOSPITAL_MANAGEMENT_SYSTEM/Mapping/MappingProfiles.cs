using AutoMapper;
using HOSPITAL_MANAGEMENT_SYSTEM.DTOs.AppointmentDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM.DTOs.DepartmentDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM.DTOs.DoctorDTO;
using HOSPITAL_MANAGEMENT_SYSTEM.DTOs.Medical_RecordDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM.DTOs.PatientDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() { 
            CreateMap<Patient,PatientDTO>().ReverseMap();
            CreateMap<MedicalRecord, MedicalRecordDTO>().ReverseMap();
            CreateMap<Doctor, DoctorDTO>().ReverseMap();
            CreateMap<Department, DepartmentDTO>().ReverseMap();
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
        }
    }
}

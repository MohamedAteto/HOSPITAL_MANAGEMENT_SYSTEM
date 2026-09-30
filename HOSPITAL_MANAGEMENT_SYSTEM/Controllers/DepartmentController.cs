using AutoMapper;
using HOSPITAL_MANAGEMENT_SYSTEM.Data;
using HOSPITAL_MANAGEMENT_SYSTEM.DTOs.DepartmentDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM.Mapping;
using HOSPITAL_MANAGEMENT_SYSTEM.Models;
using HOSPITAL_MANAGEMENT_SYSTEM.Reposatories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HOSPITAL_MANAGEMENT_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepo _repo;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentRepo repo, AppDbContext context)
        {
            _repo = repo;
            _context = context;
            _mapper = new MapperConfiguration(s => s.AddProfile<MappingProfiles>()).CreateMapper();
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            var item = _repo.GetAll().ToList();

            if (item is null || item.Count < 0)
                return BadRequest("List Is null ");

            var DTO = _mapper.Map<List<DepartmentDTO>>(item);

            return Ok(DTO);

        }

        [HttpGet("GetEach_DepartmentWithNumberOf_Doctors")]
        public IActionResult GetWtihDocCounts()
        {
            var items = _repo.GetDepartmentsWithDoctorCount()
                .Select(d => new
                {

                    Id = d.DepartementId,
                    Name = d.DepartementName,
                    Location = d.DepartementLocation,
                    DoctorCount = d.Doctors.Count
                })
                .ToList();

            if (items is null || items.Count < 0)
                return BadRequest("NOt Found");

            return Ok(items);
        }





    }
}

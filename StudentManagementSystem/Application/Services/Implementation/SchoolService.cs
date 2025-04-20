using StudentManagementSystem.Application.DTOs.SchoolDTO;
using StudentManagementSystem.Application.Services.Interface;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructures;

namespace StudentManagementSystem.Application.Services.Implementation
{
    public class SchoolService(IApplicationDbContext _context) : ISchoolService
    {
        public IEnumerable<SchoolViewModel> GetSchools(int? SchoolId)
        {
            var Schools = _context.Schools.AsQueryable();
            if (SchoolId.HasValue)
            {
                Schools = Schools.Where(school => school.Id == SchoolId);
            }
            return [.. Schools.Select(school => new SchoolViewModel
            {
                SchoolName = school.SchoolName,
                Address = school.Address
            })];
        }

        public bool CreateSchool(CreateSchoolModel School)
        {
            var newSchool = new School
            {
                SchoolName = School.SchoolName,
                Address = School.Address
            };
            _context.Schools.Add(newSchool);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateSchool(UpdateSchoolModel updateSchool)
        {
            var school = _context.Schools.FirstOrDefault(s => s.Id == updateSchool.Id);
            if (school != null)
            {
                school.SchoolName = updateSchool.NameSchool;
                school.Address = updateSchool.Address;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteSchool(int id)
        {
            var school = _context.Schools.FirstOrDefault(s => s.Id == id);
            if (school != null)
            {
                _context.Schools.Remove(school);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
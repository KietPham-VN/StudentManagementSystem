using Application.DTOs.SchoolDTO;
using Application.Services.Interface;
using Domain.Entities;

namespace Application.Services.Implementation
{
    public class SchoolService(IApplicationDbContext context) : ISchoolService
    {
        public IEnumerable<SchoolViewModel> GetSchools(int? SchoolId)
        {
            var Schools = context.Schools.AsQueryable();
            if (SchoolId.HasValue)
            {
                Schools = Schools.Where(school => school.Id == SchoolId);
            }
            return
            [.. Schools.Select
                (
                    school => new SchoolViewModel
                    {
                        SchoolName = school.SchoolName,
                        Address = school.Address
                    }
                )
            ];
        }

        public SchoolCreateModel CreateSchool(SchoolCreateModel School)
        {
            var newSchool = new School
            {
                SchoolName = School.SchoolName,
                Address = School.Address
            };
            context.Schools.Add(newSchool);
            context.SaveChanges();
            return new SchoolCreateModel()
            {
                SchoolId = newSchool.Id,
                SchoolName = newSchool.SchoolName,
                Address = newSchool.Address
            };
        }

        public SchoolUpdateModel UpdateSchool(SchoolUpdateModel updateSchool)
        {
            var school = context.Schools.FirstOrDefault(s => s.Id == updateSchool.Id);
            if (school != null)
            {
                school.SchoolName = updateSchool.NameSchool;
                school.Address = updateSchool.Address;
                context.SaveChanges();
                return new SchoolUpdateModel
                {
                    Id = school.Id,
                    NameSchool = school.SchoolName,
                    Address = school.Address
                };
            }
            return null;
        }

        public SchoolViewModel DeleteSchool(int id)
        {
            var school = context.Schools.FirstOrDefault(s => s.Id == id);
            if (school != null)
            {
                context.Schools.Remove(school);
                context.SaveChanges();
                return new SchoolViewModel
                {
                    SchoolName = school.SchoolName,
                    Address = school.Address
                };
            }
            return null;
        }
    }
}
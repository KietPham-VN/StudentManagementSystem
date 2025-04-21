using Microsoft.IdentityModel.Tokens;
using StudentManagementSystem.Application.DTOs.StudentDTO;
using StudentManagementSystem.Application.Services.Interface;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructures;

namespace StudentManagementSystem.Application.Services.Implementation
{
    public class StudentService(IApplicationDbContext _context) : IStudentService
    {
        public IEnumerable<StudentViewModel> GetStudents(int? Id)
        {
            var query = _context.Students.AsQueryable();

            if (Id.HasValue)
            {
                query = query.Where(student => student.Id == Id.Value);
            }

            foreach (var student in query)
            {
                if (student == null)
                {
                    throw new Exception("Student Not Found");
                }
            }

            var students = query.Select(student => new StudentViewModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Address = student.Address,
                SchoolId = student.SchoolId,
            }).ToList();

            return students.IsNullOrEmpty() ? throw new Exception("Student Not Found") : students;
        }

        public StudentCreateModel CreateStudent(StudentCreateModel student)
        {
            var data = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Address = student.Address,
                SchoolId = student.SchoolId
            };
            _context.Students.Add(data);
            _context.SaveChanges();
            return new StudentCreateModel
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                DateOfBirth = data.DateOfBirth,
                Address = data.Address,
                SchoolId = data.SchoolId,
            };
        }

        public StudentUpdateModel UpdateStudent(StudentUpdateModel student)
        {
            var Student = _context.Students.Find(student.Id);
            if (student != null && Student != null)
            {
                Student.FirstName = student.FirstName;
                Student.LastName = student.LastName;
                Student.DateOfBirth = student.DateOfBirth;
                Student.Address = student.Address;
                Student.SchoolId = student.SchoolId;
                _context.SaveChanges();
                return new StudentUpdateModel
                {
                    Id = Student.Id,
                    FirstName = Student.FirstName,
                    LastName = Student.LastName,
                    DateOfBirth = Student.DateOfBirth,
                    Address = Student.Address,
                    SchoolId = Student.SchoolId
                };
            }
            else
            {
                throw new Exception("Student not found");
            }
        }

        public StudentViewModel DeleteStudent(int id)
        {
            var Student = _context.Students.Find(id);
            if (Student != null)
            {
                _context.Students.Remove(Student);
                _context.SaveChanges();
                return new StudentViewModel
                {
                    Id = Student.Id,
                    FirstName = Student.FirstName,
                    LastName = Student.LastName,
                    DateOfBirth = Student.DateOfBirth,
                    Address = Student.Address,
                    SchoolId = Student.SchoolId
                };
            }
            else
            {
                throw new Exception("Student not found");
            }
        }
    }
}
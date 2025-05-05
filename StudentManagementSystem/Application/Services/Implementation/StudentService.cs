using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using StudentManagementSystem.Application.DTOs.StudentDTO;
using StudentManagementSystem.Application.Services.Interface;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructures;

namespace StudentManagementSystem.Application.Services.Implementation
{
    public class StudentService(IApplicationDbContext context, IMemoryCache cache) : IStudentService
    {
        private const string STUDENT_KEY = "StudentKey";

        public async Task<IEnumerable<StudentViewModel>> GetAllStudents()
        {
            var data = cache.Get<IEnumerable<StudentViewModel>>(STUDENT_KEY);
            if (data == null)
            {
                data = await GetStudents();
                var cacheOption = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                };
                cache.Set(STUDENT_KEY, data, cacheOption);
            }
            return data;
        }

        public async Task<IReadOnlyList<StudentViewModel>> GetStudents()
        {
            var query = context.Students.AsNoTracking().AsQueryable();

            var students = await query.Select(s => new StudentViewModel
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                DateOfBirth = s.DateOfBirth,
                Address = s.Address,
                SchoolId = s.SchoolId
            }).ToListAsync();

            if (students is null || students.Count == 0)
            {
                throw new KeyNotFoundException("Student(s) not found.");
            }

            return students;
        }

        public async Task<IReadOnlyList<StudentViewModel>> GetStudent(int id)
        {
            var query = context.Students.AsNoTracking().AsQueryable();

            if (id > 0)
            {
                query = query.Where(s => s.Id == id);
            }

            var students = await query.Select(s => new StudentViewModel
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                DateOfBirth = s.DateOfBirth,
                Address = s.Address,
                SchoolId = s.SchoolId
            }).ToListAsync();

            if (students is null || students.Count == 0)
            {
                throw new KeyNotFoundException("Student(s) not found.");
            }

            return students;
        }

        public async Task<StudentCreateModel> CreateStudent(StudentCreateModel student)
        {
            ArgumentNullException.ThrowIfNull(student);

            var entity = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Address = student.Address,
                SchoolId = student.SchoolId
            };

            await context.Students.AddAsync(entity);
            await context.SaveChangesAsync();

            student.Id = entity.Id;
            return student;
        }

        public async Task<StudentUpdateModel> UpdateStudent(StudentUpdateModel student)
        {
            ArgumentNullException.ThrowIfNull(student);

            var existingStudent = await context.Students.FindAsync(student.Id)
                ?? throw new KeyNotFoundException("Student not found.");

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.DateOfBirth = student.DateOfBirth;
            existingStudent.Address = student.Address;
            existingStudent.SchoolId = student.SchoolId;

            await context.SaveChangesAsync();

            return student;
        }

        public async Task<StudentViewModel> DeleteStudent(int id)
        {
            var student = await context.Students.FindAsync(id)
                ?? throw new KeyNotFoundException("Student not found.");

            context.Students.Remove(student);
            await context.SaveChangesAsync();

            return new StudentViewModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Address = student.Address,
                SchoolId = student.SchoolId
            };
        }
    }
}
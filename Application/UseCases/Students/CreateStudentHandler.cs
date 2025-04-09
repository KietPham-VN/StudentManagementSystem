using StudentManagementSystem.Application.DTOs;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Application.UseCases.Students
{
    public class CreateStudentHandler(IApplicationDbContext context)
    {
        public async Task<int> Handle(CreateStudentDto dto, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                AspNetUserId = dto.AspNetUserId,
            };

            context.Students.Add(student);
            await context.SaveChangesAsync(cancellationToken);

            return student.Id;
        }
    }
}
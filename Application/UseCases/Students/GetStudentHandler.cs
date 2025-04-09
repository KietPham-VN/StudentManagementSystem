using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Application.DTOs;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Application.Mappers;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Application.UseCases.Students
{
    public class GetStudentHandler(IApplicationDbContext context)
    {
        public async Task<List<StudentResponseDto>> Handle(int? id, CancellationToken cancellationToken)
        {
            if (id.HasValue)
            {
                var student = await context.Students
                    .AsNoTracking()
                    .FirstOrDefaultAsync(s => s.Id == id.Value, cancellationToken);

                if (student == null)
                    return [];

                return [StudentMapper.ToResponseDto(student)];
            }

            var students = await context.Students
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return [.. students.Select(StudentMapper.ToResponseDto)];
        }

        private StudentResponseDto MapToDto(Student student) => new()
        {
            Id = student.Id,
            AspNetUserId = student.AspNetUserId,
        };
    }
}
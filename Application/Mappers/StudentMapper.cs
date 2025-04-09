using StudentManagementSystem.Application.DTOs;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Application.Mappers;

public static class StudentMapper
{
    public static StudentResponseDto ToResponseDto(Student student)
    {
        return new StudentResponseDto
        {
            Id = student.Id,
            AspNetUserId = student.AspNetUserId,
        };
    }
}
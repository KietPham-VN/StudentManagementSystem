﻿namespace Application.DTOs.CourseDTO
{
    public class CourseUpdateModel
    {
        public int CourseId { get; init; }
        public string? CourseName { get; init; }
        public DateTime StartDate { get; init; }
    }
}
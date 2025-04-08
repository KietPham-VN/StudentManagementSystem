﻿namespace StudentManagementSystem.Domain.Entities
{
    public class ExamStudent
    {
        public int ExamId { get; set; }
        public int StudentId { get; set; }

        public Exam Exam { get; set; }
        public Student Student { get; set; }
    }
}
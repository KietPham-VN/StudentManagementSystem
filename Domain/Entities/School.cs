﻿namespace StudentManagementSystem.Domain.Entities
{
    public class School
    {
        public int Id { get; set; }

        public ICollection<StudentSchool> StudentSchools { get; set; }
        public ICollection<TeacherSchool> TeacherSchools { get; set; }
    }
}
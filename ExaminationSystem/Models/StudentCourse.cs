﻿namespace ExaminationSystem.Models
{
    public class StudentCourse : BaseModel
    {
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}

namespace ExaminationSystem.Models
{
    public class InstructorCourse : BaseModel
    {
        public int InstructorID { get; set; }
        public int CourseID { get; set; }
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}

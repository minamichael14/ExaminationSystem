namespace ExaminationSystem.Models
{
    public class InstructorStudent:BaseModel
    {
        public int InstructorID { get; set; }
        public int StudentID { get; set; }
        public Instructor Instructor { get; set; }
        public Student Student { get; set; }
    }
}

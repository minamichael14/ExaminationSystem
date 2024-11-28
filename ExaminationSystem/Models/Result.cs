namespace ExaminationSystem.Models
{
    public class Result:BaseModel
    {
        public int Value {  get; set; }
        public int StudentID { get; set; }
        public int ExamID { get; set; }
        public Student Student { get; set; }
        public Exam Exam { get; set; }
    }
}

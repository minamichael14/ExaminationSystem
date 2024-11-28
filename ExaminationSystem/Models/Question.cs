namespace ExaminationSystem.Models
{
    public class Question:BaseModel
    {
        public Question() 
        { 
            Choices = new List<Choice>();   
            ExamQuestions = new List<ExamQuestion>();
        }
        public string Body { get; set; }
        public int Grade { get; set; }
        public string level { get; set; }
        public int? CorrectChoiceOrder { get; set; }
        public ICollection<Choice> Choices { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public ICollection<ExamQuestion> ExamQuestions { get; set; }

    }
}

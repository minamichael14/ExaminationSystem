namespace ExaminationSystem.Models
{
    public class Choice : BaseModel
    {
        public string Content { get; set; }
        public int Order { get; set; }
        public int QuestionID { get; set; }
        public Question Question { get; set; }
    }
}

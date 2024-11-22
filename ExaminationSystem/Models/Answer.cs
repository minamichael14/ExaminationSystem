namespace ExaminationSystem.Models
{
    public class Answer :BaseModel
    {
        public int QuestionID { get; set; }
        public Question Question { get; set; }

        public int ChoiceID { get; set; }
        public Choice Choice { get; set; }
    }
}

using ExaminationSystem.ViewModels.Choices;

namespace ExaminationSystem.ViewModels.Questions
{
    public class QuestionViewModel
    {
        
        public int ID { get; set; }
        public string Body { get; set; }
        public int Grade { get; set; }
        public string level { get; set; }

        public int CourseID { get; set; }
        public ICollection<ChoiceViewModel> Choices { get; set; }

    }

}

namespace ExaminationSystem.Services.ExamQuestions
{
    public interface IExamQuestionService
    {
        void AddQuestions(int examID, ICollection<int> questionIds);
        void DeleteQuestions(int ExamID);
    }
}

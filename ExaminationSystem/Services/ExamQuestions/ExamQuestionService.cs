using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models;

namespace ExaminationSystem.Services.ExamQuestions
{
    public class ExamQuestionService : IExamQuestionService
    {
        IRepository<ExamQuestion> _examQuestionsRepository;
        public ExamQuestionService()
        {
            _examQuestionsRepository = new Repository<ExamQuestion>();
        }

        public void AddQuestions(int examID ,ICollection<int> questionIds)
        {
            foreach (int questionID in questionIds)
            {
                _examQuestionsRepository.Add( new ExamQuestion
                {
                    ExamID = examID,
                    QuestionID = questionID
                });
            }
            _examQuestionsRepository.SaveChanges();
        }
    
        public void DeleteQuestions(int ExamID)
        {
            var deletedExamQuestionID = _examQuestionsRepository.Get()
                                                .Where(x=>x.ExamID == ExamID)
                                                .Select(x=>x.ID);
            foreach(var id in deletedExamQuestionID)
            {
                var examQuestions = new ExamQuestion {ID=id };
                _examQuestionsRepository.Delete(examQuestions);
            }
            _examQuestionsRepository.SaveChanges();
        }
    }
}

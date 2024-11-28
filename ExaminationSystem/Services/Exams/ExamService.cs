using AutoMapper;
using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models;
using ExaminationSystem.Services.ExamQuestions;
using ExaminationSystem.Services.Questions;
using ExaminationSystem.Services.Results;
using ExaminationSystem.Services.SubmittedAnswers;
using ExaminationSystem.ViewModels.Exams;
using ExaminationSystem.ViewModels.Results;
using ExaminationSystem.ViewModels.SubmittedAnswers;

namespace ExaminationSystem.Services.Exams
{
    public class ExamService : IExamService
    {
        IRepository<Exam> _examRepository;
        IExamQuestionService _examQuestionService;
        IQuestoionService _questoionService;
        ISubmittedAnswerService _submittedAnswerService;
        IResultService _resultService;
        IMapper _mapper;

        public ExamService(IMapper mapper , IQuestoionService questoionService, ISubmittedAnswerService submittedAnswerService , IResultService resultService)
        {
            _examRepository = new Repository<Exam>();
            _examQuestionService = new ExamQuestionService();
            _questoionService = questoionService;
            _submittedAnswerService = submittedAnswerService;
            _resultService = resultService;
            _mapper = mapper;
        }

        public int CreateExam(Exam exam)
        {
            _examRepository.Add(exam);
            _examRepository.SaveChanges();
            return exam.ID;
        }
        public bool CourseHasFinalExam(int courseID)
        {
            return _examRepository.Get().Any(x => x.CourseID == courseID && x.isFinalExam == true);
        }
        public bool CreateNormalFinalExam(ExamCreateViewModel viewModel)
        {
            // validate if there are other final exams in the course
            if (CourseHasFinalExam(viewModel.CourseID))
            {
                return false;
            }
            else
            {
                var exam = viewModel.ToModel();
                var examID = CreateExam(exam);
                _examQuestionService.AddQuestions(examID, viewModel.QuestionIDs);
                return true;
            }
                
        }
        public bool CreateRandomFinalExam(ExamRandomCreateViewModel viewModel)
        {
            if (CourseHasFinalExam(viewModel.CourseID))
            {
                return false;
            }
            else
            {
                var exam = viewModel.ToModel();
                var examID = CreateExam(exam);
                var questionIDs = _questoionService.GetRandomQuestions(exam.CourseID, viewModel.QuestionNumbers).ToList();
                _examQuestionService.AddQuestions(examID, questionIDs);
                return true;
            }       
        }
        public void CreateNormalQuiz(ExamCreateViewModel viewModel)
        {
            var exam = viewModel.ToModel();
            var examID = CreateExam(exam);
            _examQuestionService.AddQuestions(examID,viewModel.QuestionIDs);
        }
        public void CreateRandomQuiz(ExamRandomCreateViewModel viewModel)
        {
            var exam = viewModel.ToModel();
            var examID = CreateExam(exam);
            var questionIDs = _questoionService.GetRandomQuestions(exam.CourseID, viewModel.QuestionNumbers).ToList();
            _examQuestionService.AddQuestions(examID, questionIDs);
        }
        public void DeleteExam(int id)
        {
            var exam = new Exam { ID = id };
            _examRepository.Delete(exam);
            _examRepository.SaveChanges();
            _examQuestionService.DeleteQuestions(id);
        }

        public void EditExamDetails(ExamEditViewModel viewModel)
        {
            // just edit exam details 
            // No Question Edits
            var exam = viewModel.ToModel();
            _examRepository.SaveInclude(exam, nameof(exam.isFinalExam) , nameof(exam.QuestionNumbers), nameof(exam.TotalGrade),nameof(exam.isRandom));
            _examRepository.SaveChanges();
        }

        public ExamViewModel getExam(int id)
        {
            var exams = _examRepository.GetByID(id);
            return _mapper.Map<ExamViewModel>(exams);
        }

        public void SubmitExam(ExamSubmitViewModel viewModel)
        {

            int totalExamResult = 0;
            var SubmittedAnswerCreateViewModel = new SubmittedAnswerCreateViewModel
            {
                ExamID = viewModel.ExamID,
                StudentID = viewModel.StudentID
            };
            
            // store the answer in the submittedAnswer table
            foreach (var QuestionAnswer in viewModel.QuestionAnswer)
            {
                var isCorrect = _questoionService.isCorrect(QuestionAnswer.Key, QuestionAnswer.Value);
                
                SubmittedAnswerCreateViewModel.QuestionID = QuestionAnswer.Key;
                SubmittedAnswerCreateViewModel.Choiceorder = QuestionAnswer.Value;
                SubmittedAnswerCreateViewModel.IsCorrect = isCorrect;

                _submittedAnswerService.Create(SubmittedAnswerCreateViewModel);

                if (isCorrect)
                {
                    totalExamResult += _questoionService.GetQuestionGrade(QuestionAnswer.Key);
                }
            }
            var resultCreateViewModel = new ResultCreateViewModel
            {
                value = totalExamResult,
                ExamID= viewModel.ExamID,
                StudentID  = viewModel.StudentID
            };
            _resultService.Save(resultCreateViewModel);
        }

        public IEnumerable<ExamViewModel> GetCourseExams(int courseID)
        {
            var exams = _examRepository.Get()
                .Where(e => e.CourseID == courseID);
            
            return _mapper.ProjectTo<ExamViewModel>(exams);
        }

        public IEnumerable<ExamViewModel> GetAll()
        {
            var exams = _examRepository.Get();

            return _mapper.ProjectTo<ExamViewModel>(exams);
        }

    }
}

using AutoMapper;
using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models;
using ExaminationSystem.Services.Courses;
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
        ICourseService _courseService;
        IMapper _mapper;

        public ExamService(IMapper mapper, 
            IQuestoionService questoionService, 
            ISubmittedAnswerService submittedAnswerService,
            IResultService resultService,
            ICourseService courseService)
        {
            _examRepository = new Repository<Exam>();
            _examQuestionService = new ExamQuestionService();
            _questoionService = questoionService;
            _submittedAnswerService = submittedAnswerService;
            _resultService = resultService;
            _courseService = courseService;
            
            _mapper = mapper;
        }
        
        public bool CreateNormalFinalExam(ExamCreateViewModel viewModel)
        {
            bool isValid = ValidateExam(viewModel);
            if (isValid)
            {
                var examID = CreateExam(viewModel);
                _examQuestionService.AddQuestions(examID, viewModel.QuestionIDs);
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool CreateRandomFinalExam(ExamCreateViewModel viewModel)
        {
            bool isValid = ValidateExam(viewModel);
            if (isValid)
            {
                var examID = CreateExam(viewModel);
                var questionIDs = _questoionService.GetRandomQuestions(viewModel.CourseID, viewModel.QuestionNumbers).ToList();
                _examQuestionService.AddQuestions(examID, questionIDs);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CreateNormalQuiz(ExamCreateViewModel viewModel)
        {
            bool isValid = ValidateExam(viewModel);
            if (isValid)
            {
                var examID = CreateExam(viewModel);
                _examQuestionService.AddQuestions(examID, viewModel.QuestionIDs);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CreateRandomQuiz(ExamCreateViewModel viewModel)
        {
            bool isValid = ValidateExam(viewModel);
            if (isValid)
            {
                var examID = CreateExam(viewModel);
                var questionIDs = _questoionService.GetRandomQuestions(viewModel.CourseID, viewModel.QuestionNumbers).ToList();
                _examQuestionService.AddQuestions(examID, questionIDs);
                return true;
            }
            else
            {
                return false ;
            }
        }
        public bool DeleteExam(int id)
        {
            if (_examRepository.IsExist(id)) 
            {
                var exam = new Exam { ID = id };
                _examRepository.Delete(exam);
                _examRepository.SaveChanges();
                _examQuestionService.DeleteQuestions(id);
                return true;
            }
            else
            {
                return false;
            }   
        }
        public bool EditExamDetails(ExamEditViewModel viewModel)
        {
            //Note: just edit exam details -> No Question Edits
            if (_examRepository.IsExist(viewModel.ID))
            {
                var exam = viewModel.ToModel();
                _examRepository.SaveInclude(exam, nameof(exam.isFinalExam), nameof(exam.TotalGrade), nameof(exam.isRandom));
                _examRepository.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public ExamViewModel GetExam(int id)
        {
            if (_examRepository.IsExist(id))
            {
                var exams = _examRepository.GetByID(id);
                return _mapper.Map<ExamViewModel>(exams);
            }
            else
            {
                //return default;
                throw new ArgumentException("No Exam existed with the specified ExamID.");
            }
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
            if (_courseService.IsExist(courseID))
            {
                var exams = _examRepository.Get()
                            .Where(e => e.CourseID == courseID);
                return _mapper.ProjectTo<ExamViewModel>(exams);
            }
            else
            {
                //return default;
                throw new ArgumentException("No course existed with the specified CourseID.");
            }
        }
        public IEnumerable<ExamViewModel> GetAll()
        {
            var exams = _examRepository.Get();

            return _mapper.ProjectTo<ExamViewModel>(exams);
        }
        
        private int CreateExam(ExamCreateViewModel viewModel)
        {
            var exam = viewModel.ToModel();
            _examRepository.Add(exam);
            _examRepository.SaveChanges();
            return exam.ID;
        }
        private bool CourseHasFinalExam(int courseID)
        {
            return _examRepository.Get().Any(x => x.CourseID == courseID && x.isFinalExam == true);
        }
        private bool ValidateExam(ExamCreateViewModel viewModel)
        {
            if (viewModel.QuestionNumbers <= 0)
            {
                return false;
            }
            if (viewModel.TotalGrade <= 0)
            {
                return false;
            }
            if (!_courseService.IsExist(viewModel.CourseID))
            {
                return false;
            }
            if (viewModel.isRandom)
            {
                if (viewModel.QuestionIDs != null)
                {
                    return false;
                }
            }
            else
            {
                if (viewModel.QuestionIDs == null || !viewModel.QuestionIDs.Any())
                {
                    return false;
                }
                var validQuestions = _questoionService.GetByCourse(viewModel.CourseID).Select(x => x.ID);
                if (viewModel.QuestionIDs.Any(q => !validQuestions.Contains(q)))
                {
                    return false;
                }
            }

            if (viewModel.isFinalExam)
            {
                if (CourseHasFinalExam(viewModel.CourseID))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

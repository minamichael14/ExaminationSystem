using AutoMapper;
using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models;
using ExaminationSystem.Services.Choices;
using ExaminationSystem.ViewModels.Choices;
using ExaminationSystem.ViewModels.Questions;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Services.Questions
{
    public class QuestionService : IQuestoionService
    {
        IRepository<Question> _questioRepository;
        IChoiceService _choiceService;
        IMapper _mapper;


        public QuestionService(IRepository<Question> repository, IChoiceService choiceService,IMapper mapper)
        {
            _questioRepository = repository;
            _choiceService = choiceService;
            _mapper = mapper;
        }
        public void Add(QuestionCreateViewModel ViewModel)
        {
            //_mapper.ProjectTo(Question) <QuestionCreateViewModel>;
            var question = ViewModel.ToModel();
            _questioRepository.Add(question);
            _questioRepository.SaveChanges();
            foreach (var choice in ViewModel.Choices)
            {
                choice.QuestionID = question.ID;
            }
            _choiceService.Add(ViewModel.Choices);
            
        }
        public void Delete(int questionId)
        {
            var question = new Question { ID= questionId};
            _questioRepository.Delete(question);
            _questioRepository.SaveChanges();
            _choiceService.Delete(questionId);
        }

        public IEnumerable<QuestionViewModel> GetAll()
        {
            var question = _questioRepository.Get();

            return _mapper.ProjectTo<QuestionViewModel>(question);
            
        }

        public IEnumerable<QuestionViewModel> GetByCourse(int courseID)
        {
            var question = _questioRepository.Get().Where(x=> x.CourseID == courseID);

            return _mapper.ProjectTo<QuestionViewModel>(question);
        }

        public IEnumerable<int> GetRandomQuestions(int courseID, int questionsNumber)
        {
            Random random = new Random();
            var allQuestionIDs = _questioRepository.Get().Where(x => x.CourseID == courseID).Select(q => q.ID).ToList();
            int index = 0;
            var selectedQuestionsID = new HashSet<int>();
            var questionsCount = allQuestionIDs.Count();
            for (int i = 0; ; i++)
            {
                index = random.Next(questionsCount);

                selectedQuestionsID.Add(allQuestionIDs[index]);
                if (selectedQuestionsID.Count == questionsNumber)
                {
                    break;
                }
            }
            return selectedQuestionsID;
        }

        public QuestionViewModel GetById(int questionId)
        {
            var question = _questioRepository.Get().Where(x => x.ID == questionId);
  
            return _mapper.ProjectTo<QuestionViewModel>(question).FirstOrDefault();

        }

        public void Update(QuestionEditViewModel ViewModel)
        {
            //var question = _mapper.Map<Question>(ViewModel);
            var question = ViewModel.ToModel();
            _questioRepository.SaveInclude(question, nameof(question.Body), nameof(question.Grade), nameof(question.level) , nameof(question.CorrectChoiceOrder));
            _questioRepository.SaveChanges();
            _choiceService.Update(ViewModel.Choices);
            
        }

        public bool isCorrect(int questionId, int choiceOrder)
        {
            var correctChoiceOrder = _questioRepository.Get()
                                        .Where(x => x.ID == questionId)
                                        .Select(x => x.CorrectChoiceOrder)
                                        .FirstOrDefault();
            if(correctChoiceOrder == choiceOrder)
            {
                return true;
            }
            return false;
        }

        public int GetQuestionGrade(int questionId)
        {
            return _questioRepository.Get().Where(q=>q.ID == questionId).Select(q => q.Grade).FirstOrDefault();
        }
    }
}

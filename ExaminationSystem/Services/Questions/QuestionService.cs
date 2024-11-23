using AutoMapper;
using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models;
using ExaminationSystem.Services.Answers;
using ExaminationSystem.Services.Choices;
using ExaminationSystem.ViewModels.Answers;
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
            var question = ViewModel.ToModel();
            _questioRepository.Add(question);
            _questioRepository.SaveChanges();
            foreach (var choice in ViewModel.Choices)
            {
                choice.QuestionID = question.ID;
                _choiceService.Add(choice);
            }
        }
        public void Delete(int questionId)
        {
            var question = new Question { ID= questionId};
            _questioRepository.Delete(question);
            _questioRepository.SaveChanges();
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

        public QuestionViewModel GetById(int questionId)
        {
            var question = _questioRepository.Get().Where(x => x.ID == questionId);

            return _mapper.ProjectTo<QuestionViewModel>(question).FirstOrDefault();

        }

        public void Update(QuestionEditViewModel ViewModel)
        {
            //var question = _mapper.Map<Question>(ViewModel);
            var question = ViewModel.ToModel();
            _questioRepository.SaveInclude(question, nameof(question.Body), nameof(question.Grade), nameof(question.level));
            _questioRepository.SaveChanges();
            foreach (var choice in ViewModel.Choices)
            {
                _choiceService.Update(choice);
            }
        }
    }
}

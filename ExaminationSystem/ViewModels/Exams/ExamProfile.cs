using AutoMapper;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Questions;

namespace ExaminationSystem.ViewModels.Exams
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<Exam, ExamViewModel>()
                .ForMember(dst => dst.Questions, opt => opt.MapFrom(src => src.ExamQuestions.Select(x => x.Question))); 
        }
    }
}

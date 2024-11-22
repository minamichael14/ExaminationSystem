﻿using AutoMapper;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Choices;

namespace ExaminationSystem.ViewModels.Questions
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {

            CreateMap<Question, QuestionViewModel>()
                    .ForMember(dst => dst.Choices, opt => opt.MapFrom(src => src.Choices));

            CreateMap<QuestionEditViewModel, Question>()
               .ForMember(dst => dst.Choices, opt => opt.MapFrom(src => src.Choices))
               ;          
            

            CreateMap<Choice, ChoiceViewModel>()
              .ForMember(dst => dst.Iscorrect, opt => opt.MapFrom(src => src.Question.Answer.ChoiceID == src.ID ? true : false));

            //CreateMap<ChoiceEditViewModel, Choice>()
            //    .ForMember(dst=> dst.Question , opt=> opt.MapFrom(src => src.QuestionID));

            //CreateMap<AnswerEditViewModel, Answer>();
        }
    }
}

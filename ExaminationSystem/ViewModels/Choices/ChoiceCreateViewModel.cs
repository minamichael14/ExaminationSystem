﻿using ExaminationSystem.Models;

namespace ExaminationSystem.ViewModels.Choices
{
    public class ChoiceCreateViewModel
    {
        public string Content { get; set; }
        public int QuestionID { get; set; }
        public int Order {  get; set; }

    }

    public static class ChoiceCreateViewModelExtension
    {
        public static Choice ToModel(this ChoiceCreateViewModel viewModel)
        {
            return new Choice
            {
                Content = viewModel.Content,
                QuestionID = viewModel.QuestionID,
                Order = viewModel.Order
            };
        }

        public static ICollection<Choice> ToModel(this ICollection<ChoiceCreateViewModel> viewModel)
        {
            var choices = new List<Choice>();
            foreach (var item in viewModel)
            {
                choices.Add(new Choice
                {
                    Content = item.Content,
                    QuestionID = item.QuestionID,
                    Order = item.Order
                });
            }
            return choices;
        }
    }
}


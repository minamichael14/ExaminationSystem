using ExaminationSystem.Models;

namespace ExaminationSystem.ViewModels.Students
{
    public class StudentCreateViewModel
    {
        public string Name { get; set; }
        public int Grade { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
    }

    public static class StudentCreateViewModelExtension
    {
        public static Student ToModel(this StudentCreateViewModel viewModel)
        {
            return new Student
            {
                Name = viewModel.Name,
                Grade = viewModel.Grade,
                Age = viewModel.Age,
                Phone = viewModel.Phone
            };
        }

    }
}

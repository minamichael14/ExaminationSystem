using ExaminationSystem.Models;

namespace ExaminationSystem.ViewModels.Students
{
    public class StudentEditViewModel : StudentCreateViewModel
    {
        public int ID { get; set; }
    }

    public static class StudentEditViewModelExtension
    {
        public static Student ToModel(this StudentEditViewModel viewModel)
        {
            var student = ((StudentCreateViewModel)viewModel).ToModel();
            student.ID = viewModel.ID;
            return student;
        }
    }    
}

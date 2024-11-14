using ExaminationSystem.Models;

namespace ExaminationSystem.ViewModels.Instructors
{
    public class InstructorViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    public static class InstructorViewModelExtension
    {
        public static InstructorViewModel ToViewModel(this Instructor instructor)
        {
            return new InstructorViewModel
            {
                ID = instructor.ID,
                Name = instructor.Name,
                Phone = instructor.Phone
            };
        }


        public static IQueryable<InstructorViewModel> ToViewModel(this IQueryable<Instructor> instructors)
        {
            return instructors.Select(x => new InstructorViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Phone = x.Phone
            });
        }
    }
}

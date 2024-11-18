using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Instructors;
using System.Runtime.CompilerServices;

namespace ExaminationSystem.ViewModels.Students
{
    public class StudentViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
    }

    public static class StudentViewModelExtension
    {
        public static StudentViewModel ToViewModel(this Student student)
        {
            return new StudentViewModel
            {
                ID = student.ID,
                Name = student.Name,
                Grade = student.Grade,
                Age = student.Age,
                Phone = student.Phone
            };
        }

        public static IQueryable<StudentViewModel> ToViewModel(this IQueryable<Student> students)
        {
            return students.Select(x => new StudentViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Grade = x.Grade,
                Age = x.Age,
                Phone = x.Phone
            });
        }
    }
}

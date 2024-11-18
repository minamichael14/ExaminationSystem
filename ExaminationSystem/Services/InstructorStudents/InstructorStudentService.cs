using ExaminationSystem.Data.Repository;
using ExaminationSystem.Models;

namespace ExaminationSystem.Services.InstructorStudents
{
    public class InstructorStudentService : IInstructorStudentService
    {
        IRepository<InstructorStudent> _instructorStudentRepository;
        public InstructorStudentService()
        {
            _instructorStudentRepository = new Repository<InstructorStudent>();
        }


        public void EnrollStudentByInstructor(int StudentID, int InstructorID)
        {
            _instructorStudentRepository.Add(new InstructorStudent
            {
                StudentID = StudentID,
                InstructorID = InstructorID
            });
            _instructorStudentRepository.SaveChanges();
        }
    }
}

using ExaminationSystem.Models;

namespace ExaminationSystem.ViewModels.Results
{
    public class ResultViewModel
    {
        public int ID { get; set; }
        public int Value { get; set; }
        public int StudentID { get; set; }
        public int ExamID { get; set; }
    }

    public static class ResultViewModelExtension
    {
        public static ResultViewModel ToViewModel(this Result result)
        {
            return new ResultViewModel
            {
                ID = result.ID,
                ExamID = result.ExamID,
                StudentID = result.StudentID,
                Value = result.Value
            };
        }

        public static IQueryable<ResultViewModel> ToViewModel(this IQueryable<Result> results)
        {
            return results.Select(x => new ResultViewModel
            {
                ID = x.ID,
                ExamID=x.ExamID,
                StudentID=x.StudentID,
                Value=x.Value
            }
            );
            
        }
    }

}

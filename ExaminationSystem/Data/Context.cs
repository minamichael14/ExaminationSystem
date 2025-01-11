using ExaminationSystem.Models;
using ExaminationSystem.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ExaminationSystem.Data
{
    public class Context : DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<RoleFeature> RoleFeatures { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = .\SQLExpress; Initial Catalog = ExaminationSystem; Integrated security = true; trust server certificate = true")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(logs=> Debug.WriteLine(logs),LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define the one-to-many relationship between Question and Choice
            modelBuilder.Entity<Choice>()
                .HasOne(c => c.Question)
                .WithMany(q => q.Choices)
                .HasForeignKey(c => c.QuestionID);


            modelBuilder.Entity<ExamQuestion>()
            .HasOne(eq => eq.Question)         
            .WithMany(q => q.ExamQuestions)    
            .HasForeignKey(eq => eq.QuestionID) 
            .OnDelete(DeleteBehavior.Restrict);



        }

    }
}

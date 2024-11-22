using ExaminationSystem.Models;
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
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Choice> Choices { get; set; }
       

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

            // Define the one-to-one relationship between Question and Answer
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithOne(q => q.Answer)
                .HasForeignKey<Answer>(a => a.QuestionID)
                .OnDelete(DeleteBehavior.Restrict);  // No cascade delete here


            // Define the foreign key relationship between Answer and Choice (for correct answer)
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Choice)
                .WithMany()
                .HasForeignKey(a => a.ChoiceID);

        }

    }
}
